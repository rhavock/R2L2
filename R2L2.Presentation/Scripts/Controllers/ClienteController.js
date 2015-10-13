var ClienteController = function ($scope, ClienteService) {
    Listar();

    function Listar() {
        var getData = ClienteService.Listar();

        getData.then(function (cliente) {
            $scope.clientes = cliente.data;
        }, function () {
            toastr.error('Erro ao carregar os clientes');
        });
    };

    $scope.Atualizar = function (cliente) {
        var getData = ClienteService.Obter(cliente.Cpf);
        $scope.Action = "Atualizar";
        getData.then(function (cli) {
            $scope.cliente = cli.data;
            $scope.Cpf = cliente.Cpf;
            $scope.Nome = cliente.Nome;
            $scope.Desconto = cliente.Desconto;
            $scope.Cep = cliente.Cep;
            $scope.Rua = cliente.Rua;
            $scope.Bairro = cliente.Bairro;
            $scope.Cidade = cliente.Cidade;
            $scope.Numero = cliente.Numero;
            $scope.Uf = cliente.Uf;
            $scope.Referencia = cliente.Referencia;
            

            var id = $('#atualizaClie').attr('href');
            $(id).addClass('active');
            var offcanvas = ($(id).closest('.offcanvas:first').length > 0);
            $('body').addClass('offcanvas-expanded');

            var width = $(id).width();
            if (width > $(document).width()) {
                width = $(document).width() - 8;
                $(id + '.active').css({ 'width': width });
            }
            width = '-' + width;
            var translate = 'translate(' + width + 'px,0)';
            $(id + '.active').css({ '-webkit-transform': translate, '-ms-transform': translate, '-o-transform': translate, 'transform': translate });

            if ($('#base > .backdrop').length === 0 && $('#base').data('backdrop') !== 'hidden') {
                $('<div class="backdrop"></div>').hide().appendTo('#base').fadeIn();
            }
            $('#formclie').removeClass('ng-hide');
            $('#desconto').addClass('dirty');
            $('#uf').addClass('dirty');
            $('#num').addClass('dirty');
            $('#cid').addClass('dirty');
            $('#bai').addClass('dirty');
            $('#rua').addClass('dirty');
            $('#cep').addClass('dirty');
            $('#desconto').addClass('dirty');
            $('#nom').addClass('dirty');
            $('#cp').addClass('dirty');
            $('#refer').addClass('dirty');

            evalScrollbar();
        }, function () {
            toastr.error('Erro ao obter o cliente');
        });
       
    }

    $scope.Adicionar = function () {
        var Cliente = {

            Cpf: $scope.Cpf,
            Nome: $scope.Nome,
            Desconto: $scope.Desconto,
            Cep: $scope.Cep,
            Rua: $scope.Rua,
            Bairro: $scope.Bairro,
            Cidade: $scope.Cidade,
            Numero: $scope.Numero,
            Uf: $scope.Uf,
            Referencia: $scope.Referencia
        };
        var getAction = $scope.Action;

        if (getAction == "Atualizar") {
            Cliente.Cpf = $scope.Cpf;
            var getData = ClienteService.Atualizar(Cliente);
            getData.then(function (msg) {
                Listar();
                toastr.success('Atualizado');
            }, function () {
                toastr.error('Erro ao atualizar o cliente', '');
            });
        }
        else {
            var getData = ClienteService.Adicionar(Cliente);
            getData.then(function (msg) {
                Listar();
                toastr.success('Adicionado');
            }, function () {
                toastr.error('Erro ao adicionar o cliente', '');
            });
        }
        ClearFields();
    }

    $scope.Apagar = function (cliente) {
        var getData = ClienteService.Apagar(cliente);
        getData.then(function (msg) {
            Listar();
            toastr.success('Cliente apagado');
        }, function () {
            toastr.error('Erro ao excluir');
        });
    }

    $scope.AddCliente = function () {
        $('#formclie').removeClass('ng-hide');
        ClearFields();
        $scope.Action = "Adicionar";
    };
    evalScrollbar = function () {
        if (!$.isFunction($.fn.nanoScroller)) {
            return;
        }
        var menu = $('.offcanvas-pane.active');
        if (menu.length === 0)
            return; var menuScroller = $('.offcanvas-pane.active .offcanvas-body');
        var parent = menuScroller.parent();
        if (parent.hasClass('nano-content') === false) {
            menuScroller.wrap('<div class="nano"><div class="nano-content"></div></div>');
        }
        var height = $(window).height() - menu.find('.nano').position().top;
        var scroller = menuScroller.closest('.nano'); scroller.css({ height: height }); scroller.nanoScroller({ preventPageScrolling: true });
    };

    function ClearFields() {
        $scope.cliente = '';
        $scope.Cpf = '';
        $scope.Nome = '';
        $scope.Desconto = '';
        $scope.Cep = '';
        $scope.Rua = '';
        $scope.Bairro = '';
        $scope.Cidade = '';
        $scope.Numero = '';
        $scope.Uf = '';
        $scope.Referencia = '';

        $('[data-toggle="offcanvas"]').removeClass('expanded');
        $('.offcanvas-pane').removeClass('active');
        $('.offcanvas-pane').css({ '-webkit-transform': '', '-ms-transform': '', '-o-transform': '', 'transform': '' });
        $('#base > .backdrop').fadeOut(function () {
            $(this).remove();
        });
    }
}
ClienteController.$inject = ['$scope', 'ClienteService'];
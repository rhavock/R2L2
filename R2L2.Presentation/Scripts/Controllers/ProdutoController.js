var ProdutoController = function ($scope, ProdutoService) {
    Listar();

    function Listar() {

        var getData = ProdutoService.Listar();
        getData.then(function (prod) {
            $scope.produtos = prod.data;
        }, function () {
            toastr.error('Error ao carregar os produtos')
        });
    };

    $scope.Atualizar = function (produto) {
        var getData = ProdutoService.Obter(produto.CodigoBarras);
        $scope.Action = "Atualizar";
        getData.then(function (prod) {
            $scope.produto = prod.data;
            $scope.CodigoBarras = produto.CodigoBarras;
            $('#codBarras').addClass('dirty');
            $scope.Descricao = produto.Descricao;
            $('#descr').addClass('dirty');
            $scope.Estoque = produto.Estoque;
            $('#estq').addClass('dirty');
            $scope.Localizacao = produto.Localizacao;
            $('#local').addClass('dirty');
            $scope.Valor = produto.Valor;
            $('#val').addClass('dirty');
            $scope.Marca = produto.Marca;
            $('#marca').addClass('dirty');
            $scope.EstoqueMin = produto.EstoqueMin
            $('#estqmin').addClass('dirty');
            
            var id = $('#atualizaProd').attr('href');
            $(id).addClass('active');
            var leftOffcanvas = ($(id).closest('.offcanvas:first').length > 0);
            $('body').addClass('offcanvas-expanded');
            var width = $(id).width();
            if (width > $(document).width()) {
                width = $(document).width() - 8;
                $(id + '.active').css({ 'width': width });
            }
            width = '-' + width;
            var translate = 'translate(' + width + 'px, 0)';
            $(id + '.active').css({ '-webkit-transform': translate, '-ms-transform': translate, '-o-transform': translate, 'transform': translate });
            $('#formprod').removeClass('ng-hide');

            if ($('#base > .backdrop').length === 0 && $('#base').data('backdrop') !== 'hidden') {
                $('<div class="backdrop"></div>').hide().appendTo('#base').fadeIn();
            }


        }, function () {
            toastr.error('Erro ao obter o produto');
        });
    }

    $scope.Adicionar = function () {
        var Produto = {
            CodigoBarras: $scope.CodigoBarras,
            Descricao: $scope.Descricao,
            Estoque: $scope.Estoque,
            Localizacao: $scope.Localizacao,
            Valor: $scope.Valor,
            Marca: $scope.Marca,
            EstoqueMin: $scope.EstoqueMin
        };
        var getAction = $scope.Action;

        if (getAction == "Atualizar") {
            Produto.CodigoBarras = $scope.CodigoBarras;
            var getData = ProdutoService.Atualizar(Produto);
            getData.then(function (msg) {
                Listar();
                toastr.success('Atualizado', '');
                // $scope.divProduto = false;
            }, function () {
                toastr.error('Erro ao atualizar o produto', '');
            });
        }
        else {
            var getData = ProdutoService.Adicionar(Produto);
            getData.then(function (msg) {
                Listar();
                toastr.success('Adicionado', '');
                //$scope.divProduto = false;
            }, function () {
                toastr.error('Erro ao adicionar o produto', '');
            });
        }
    
        ClearFields();
    }

    $scope.AddProduto = function () {
        ClearFields();
        $scope.Action = "Adicionar";        
    }

    $scope.Apagar = function (produto) {
        var getData = ProdutoService.Apagar(produto);
        getData.then(function (msg) {
            Listar();
            toastr.success('Produto apagado', '')
        }, function () {
            toastr.error('Erro ao apagar o Produto');
        });
    }

    function ClearFields() {
        $scope.CodigoBarras = "";
        $scope.Descricao = "";
        $scope.Estoque = "";
        $scope.Localizacao = "";
        $scope.Valor = "";
        $('[data-toggle="offcanvas"]').removeClass('expanded');
        $('.offcanvas-pane').removeClass('active');
        $('.offcanvas-pane').css({ '-webkit-transform': '', '-ms-transform': '', '-o-transform': '', 'transform': '' });
        $('#base > .backdrop').fadeOut(function () {
            $(this).remove();
        });
    }
}

ProdutoController.$inject = ['$scope', 'ProdutoService'];
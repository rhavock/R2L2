var UsuarioController = function ($scope, UsuarioService) {
    Listar();

    function Listar() {
        var getData = UsuarioService.Listar();
        getData.then(function (user) {
            $scope.usuarios = user.data;
        }, function () {
            toastr.error('Erro ao carregar os usuários');
        })
    };

    $scope.Atualizar = function (usuario) {
        var getData = UsuarioService.Obter(usuario.Login);
        $scope.Action = "Atualizar";
        getData.then(function (use) {
            $scope.usuario = use.data;
            $scope.Login = usuario.Login;
            $scope.Nome = usuario.Nome;
            $scope.Telefone = usuario.Telefone;
            $scope.Email = usuario.Email;            

        })
    }

    $scope.Adicionar = function () {
       
        if ($scope.Senha != $("#confirmuser").val()) {
            console.log($scope.Senha);
            console.log($("#confirmuser").val());
            toastr.warning('A senha está diferente da confirmação.');
            return;
        }
        var usuario = {
            Nome: $scope.Nome,
            Login: $scope.Login,
            Telefone: $scope.Telefone,
            Email: $scope.Email,
            Senha: $scope.Senha
        };
        var getAction = $scope.Action;

        if (getAction == "Atualizar") {
            var getData = UsuarioService.Atualizar(usuario);
            getData.then(function (msg) {
                Listar();
                toastr.success('Atualizado!');
            }, function () {
                toastr.error('Erro ao atualizar o usuário!');
            });
        }
        else {
            var getData = UsuarioService.Adicionar(usuario);
            getData.then(function () {
                Listar();
                toastr.success('Adicionado');
            }, function () {
                toastr.error('Erro ao adicionar o usuário!');
            });
        }
        ClearFields();
    }
    function ClearFields() {
        $scope.usuario = '';
        $scope.Login = '';
        $scope.Nome = '';
        $scope.Telefone ='';
        $scope.Email = '';

        $('[data-toggle="offcanvas"]').removeClass('expanded');
        $('.offcanvas-pane').removeClass('active');
        $('.offcanvas-pane').css({ '-webkit-transform': '', '-ms-transform': '', '-o-transform': '', 'transform': '' });
        $('#base > .backdrop').fadeOut(function () {
            $(this).remove();
        });
    }
}
UsuarioController.$inject = ['$scope', 'UsuarioService'];
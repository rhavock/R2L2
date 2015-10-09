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
}
ClienteController.$inject = ['$scope', 'ClienteService'];
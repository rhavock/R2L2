var PedidoController = function ($scope, PedidoService) {
    Listar();

    function Listar() {
        var getData = PedidoService.Listar();
        getData.then(function (ped) {
            $scope.pedidos = ped.data;
         }, function () {
            toastr.error('Não foi possível carregar os pedidos');
        })
    };

    $scope.PesquisarCliente = function () {
        
        var getData = PedidoService.PesquisarCliente($('#clienteSearch').text());
        getData.then(function (cli) {
            $scope.clientes = cli.data;
        }, function () {
            toastr.error('Não foi possível carregar os pedidos');
        });
    }
}
PedidoController.$inject = ['$scope', 'PedidoService'];
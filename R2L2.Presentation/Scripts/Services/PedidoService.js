var PedidoService = function ($http) {
    this.Listar = function () {
        return $http.get("/Pedido/Listar");
    }


    this.PesquisarCliente = function (clienteSearch) {
        return $http.get("/Pedido/PesquisarCliente?clienteSearch=" + clienteSearch);
    }
}
PedidoService.$inject = ['$http'];
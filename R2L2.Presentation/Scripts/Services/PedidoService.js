var PedidoService = function ($http) {
    this.Listar = function () {
        return $http.get("/Pedido/Listar");
    }

    this.PesquisarCliente = function (clienteSearch) {
        return $http.get("/Pedido/PesquisarCliente?clienteSearch=" + clienteSearch);
    }

    this.PesquisarProduto = function (produtoSearch) {
        return $http.get("/Pedido/PesquisarProduto?produtoSearch=" + produtoSearch);
    }
}
PedidoService.$inject = ['$http'];
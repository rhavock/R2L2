var ProdutoService = function ($http) {
    this.Listar = function () {
        return $http.get("Produto/Listar");
    }

    this.Obter = function (CodigoBarras) {
        return $http.get("Produto/Obter?CodigoBarras=" + CodigoBarras);
    }

    this.Atualizar = function (produto) {
        var response = $http({
            method: "post",
            url: "Produto/Atualizar",
            data: JSON.stringify(produto),
            dataType: "json"
        });
        return response;
    }
    this.Adicionar = function (produto) {
        var response = $http({
            method: "post",
            url: "Produto/Adicionar",
            data: JSON.stringify(produto),
            dataType: "json"
        });
        return response;
    }

    this.Apagar = function (produto) {
        var response = $http({
            method: "post",
            url: "Produto/Apagar",
            data: JSON.stringify(produto),
            dataType: "json"
        });
        return response;
    }
}
ProdutoService.$inject = ['$http'];
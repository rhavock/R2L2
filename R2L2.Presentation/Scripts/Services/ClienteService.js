var ClienteService = function ($http) {
    this.Listar = function () {
        return $http.get("/Cliente/Listar");
    }
    this.Obter = function (Cpf) {
        return $http.get("/Cliente/Obter?Cpf=" + Cpf);
    }
    this.Atualizar = function (cliente) {
        var response = $http({
            method: "post",
            url: "/Cliente/Atualizar",
            data: JSON.stringify(cliente),
            dataType: "json"
        });
        return response;
    }
    this.Adicionar = function (cliente) {
        var response = $http({
            method: "post",
            url: "/Cliente/Adicionar",
            data: JSON.stringify(cliente),
            dataType: "json"
        });
        return response;
    }

    this.Apagar = function (cliente) {
        var response = $http({
            method: "post",
            url: "/Cliente/Apagar",
            data: JSON.stringify(cliente),
            dataType: "json"
        });
        return response;
    }
}
ClienteService.$inject = ['$http'];
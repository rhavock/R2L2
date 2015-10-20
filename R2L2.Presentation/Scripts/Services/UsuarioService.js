var UsuarioService = function ($http) {
    this.Listar = function () {
        return $http.get("/Usuario/Listar");
    }

    this.Obter = function (Login) {
        return $http.get("/Usuario/Obter?Login=" + Login);
    }
    this.Atualizar = function (usuario) {
        var response = $http({
            method: "post",
            url: "/Usuario/Atualizar",
            data: JSON.stringify(usuario),
            dataType: "json"
        });
        return response;
    }
    this.Adicionar = function (usuario) {
        var response = $http({
            method: "post",
            url: "/Usuario/Adicionar",
            data: JSON.stringify(usuario),
            dataType: "json"
        });
        return response;
    }

    this.Apagar = function (usuario) {
        var response = $http({
            method: "post",
            url: "/Usuario/Apagar",
            data: JSON.stringify(usuario),
            dataType: "json"
        });
        return response;
    }
}
UsuarioService.$inject = ['$http'];
var ClienteService = function ($http) {
    this.Listar = function () {
        return $http.get("/Cliente/Listar");
    }
}
ClienteService.$inject = ['$http'];
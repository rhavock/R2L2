var LoginController = function ($scope, $routeParams) {
    $scope.loginForm = {
        emailAdress: '',
        password: '',
        rememberMe: false,
        returnUrl: $routeParams.returnUrl
    };

    $scope.login = function () {

    }
}
LoginController.$inject = ['$scope', '$routeParams'];
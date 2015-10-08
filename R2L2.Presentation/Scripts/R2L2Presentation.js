var R2L2Presentation = angular.module('R2L2Presentation', []);
R2L2Presentation.controller('ProdutoController', ProdutoController);

R2L2Presentation.service("ProdutoService", ProdutoService);

//var configFunction = function ($routeProvider) {
//    $routeProvider
//        .when('/Produto', {
//            templateUrl: '/Produto/Index',
//            controller: ProdutoController
//        })
//        .when('/Home', {
//            templateUrl: '/Home/Index'
//        });
//}
//configFunction.$inject = ['$routeProvider'];
//R2L2Presentation.config(configFunction);

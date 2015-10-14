var R2L2Presentation = angular.module('R2L2Presentation', []);
R2L2Presentation.controller('ProdutoController', ProdutoController);
R2L2Presentation.controller('ClienteController', ClienteController);
R2L2Presentation.controller('PedidoController', PedidoController);

R2L2Presentation.service("ProdutoService", ProdutoService);
R2L2Presentation.service('ClienteService', ClienteService);
R2L2Presentation.service('PedidoService', PedidoService);
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

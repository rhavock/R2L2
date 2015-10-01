var R2L2Presentation = angular.module('R2L2Presentation', ['ngRoute']);

R2L2Presentation.controller('HomeController', HomeController);
R2L2Presentation.controller('LoginController', LoginController);

R2L2Presentation.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);

var configFunction = function ($routeProvider,$httpProvider) {
	$routeProvider
		.when('/routeOne', {
			templateUrl: 'routesDemo/one'
		})
		.when('/routeTwo/:donuts', {
			templateUrl: function (params) { return 'routesDemo/two?donuts=' + params.donuts; }
		})
		.when('/routeThree', {
			templateUrl: 'routesDemo/three'
		})
		.when('/Login', {
			templateUrl: '/Account/Login',
			controller: LoginController
		});

	$httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$routeProvider', '$httpProvider'];

R2L2Presentation.config(configFunction);
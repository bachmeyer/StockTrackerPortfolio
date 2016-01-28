namespace StockTrackerFourLayer {
    
    angular.module('StockTrackerFourLayer', ['ngRoute']);

    angular.module('StockTrackerFourLayer').factory('authInterceptor',
        ($q: ng.IQService, $window: ng.IWindowService, $location: ng.ILocationService) => {
            return {
                request: (config) => {
                    config.headers = config.headers || {};
                    let token = $window.localStorage.getItem('token');
                    if (token) {
                        config.headers.Authorization = `Bearer ${token}`;
                    }
                    return config;
                },
                responseError: (response) => {
                    if (response.status === 401) {
                        $location.path('/login');
                    }
                    return $q.reject(response);
                }
            };
        });

    angular.module('StockTrackerFourLayer')
        .config(function ($routeProvider: ng.route.IRouteProvider, $httpProvider: ng.IHttpProvider) {

            $httpProvider.interceptors.push('authInterceptor');

            $routeProvider.when('/', { template: 'Hello World!' });

            $routeProvider.when('/login', {
                templateUrl: '/Presentation/ngApp/views/login.html',
                controller: StockTrackerFourLayer.Controllers.AuthController,
                controllerAs: 'controller'
            });
            $routeProvider.when('/register', {
                templateUrl: '/Presentation/ngApp/views/register.html',
                controller: StockTrackerFourLayer.Controllers.AuthController,
                controllerAs: 'controller'
            });
            $routeProvider.when('/research', {
                templateUrl: '/Presentation/ngApp/views/research.html',
                controller: StockTrackerFourLayer.Controllers.ResearchController,
                controllerAs: 'controller'
            });
            $routeProvider.when('/ticker/:ticker', {
                templateUrl: '/Presentation/ngApp/views/stockDetails.html',
                controller: StockTrackerFourLayer.Controllers.StockDetailsController,
                controllerAs: 'controller'
            });
        });
}
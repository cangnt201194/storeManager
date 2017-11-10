/// <reference path="I:\SoureCode\Git\StoreManager.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    //app chinhs include cac module con.moi module con khai bao ben trong products.module
    angular.module('storeManager',
        ['storeManager.products',
         'storeManager.common',
         'storeManager.product_categories',
         'storeManager.application_groups',
         'storeManager.application_roles',
         'storeManager.application_users'
        ]).config(config)
          .config(configAuthentication)
          .config(configError);

    configError.$inject = ['$qProvider'];
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    configAuthentication.$inject = ['$httpProvider'];
    function configError($qProvider) {
        $qProvider.errorOnUnhandledRejections(false);
    }
   
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/views/baseView.html',
                abstract: true
            })
            .state('login', {
                url: "/login",
                templateUrl: "/app/components/login/loginView.html",
                controller: "loginController"
            })
            .state('home', {
                url: "/admin",
                parent: 'base',
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
            });
        $urlRouterProvider.otherwise('/login');
    }

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
        
            return {
          
                request: function (config) {
                
                    return config;
                },
                requestError: function (rejection) {
                
                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                
                    return response;
                },
                responseError: function (rejection) {
                
                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();
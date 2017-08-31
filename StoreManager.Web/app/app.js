/// <reference path="I:\SoureCode\Git\StoreManager.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    //app chinhs include cac module con.moi module con khai bao ben trong products.module
    angular.module('storeManager',
        ['storeManager.products',
         'storeManager.common',
         'storeManager.product_categories'
        ]).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('base', {
            url: '', templateUrl: '/app/shared/views/baseView.html',
            abstract: true
        }).state('login', {
            url: "/login",
            templateUrl: "/app/components/login/loginView.html",
            controller: "loginController"
        }).state('home', {
            url: "/admin",
            parent:'base',
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/login');
    }
})();
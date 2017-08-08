﻿/// <reference path="I:\SoureCode\Git\StoreManager.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('storeManager.products', ['storeManager.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: "/products",
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListViewController"
        }).state('product_add', {
            url: "/product_add",
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddViewController"
        });
    }
})();
﻿/// <reference path="I:\SoureCode\Git\StoreManager.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiService','notificationService'];
    function productCategoryListController($scope, apiService, notificationService) {
        $scope.productCategories = [];
        $scope.getProductcategories = getProductCategories;
        $scope.pageCount = 0;
        $scope.page = 0;
        $scope.keyword = "";
        $scope.search = search;
        function search()
        {
            getProductCategories();
        }
        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 4,
                   keyword:$scope.keyword
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount==0) {
                    notificationService.displayWarning("Không có bản ghi nào được tìm thấy!");
                }
                    $scope.productCategories = result.data.Items;
                    $scope.page = result.data.Page;
                    $scope.pagesCount = result.data.TotalPages;
                    $scope.totalCount = result.data.TotalCount;           
            }, function () {
                console.log('Load product category failed')
            });         
        }

        $scope.getProductcategories();      
    }
})(angular.module('storeManager.product_categories'));
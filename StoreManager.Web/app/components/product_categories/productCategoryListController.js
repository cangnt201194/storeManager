/// <reference path="I:\SoureCode\Git\StoreManager.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiService'];
    function productCategoryListController($scope, apiService) {
        $scope.productcategories = [];
        $scope.getProductcategories = getProductCatefories;

        function getProductCatefories() {
            apiService.get('/api/productcategory/getall', null, function (result) {
                $scope.productcategories = result.data;
            }, function () {
                console.log('Load product category failed')
            });         
        }
        $scope.getProductcategories();
    }
})(angular.module('storeManager.product_categories'));
/// <reference path="I:\SoureCode\Git\StoreManager.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiService'];
    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];
        $scope.getProductcategories = getProductCategories;
        $scope.pageCount = 0;
        $scope.page = 0;

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize:2
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
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
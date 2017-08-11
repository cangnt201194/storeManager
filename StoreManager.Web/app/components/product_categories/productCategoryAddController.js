﻿/// <reference path="I:\SoureCode\Git\StoreManager.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService'];

    function productCategoryAddController($scope, apiService, notificationService, $state, commonService) {
        $scope.productCategory={
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.parentCategories = [];

        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        };
        $scope.AddProductCategory = AddProductCategory;
        function AddProductCategory() {
            apiService.post("api/productcategory/create", $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + " đã được thêm mới.");
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError("Thêm mới không thành công.");
            });

        };
        function loadParentCategories() {
            apiService.get("api/productcategory/getallparents", null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('cannot get list parent.');
            });
        };
        loadParentCategories();
    }

})(angular.module('storeManager.product_categories'));
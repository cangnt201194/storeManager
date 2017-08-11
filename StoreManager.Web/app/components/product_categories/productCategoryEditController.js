/// <reference path="I:\SoureCode\Git\StoreManager.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state','$stateParams','commonService'];

    function productCategoryEditController($scope, apiService, notificationService, $state, $stateParams,commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.parentCategories = [];
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        };

        $scope.UpdateProductCategory = UpdateProductCategory;
        function UpdateProductCategory() {
            apiService.put("api/productcategory/update", $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + " đã được cập nhật.");
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError("Cập nhật không thành công.");
            });

        };
        function loadProductCategoryDetail() {
            apiService.get('api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error)
            {
                notificationService.displayError(error.data);
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
        loadProductCategoryDetail();
    }

})(angular.module('storeManager.product_categories'));
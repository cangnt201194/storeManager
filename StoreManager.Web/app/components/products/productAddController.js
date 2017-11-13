/// <reference path="I:\SoureCode\Git\StoreManager.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService'];

    function productAddController($scope, apiService, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date(dateString),
            Status: true,
        }
        $scope.loadProductCategories = [];
        $scope.moreImages = [];
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px',
            uiColor: '#3C8DBC'
        }

        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        };
        $scope.AddProduct = AddProduct;
        function AddProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.post("api/product/create", $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + " đã được thêm mới.");
                $state.go('products');
            }, function (error) {
                notificationService.displayError("Thêm mới không thành công.");
            });

        };
        function loadProductCategories() {
            apiService.get("api/productcategory/getallparents", null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('cannot get list parent.');
            });
        };
        loadProductCategories();

        $scope.ChoosemoreImages = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }
    }

})(angular.module('storeManager.products'));
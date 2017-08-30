/// <reference path="I:\SoureCode\Git\StoreManager.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService', '$stateParams'];

    function productEditController($scope, apiService, notificationService, $state, commonService, $stateParams) {
        $scope.product = {
           
        }
        $scope.loadProductCategories = [];
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px',
            uiColor: '#3C8DBC'
        }

        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        };
        $scope.UpdateProduct = UpdateProduct;
        function UpdateProduct() {
            $scope.product.UpdatedDate = new Date;
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.put("api/product/update", $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + " đã được cập nhật.");
                $state.go('products');
            }, function (error) {
                notificationService.displayError("Cập nhật không thành công.");
            });

        };
        function loadProductDetail() {
            apiService.get("api/product/getbyid/" + $stateParams.id,null, function (result) {
                $scope.product = result.data;
                $scope.moreImages = JSON.parse($scope.product.MoreImages);
            }, function (error) {
                notificationService.displayError("Không tìm thấy sản phẩm này");
            });
        }


        $scope.ChoosemoreImages = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }
  

        function loadProductCategories() {
            apiService.get("api/productcategory/getallparents", null, function (result) {
                $scope.productCategories = result.data;
        
            }, function () {
                console.log('cannot get list parent.');
            });
        };
        

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }
        loadProductCategories();
        loadProductDetail();
    }

})(angular.module('storeManager.products'));
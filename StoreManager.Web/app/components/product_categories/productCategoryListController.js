/// <reference path="I:\SoureCode\Git\StoreManager.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.getProductcategories = getProductCategories;
        $scope.pageCount = 0;
        $scope.page = 0;
        $scope.keyword = "";
        $scope.search = search;
        $scope.deleteProductCategory = deleteProductCategory;
        $scope.selectAll = selectAll;
        $scope.isAll = false;
        $scope.deleteMulti = deleteMulti;
        function deleteMulti() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config={
                params:{
                    checkedProductCategories: JSON.stringify(listId)
                }
            }
            apiService.del('api/productcategory/deletemulti', config, function (result) {
                notificationService.displaySuccess("Xóa thành công " + result.data + ' bản ghi.');
                search();
            }, function (error) {
                notificationService.displayError("Xóa không thành công");
                search();
            });
        }

        function selectAll() {
            if ($scope.isAll===false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        $scope.$watch("productCategories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled','disabled');
            }
        }, true);

        function deleteProductCategory(id) {
            $ngBootbox.confirm("Bạn có chắc muốn xóa?").then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("api/productcategory/delete", config, function () {
                    notificationService.displaySuccess("Xóa không thành công.");
                    search();
                }, function () {
                    notificationService.displayError("Xóa không thành công.");
                })
            });
        }

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
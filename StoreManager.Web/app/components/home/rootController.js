(function (app) {
    app.controller('rootController', rootController)
    rootController.inject = ['$scope', 'authData', '$state', 'authenticationService', 'loginService'];
    function rootController($scope, authData, $state, authenticationService, loginService) {
        $scope.logout = function () {
            loginService.logOut();
            $state.go('login');
        }
        $scope.authentication = authData.authenticationData;
    }
})(angular.module('storeManager'));
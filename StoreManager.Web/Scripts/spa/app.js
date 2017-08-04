/// <reference path="../plugins/angular/angular.js" />
var myApp = angular.module("myModule", []);
//cach 1 khai bao
myApp.controller("myController", myController);
myApp.controller("myController1", myController1);
myApp.controller("schoolController", schoolController);

myController.$inject = ['$scope', '$rootScope'];
//declare scope long nhau
function schoolController($scope, $rootScope) {
    $scope.message = "test from schoolController.";
}
function myController($scope)
{
     $scope.message = "This is my message from Controller";
}
function myController1($scope, $rootScope) {
   // $scope.message = "This is my message from Controller1";
}

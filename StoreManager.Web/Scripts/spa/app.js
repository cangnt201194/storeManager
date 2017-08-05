
/// <reference path="../plugins/angular/angular.js" />
var myApp = angular.module("myModule", []);
//cach 1 khai bao
myApp.controller("myController", myController);
myApp.directive("storeManagerDirective", storeManagerDirective);
myApp.service('Validator', Validator);

myApp.controller("myController", myController);
myController.$inject = ['$scope', 'Validator'];
//declare scope long nhau
function myController($scope, Validator)
{
    $scope.number = 1;
   // $scope.ten = prompt("mời bạn nhập số:");
    // Validator.checkNumber($scope.ten);
    $scope.checkNumber= function ()
    {
        $scope.message = Validator.checkNumber($scope.number);
    }
   
}
//tạo service
function Validator($window) {
    return {
        checkNumber: checkNumber
    }
    function checkNumber(input) {
        if(input%2==0)
        {
            return 'this is even';
        } else {
            return 'this is odd';
        }
    }
}
//khai bao custome Directive
function storeManagerDirective(){
    return {
        restrict:"A",
        templateUrl: "/Scripts/spa/storeManagerDirective.html"
    }
}

angular.module('RomanSPA.Controllers', [])
       .controller('GenericController', ['$scope', function ($scope) {
           $scope.title = 'Welcome to RomanSPA, the AngularJS edition';
           $scope.body = 'This content has been loaded from GenericController';
       }]);

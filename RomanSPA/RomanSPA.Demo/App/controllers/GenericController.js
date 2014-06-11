angular.module('RomanSPA')
       .controller('GenericController', ['$scope', '$route', function ($scope, $route) {
           
           $scope.pageUrl = '/';

           if ($route.current !== undefined) { $scope.pageUrl = $route.current.templateUrl; }

           // Retrieve our view - be it from server side, or custom template location
            $.get({
                url: $scope.pageUrl.toString(),
                beforeSend: function(xhr) { xhr.setRequestHeader('X-RomanViewRequest', 'true'); },
                success: applyView
            });

            // Retrieve our model using the modelfactory for our current URL path
            $.get({
                url: $scope.pageUrl.toString(),
                beforeSend: function (xhr) { xhr.setRequestHeader('X-RomanModelRequest', 'true'); },
                success: applyModel
            });

            function applyView(data) {
                $scope.$apply(function () { angular.element('body').html($compile(data)($scope)); });
            }

            function applyModel(data) { $scope.model = data; }
       }]);
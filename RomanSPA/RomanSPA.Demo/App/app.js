// angular.module('RomanSPA.Controllers', []);

angular.module('RomanSPA', ['ngRoute'])
        .config(['$routeProvider', function ($routeProvider, $locationProvider) {
            $.ajax({
                url: '/api/RouteApi/AllRoutes',
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        $routeProvider.when(data[i].RoutePattern, {
                            controller: data[i].controller,
                            templateUrl: data[i].templateUrl
                        });
                    }
                    $routeProvider.otherwise({ redirectTo: '/' });
                },
                fail: function (data) {

                }
            });
        }])
        .value('breeze', window.breeze);
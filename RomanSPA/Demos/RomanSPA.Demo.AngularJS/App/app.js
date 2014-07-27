angular.module('RomanSPA', ['ngRoute'])
        .config(['$routeProvider', '$locationProvider', '$httpProvider', function
                 ($routeProvider, $locationProvider, $httpProvider) {

            $locationProvider.html5Mode(true);

            $httpProvider.defaults.headers.get = { 'X-RomanViewRequest': 'true' };

            var populateRouteTable = function (data) {
                for (var r = 0; r < data.length; r++) {
                    $routeProvider.when(data[r].RoutePattern, data[r].controller, data[r].templatePath)
                }
            }

            var getRoutes = function (routeApi) {
                var defer = $q.defer();
                $.ajax({
                    url: routeApi,
                    success: function (data) { defer.resolve(data); },
                    fail: function (data) { defer.reject(data); }
                });
                return defer.promise;
            }

            var getRouteTemplate = function ($routeProvider, pattern, controller, templUrl) {
                $httpProvider.get(templUrl)
                     .success(function (data) {
                        setRoute($routeProvider, pattern, controller, data);
                        $routeProvider.otherwise({ redirectTo: '/', caseInsensitiveMatch: true });
                     });
            }

            var routes = getRoutes('/api/Angular/Routes');
            routes.then(populateRouteTable);
        }])
    .run(['$route', function ($route) {
        if ($route.routes.length > 0) $route.reload();
    }])
    .value('breeze', window.breeze);
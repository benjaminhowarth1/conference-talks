// angular.module('RomanSPA.Controllers', []);

angular.module('RomanSPA', ['ngRoute'])
        .config(['$routeProvider', '$locationProvider', function 
                 ($routeProvider, $locationProvider) {

            $locationProvider.html5Mode(true);

            $.ajax({
                url: '/api/RouteApi/ServerRoutes',
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        getRouteTemplate($routeProvider, data[i].RoutePattern, data[i].controller, data[i].templateUrl);
                    }
                },
                async: false
            });

            function addHeaders(xhr) { xhr.setRequestHeader('X-RomanViewRequest', 'true'); }

            function getRouteTemplate($routeProvider, pattern, controller, templUrl) {
                $.ajax({ url: templUrl, beforeSend: addHeaders, async: false })
                 .done(function (data) {
                     setRoute($routeProvider, pattern, controller, data);
                     $routeProvider.otherwise({ redirectTo: '/', caseInsensitiveMatch: true });
                 });
            }

            function setRoute($routeProvider, pattern, controller, template) {
                $routeProvider.when(pattern, { controller: controller, template: template, caseInsensitiveMatch: true });
            }
        }])
    .run(['$route', function ($route) {
        if ($route.routes.length > 0) $route.reload();
    }])
    .value('breeze', window.breeze);
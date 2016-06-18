var app = angular.module("watchdogApp", [
    "ngRoute",
    "LocalStorageModule"
]);

app.config([
    "$routeProvider",
    "$locationProvider",
    function ($routeProvider, $locationProvider) {
        $routeProvider

            .when("/Login", {
                templateUrl: "Templates/Login.html",
                controller: "loginCtrl"
            });

        $locationProvider.html5Mode(true);
    }
]);
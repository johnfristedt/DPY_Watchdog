var app = angular.module("dpyApp", [
    "ngRoute",
    "LocalStorageModule"
]);

app.config([
    "$routeProvider",
    "$httpProvider",
    "$locationProvider",
    function ($routeProvider, $httpProvider, $locationProvider) {
        $routeProvider

            .when("/", {
                templateUrl: "Templates/Home.html",
                controller: "homeCtrl"
            })

            .when("/:pageName", {
                templateUrl: "Templates/Page.html",
                controller: "pageCtrl",
                caseInsensitiveMatch: true
            })

            .when("/Contact", {
                templateUrl: "Templates/Contact.html",
                caseInsensitiveMatch: true
            });

        $locationProvider.html5Mode(true);
    }
]);
/// <reference path="../Apps/dpyApp.js" />
/// <reference path="../angular-route.js" />
/// <reference path="../angular.js" />

app.factory("authInterceptorService", [
    "$q",
    "$location",
    "$rootScope",
    "localStorageService",
    "authentication",
    function ($q, $location, $rootScope, localStorageService, authentication) {
        var authInterceptorServiceFactory = {};

        $rootScope.$on("$routeChangeStart", function (event, next) {
            console.log("test");
            var authorized;

            if (next.access !== undefined) {
                authorized = authentication.authorize(next.access.loginRequired,
                                                      next.access.requiredRoles,
                                                      next.access.roleCheckType);
                
                console.log(authorized);
                if (authorized === authentication.results.loginRequired) {
                    document.location.replace("/Login");
                }

                else if (authorized === authentication.results.notAuthorized) {
                    document.location.replace("/Login");
                }
            }
        });

        var _request = function (config) {
            config.headers = config.headers || {};

            var authData = localStorageService.get("authorizationData");
            if (authData) {
                config.headers.Authorization = "Bearer " + authData.token;
            }

            return config;
        };

        var _responseError = function (rejection) {
            if (rejection.status === 401) {
                document.location.replace("/Login");
            }
            else {
                //$location.path("/");
            }

            //return $q.reject(rejection);
        };

        authInterceptorServiceFactory.request = _request;
        authInterceptorServiceFactory.responseError = _responseError;

        return authInterceptorServiceFactory;
    }
]);
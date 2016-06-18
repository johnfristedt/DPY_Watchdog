/// <reference path="../Apps/dpyApp.js" />
/// <reference path="../angular-local-storage.js" />
/// <reference path="../angular-route.js" />
/// <reference path="../angular.js" />


app.service("authService", [
    "$http",
    "$q",
    "$location",
    "localStorageService",
    function ($http, $q, $location, localStorageService) {
        var authServiceFactory = {};

        var authentication = {
            isAuth: false,
            userName: ""
        };

        var saveRegistration = function (registration) {
            logOut();

            return $http.post(server + "api/account/register", registration)
                .then(function (response) {
                    return response;
                });
        };



        var login = function (loginData, redirectPath) {
            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

            var deferred = $q.defer();

            $http.post(oauth + "token", data, {
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded"
                }
            }).success(function (response) {
                console.log(response);
                localStorageService.set("authorizationData", { token: response.access_token, userName: loginData.userName });

                authentication.isAuth = true;
                authentication.userName = loginData.userName;

                deferred.resolve(response);

                if (redirectPath == undefined)
                    document.location.replace("/Account");

            }).error(function (err, status) {
                console.log(status);
                logOut();
                deferred.reject(err);
            });

            return deferred.promise;
        };

        var logOut = function () {
            localStorageService.remove("authorizationData");

            authentication.isAuth = false;
            authentication.userName = "";
        };

        var fillAuthData = function () {
            var authData = localStorageService.get("authorizationData");
            if (authData) {
                authentication.isAuth = true;
                authentication.userName = authData.userName;
            }
        };

        authServiceFactory.saveRegistration = saveRegistration;
        authServiceFactory.login = login;
        authServiceFactory.logOut = logOut;
        authServiceFactory.fillAuthData = fillAuthData;
        authServiceFactory.authentication = authentication;

        return authServiceFactory;
    }]);
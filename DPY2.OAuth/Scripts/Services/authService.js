/// <reference path="../Apps/dpyApp.js" />
/// <reference path="../angular-local-storage.js" />
/// <reference path="../angular-route.js" />
/// <reference path="../angular.js" />


app.service("authService", [
    "$http",
    "$location",
    "localStorageService",
    function ($http, $location, localStorageService) {
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
            console.log(loginData);
            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

            $http.post(server + "token", data, {
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded"
                }
            }).then(
            function (response) {
                console.log(response.data);
                var redirectUri = redirectPath + "?code=" + response.data.access_token + "&username=" + loginData.userName;
                document.location.replace(redirectUri);

            },
            function (response) {
                console.log(response);
                logOut();
            });
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
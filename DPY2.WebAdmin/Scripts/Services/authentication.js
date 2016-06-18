/// <reference path="../Apps/dpyApp.js" />
/// <reference path="../angular-route.js" />
/// <reference path="../angular.js" />

app.factory("authentication", [
    "localStorageService",
    function (localStorageService) {
        var roleCheckTypes = {
            atLeastOne: "AtLeastOne",
            combination: "Combination"
        };

        var results = {
            authorized: "Authorized",
            notAuthorized: "NotAuthorized",
            loginRequired: "LoginRequired"
        };

        var authorize = function (loginRequired, requiredRoles, roleCheckType) {
            var authData = localStorageService.get("authorizationData");
            var result = results.notAuthorized;
            var user = authData != null ? authData.userName : undefined;
            var loweredRoles = [];
            var hasRole = true;
            var role;

            roleCheckType = roleCheckType || roleCheckTypes.atLeastOne;

            if (loginRequired === false) {
                result = results.authorized;
            }

            if (loginRequired === true && (authData === undefined || user === undefined)) {
                result = results.loginRequired;
            }

            // Login without roles
            else if ((loginRequired === true && user !== undefined) &&
                    (requiredRoles === undefined || requiredRoles.length === 0)) {
                result = results.authorized;
            }

            // Login with roles
            else if (requiredRoles) {
                loweredRoles = [];
                loweredRoles.push("admin"); // TODO: Proper roles

                for (var i = 0; i < requiredRoles.length; i++) {
                    role = requiredRoles[i].toLowerCase();

                    if (roleCheckType === roleCheckTypes.atLeastOne) {
                        hasRole = loweredRoles.indexOf(role) > -1;
                    }

                    // Break if we have one required role and only need one

                    if (hasRole) {
                        result = results.authorized;
                        break;
                    }
                }
            }

            return result;
        };

        return {
            roleCheckTypes: roleCheckTypes,
            results: results,
            authorize: authorize
        }
    }
]);
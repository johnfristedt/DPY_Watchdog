var caseInsensitiveRouting = true;

var app = angular.module("accountApp", [
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
                controller: "homeCtrl",
                caseInsensitiveMatch: caseInsensitiveRouting,
                access: {
                    loginRequired: true
                }
            })

            .when("/Pages", {
                templateUrl: "Templates/Pages/List.html",
                controller: "pagesListCtrl",
                caseInsensitiveMatch: caseInsensitiveRouting,
                access: {
                    loginRequired: true
                }
            })

            .when("/Pages/New", {
                templateUrl: "Templates/Pages/New.html",
                controller: "createPageCtrl",
                caseInsensitiveMatch: caseInsensitiveRouting,
                access: {
                    loginRequired: true
                }
            })

            .when("/Pages/Edit/:pageName", {
                templateUrl: "Templates/Pages/Edit.html",
                controller: "editPageCtrl",
                caseInsensitiveMatch: caseInsensitiveRouting,
                access: {
                    loginRequired: true
                }
            })

            .when("/Skills", {
                templateUrl: "Templates/Skills/List.html",
                controller: "skillListCtrl",
                caseInsensitiveMatch: caseInsensitiveRouting,
                access: {
                    loginRequired: true
                }
            })

            .when("/Skills/New/:blockId", {
                templateUrl: "Templates/Skills/New.html",
                controller: "createSkillCtrl",
                caseInsensitiveMatch: caseInsensitiveRouting,
                access: {
                    loginRequired: true
                }
            })

            .when("/Skills/:id", {
                templateUrl: "Templates/Skills/Edit.html",
                controller: "editSkillCtrl",
                caseInsensitiveMatch: caseInsensitiveRouting,
                access: {
                    loginRequired: true
                }
            })

            .when("/Projects", {
                templateUrl: "Templates/Projects/List.html",
                controller: "projectListCtrl",
                caseInsensitiveMatch: caseInsensitiveRouting,
                access: {
                    loginRequired: true
                }
            })

            .when("/Projects/New/:blockId", {
                templateUrl: "Templates/Projects/New.html",
                controller: "createProjectCtrl",
                caseInsensitiveMatch: caseInsensitiveRouting,
                access: {
                    loginRequired: true
                }
            })

            .when("/Projects/:id", {
                templateUrl: "Templates/Projects/Edit.html",
                controller: "editProjectCtrl",
                caseInsensitiveMatch: caseInsensitiveRouting,
                access: {
                    loginRequired: true
                }
            })

            .when("/Login", {
                templateUrl: "Templates/Login.html",
                controller: "loginCtrl",
                caseInsensitiveMatch: caseInsensitiveRouting,
                access: {
                    loginRequired: false
                }
            })

            .when("/Authenticate", {
                templateUrl: "Templates/Authenticate.html",
                controller: "authCtrl",
                caseInsensitiveMatch: caseInsensitiveRouting,
                access: {
                    loginRequired: false
                }
            });

        $httpProvider.interceptors.push("authInterceptorService");
        $locationProvider.html5Mode(true);
    }
]);

app.run([
    "authService",
    function (authService) {
        authService.fillAuthData();
    }
]);
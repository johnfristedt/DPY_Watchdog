app.controller("loginCtrl", [
    "$scope",
    "$routeParams",
    "authService",
    function ($scope, $routeParams, authService) {
        $scope.userData = { userName: "", password: "" };

        $scope.login = function () {
            authService.login($scope.userData, $routeParams.redirecturi);
        }
    }
]);
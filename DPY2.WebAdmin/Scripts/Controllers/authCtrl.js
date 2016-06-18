app.controller("authCtrl", [
    "$scope",
    "$location",
    "$routeParams",
    "localStorageService",
    function ($scope, $location, $routeParams, localStorageService) {
        $scope.code = $routeParams.code;
        console.log($scope.code);
        localStorageService.set("authorizationData", { token: $routeParams.code, userName: $routeParams.username });
        document.location.replace("/");
    }
]);
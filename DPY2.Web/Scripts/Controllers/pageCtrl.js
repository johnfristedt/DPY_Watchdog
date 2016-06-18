app.controller("pageCtrl", [
    "$scope",
    "$http",
    "$routeParams",
    function ($scope, $http, $routeParams) {
        $scope.pageName = $routeParams.pageName;

        $http.get(api + "pages/" + $scope.pageName)
            .then(
                function (response) {
                    $scope.page = response.data;
                    console.log($scope.page);
                }
            );
    }
]);
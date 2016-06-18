app.controller("mainCtrl", [
    "$scope",
    "$http",
    function ($scope, $http) {
        $http.get(api + "pages/names")
            .then(
                function (response) {
                    $scope.pages = response.data;
                    console.log($scope.pages);
                }
            );
    }
]);
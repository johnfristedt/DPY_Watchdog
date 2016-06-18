app.controller("createPageCtrl", [
    "$scope",
    "$http",
    "$location",
    "$routeParams",
    function ($scope, $http, $location, $routeParams) {
        $scope.newPage = { name: "" };

        $scope.createPage = function () {
            $http.post(api + "pages", $scope.newPage)
                .then(
                    function (response) {
                        console.log(response);
                        $location.path("/Pages");
                    }
                )
        }
    }
]);
app.controller("editProjectCtrl", [
    "$scope",
    "$http",
    "$routeParams",
    "$location",
    function ($scope, $http, $routeParams, $location) {
        $scope.project = {};

        $scope.updateProject = function () {
            $http.put(api + "projects", $scope.project)
                .then(
                    function (response) {
                        console.log(response);
                        $location.path("/Projects");
                    }
                );
        };

        $http.get(api + "projects/" + $routeParams.id)
            .then(
                function (response) {
                    $scope.project = response.data;
                    console.log($scope.project);
                }
            );
    }
]);
app.controller("projectsListCtrl", [
    "$scope",
    "$http",
    function ($scope, $http) {
        $http.get(api + "projects")
            .then(
                function (response) {
                    $scope.projects = response.data;
                    console.log($scope.projects);
                }
            );
    }
]);
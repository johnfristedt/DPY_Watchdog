app.controller("projectListCtrl", [
    "$scope",
    "$http",
    "$location",
    function ($scope, $http, $location) {
        $scope.projects = [];

        $scope.newProject = function () {
            $location.path("/Projects/New");
        };

        $scope.editProject = function (id) {
            $location.path("/Projects/" + id);
        };

        $scope.deleteProject = function (id) {
            $http.delete(api + "projects/" + id)
                .then(
                    function () {
                        $scope.projects = $scope.projects.filter(function (project) {
                            return project.Id != id;
                        });
                    }
                );
        };

        $http.get(api + "projects")
            .then(
                function (response) {
                    $scope.projects = response.data;
                    console.log($scope.projects);
                }
            );
    }
]);
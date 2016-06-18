app.controller("skillsListCtrl", [
    "$scope",
    "$http",
    function ($scope, $http) {
        $http.get(api + "skills")
            .then(
                function (response) {
                    $scope.skills = response.data;
                }
            );
    }
]);
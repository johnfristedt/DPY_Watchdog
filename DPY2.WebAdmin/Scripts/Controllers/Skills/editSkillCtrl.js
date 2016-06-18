app.controller("editSkillCtrl", [
    "$scope",
    "$http",
    "$routeParams",
    "$location",
    function ($scope, $http, $routeParams, $location) {
        $scope.skill = {};

        $scope.updateSkill = function () {
            $http.put(api + "skills", $scope.skill)
                .then(
                    function (response) {
                        console.log(response);
                        $location.path("/Skills");
                    }
                );
        };

        $http.get(api + "skills/" + $routeParams.id)
            .then(
                function (response) {
                    $scope.skill = response.data;
                    console.log($scope.skill);
                }
            );
    }
]);
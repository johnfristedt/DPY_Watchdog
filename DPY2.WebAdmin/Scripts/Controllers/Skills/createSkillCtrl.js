app.controller("createSkillCtrl", [
    "$scope",
    "$http",
    "$location",
    "$routeParams",
    function ($scope, $http, $location, $routeParams) {
        $scope.newSkill = { name: "", description: "", blockId: $routeParams.blockId };

        $scope.createSkill = function () {
            $http.post(api + "skills", $scope.newSkill)
                .then(
                    function () {
                        $location.path("/Pages");
                    }
                );
        };

        console.log($scope.newSkill);
    }
]);
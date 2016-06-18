app.controller("skillListCtrl", [
    "$scope",
    "$http",
    "$location",
    function ($scope, $http, $location) {
        $scope.skills = [];

        $scope.newSkill = function () {
            $location.path("/Skills/New");
        };

        $scope.editSkill = function (id) {
            $location.path("/Skills/" + id);
        };

        $scope.deleteSkill = function (id) {
            $http.delete(api + "skills/" + id)
                .then(
                    function () {
                        $scope.skills = $scope.skills.filter(function (skill) {
                            return skill.id != id;
                        });
                    }
                );
        };

        $http.get(api + "skills")
            .then(
                function (response) {
                    $scope.skills = response.data;
                    console.log(response);
                }
            );
    }
]);
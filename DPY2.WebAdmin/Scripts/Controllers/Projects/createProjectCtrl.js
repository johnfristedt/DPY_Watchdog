app.controller("createProjectCtrl", [
    "$scope",
    "$http",
    "$location",
    "$routeParams",
    function ($scope, $http, $location, $routeParams) {
        $scope.newProject = { Name: "", Description: "", Image: "", blockId: $routeParams.blockId };

        $scope.createProject = function () {
            $http.post(api + "projects", $scope.newProject)
                .then(
                function (response) {
                    $location.path("/Projects")
                },
                function (response) {
                    console.log(response);
                });
        };

        var setNewImage = function (base64string) {
            $scope.newProject.Image = base64string;
        };

        $(document).on('change', '#file', function () {
            var preview = document.querySelector('#preview');
            var file = document.querySelector('#file').files[0];
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#preview').attr('src', e.target.result);
                setNewImage(e.target.result);
            };

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = '';
            }
        });

        console.log($scope.newProject);
    }
]);
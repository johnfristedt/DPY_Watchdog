app.controller("pagesListCtrl", [
    "$scope",
    "$http",
    "$location",
    function ($scope, $http, $location) {
        $scope.pages = [];

        $scope.editPage = function (pageName) {
            $location.path("/Pages/Edit/" + pageName);
        }

        $scope.deletePage = function (id) {
            $http.delete(api + "pages/" + id)
                .then(
                    function (response) {
                        console.log(response);
                        $scope.pages = $scope.pages.filter(function (page) {
                            return page.id != id;
                        });
                    }
                )
        }

        $http.get(api + "pages")
            .then(
                function (response) {
                    $scope.pages = response.data;
                    console.log($scope.pages);
                }
            );
    }
]);
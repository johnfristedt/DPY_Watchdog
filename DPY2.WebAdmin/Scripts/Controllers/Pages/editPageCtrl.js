app.controller("editPageCtrl", [
    "$scope",
    "$http",
    "$location",
    "$routeParams",
    function ($scope, $http, $location, $routeParams) {
        $scope.page = {};

        $scope.moveBlock = function (index, direction) {
            var moveTo = $scope.page.blocks[index + direction];
            var moveFrom = $scope.page.blocks[index];

            var newPageIndex = moveTo.pageIndex;
            var oldPageIndex = moveFrom.pageIndex;
            
            moveTo.pageIndex = oldPageIndex;
            moveFrom.pageIndex = newPageIndex;


            $scope.page.blocks[index + direction] = moveFrom;
            $scope.page.blocks[index] = moveTo;
        };

        $scope.createBlock = function () {
            $http.post(api + "blocks/" + $scope.page.id)
                .then(
                    function (response) {
                        console.log(response);
                        $scope.page.blocks.push(response.data);
                    }
                );
        };

        $scope.updatePage = function () {
            $http.put(api + "pages/" + $scope.page.id, $scope.page)
                .then(
                    function (response) {
                        console.log(response);
                        $location.path("/Pages");
                    }
                );
        };

        $scope.deleteBlock = function (id) {
            $http.delete(api + "blocks/" + id)
                .then(
                    function (response) {
                        $scope.page.blocks = $scope.page.blocks.filter(function (block) {
                            return block.id != id;
                        });
                    }
                );
        };

        $http.get(api + "pages/" + $routeParams.pageName)
            .then(
                function (response) {
                    $scope.page = response.data;
                    console.log($scope.page);
                }
            );
    }
]);
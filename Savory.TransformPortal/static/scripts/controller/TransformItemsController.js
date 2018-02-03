function TransformItemsController($scope, TransformService) {

    $scope.init = function () {

        TransformService.items().then(function (response) {
            $scope.transformList = response;

            $scope.loaded = true;
        })
    }

    $scope.init();
}
function TransformCreateController($scope, TransformService) {

    $scope.init = function () {

        //console.log('create');

    }

    $scope.init();

    $scope.confirmCreateTransform = function () {

        $scope.waiting = true;
        $scope.message = null;

        TransformService.create($scope.transform).then(function (response) {

            $scope.waiting = false;

            $scope.message = response.message;
        })
    }
}
function WelcomeController($scope) {

    $scope.init = function () {

        console.log('welcome');

        //UserService.profile().then(function (result) {
        //    if (result.statusCode == 1) {
        //        $scope.profile = result.item;
        //    }
        //});
    }
}
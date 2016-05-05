var splice = angular.module('spliceApp')
    .controller('loginController', ['$scope', 'loginService', '$location', function ($scope, loginService, $location) {

    $scope.loginModel = {
        UserName: "",
        Password:""
    }
    $scope.Login = function () {
        loginService.login($scope.loginModel)
           .then(function (response) {
               $location.path('dashboard');

           })


    }


}])

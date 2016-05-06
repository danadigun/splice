var splice = angular.module('spliceApp')
    .controller('loginController', ['$scope', 'loginService', '$location', '$rootScope', function ($scope, loginService, $location, $rootScope) {
        $rootScope.hidebar = false;
        $scope.loginModel = {
            UserName: "",
            Password: ""
        }
        $scope.Login = function () {
            loginService.login($scope.loginModel)
               .then(function (response) {
                   $rootScope.hidebar = true;
                   $location.path('dashboard');

               })


        }


}])

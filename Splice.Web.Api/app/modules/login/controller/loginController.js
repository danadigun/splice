var splice = angular.module('spliceApp')
    .controller('loginController', ['$scope', 'loginService', '$location', '$rootScope', 'growl', function ($scope, loginService, $location, $rootScope, growl) {
        $rootScope.hidebar = false;
        $scope.loginModel = {
            UserName: "",
            Password: ""
        }
        $scope.Login = function () {
            if ($.fn.validateForceFully($("#loginForm")) == true) {
                loginService.login($scope.loginModel)
                   .then(function (response) {
                       if (response.data.Success) {
                           $rootScope.hidebar = true;
                           $location.path('dashboard');
                       }
                       else {
                           $location.path('login');
                           growl.error('Invalid UserName or Password.')
                       }
                   })


            }
        }


    }])

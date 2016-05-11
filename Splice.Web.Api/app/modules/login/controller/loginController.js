var splice = angular.module('spliceApp')
    .controller('loginController', ['$scope', 'loginService', '$location', '$rootScope', 'growl', '$cookieStore', function ($scope, loginService, $location, $rootScope, growl, $cookieStore) {
        $rootScope.hidebar = false;
        $scope.loginText = "Login";
        $scope.loginModel = {
            Email: "",
            Password: ""
        }
        $scope.Login = function () {
            $scope.loginText = "Logging...";
            $scope.loginDisable = true;
            //if ($.fn.validateForceFully($("#loginForm")) == true) {
                loginService.login($scope.loginModel)
                   .then(function (response) {
                       if (response.data.Success) {
                           $cookieStore.put('globals', response.data.Token);
                           $rootScope.globals = response.data.Token;
                           $rootScope.hidebar = true;
                           $location.path('dashboard');
                       }
                       else {
                           $scope.loginText = "Login";
                           $scope.loginDisable = false;
                           $location.path('login');
                           growl.error('Invalid UserName or Password.')
                       }
                   })


            }
       // }


    }])

var splice = angular.module('spliceApp')
    .controller('retailerController', ['$scope', 'retailerService', '$location', 'growl', function ($scope, retailerService, $location, growl) {
        $scope.Error = false;
        $scope.signUpText = "Register Now";
        $scope.UserModel = {

            FirstName: "",
            LastName: "",
            Email: "",
            Password: "",
            Address: "",
            Country: "",
            Phone: "",
            StoreName: "",
            RetailURL: "",
            Type: "",
            ConfirmPassword: ""
        }

        $scope.CreateUser = function () {
            $scope.signUpText = "Submitting...";
            $scope.signupDisable = true;
          
                retailerService.createUser($scope.UserModel)
                           .then(function (response) {
                               if (response.data.Success) {
                                 growl.success('Welcome! ' + $scope.UserModel.FirstName)
                                   $location.path('dashboard');
                               }
                               else {
                                   $scope.signUpText = "Register Now";
                                   $scope.signupDisable = false;
                                   $scope.Error = response.data.Message;
                                   //growl.error('Unable to CreateUser,Please try again.')
                               }
                           })


            }




        $scope.Comparepassword = function () {
            if ($scope.UserModel.Password !== $scope.UserModel.ConfirmPassword) {
                $scope.ComparepasswordStatus = true;
            }
            else {
                $scope.ComparepasswordStatus = false;
            }
        };

        $scope.ComparepasswordChanged = function () {
            $scope.ComparepasswordStatus = false;
        }

        $scope.Cancel = function () {
            $location.path('login');
        };

    }])

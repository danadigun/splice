var splice = angular.module('spliceApp')
    .controller('retailerController', ['$scope', 'retailerService', '$location', 'growl', function ($scope, retailerService, $location, growl) {


        $scope.UserModel = {
            UserName: "",
            EmailAddre: "",
            Password: "",
            Name: "",
            Position: "",
            StoreName: "",
            StreetAddr: "",
            City: "",
            Country: "",
            Phone: "",
            Fax: "",
            RetailURL: "",
            Type: "",
            ConfirmPassword:""
        }

        $scope.CreateUser = function () {
            if ($.fn.validateForceFully($("#signUpId")) == true) {
                retailerService.createUser($scope.UserModel)
                           .then(function (response) {
                               if (response) {
                                   growl.success('User Created Successfully')
                                   $location.path('login');
                               }
                               else {
                                   growl.error('Unable to CreateUser,Please try again.')
                               }
                           })


            }
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

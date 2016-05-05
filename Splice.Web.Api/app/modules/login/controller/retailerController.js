var splice = angular.module('spliceApp')
    .controller('retailerController', ['$scope', 'retailerService', function ($scope, retailerService) {


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
            Type: ""
        }

        $scope.CreateUser = function () {
            retailerService.createUser($scope.UserModel)
                       .then(function (response) {

                       })


        }


    }])

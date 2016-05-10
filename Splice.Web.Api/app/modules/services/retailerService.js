var splice = angular.module('spliceApp').service('retailerService', ['$http', 'baseUrl', function ($http, baseUrl) {
    var retailerService = {}

    retailerService.createUser = function (userModel) {
        return $http.post(baseUrl + '/api/Retailer/AddUser', userModel);
        };

    
    return retailerService;

}])
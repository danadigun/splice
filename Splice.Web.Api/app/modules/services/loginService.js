var splice = angular.module('spliceApp').service('loginService', ['$http', 'baseUrl', function ($http, baseUrl) {
    var loginService = {}

    loginService.login = function (loginModel) {
        return $http.post(baseUrl + '/api/Retailer/login', loginModel);
    };


    
    return loginService;

}])
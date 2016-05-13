var splice = angular.module('spliceApp').service('stockService', ['$http', 'baseUrl', function ($http, baseUrl) {
    var stockService = {}

    stockService.createStock = function (stockModel) {
        return $http.post(baseUrl + '/api/Stock/CreateStock', stockModel);
        };

    
    return stockService;

}])
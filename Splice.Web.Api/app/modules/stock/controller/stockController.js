var splice = angular.module('spliceApp')
.controller('stockController', ['$scope', 'stockService', function ($scope, stockService) {
    $scope.createStockText = "+ Create Stock";
    $scope.StockModel = {
        Name: "",
        Title: "",
        Description: "",
        MaxQuantity: "",
        AvailabilityDate: $scope.date,
        Status: ""
    }
    $scope. date = new Date(['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate']);


    $scope.CreateStock = function () {
        $scope.createStockText = "Submitting...";
        $scope.createStockDisable = true;
        //$scope.StockModel.AvailabilityDate = $scope.StockModel.AvailabilityDate + 1;
        stockService.createStock($scope.StockModel)
    .then(function (response) {

        $scope.createStockText = "+ Create Stock";
        $scope.createStockDisable = false;
    })
    }

}])
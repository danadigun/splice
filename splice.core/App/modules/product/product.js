var product = angular.module('splice.product', []);

product.controller('ProductController', function ($scope, $http) {

    $scope.DisplayManageProduct = function () {
        $('#modal-add-product').openModal();
    }

    $scope.saveProduct = function (product) {
        //TODO: Add new Product
    }

    $scope.removeProduct = function (id) {
        //TODO: Remove Product
    }

    $scope.updateProduct = function (product) {
        //TODO: Update Product
    }
});

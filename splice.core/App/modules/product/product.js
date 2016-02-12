var product = angular.module('splice.product', []);

product.config(function ($urlRouterProvider, $stateProvider) {
    $stateProvider.state('CreateStock',
        {
            views: {
                'index': {
                    templateUrl: '/App/modules/product/createStock.html'
                }

            },
            url: '/stock/create'
        }).state('AddProduct',
        {
            views: {
                'index': {
                    templateUrl: ''
                }

            },
            url: '/product/add'
        })
    .state('ViewStock',
        {
            views: {
                'index': {
                    templateUrl: ''
                }

            },
            url: '/stock/view'
        })
});

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

    $scope.addItemToStock = function (product) {
        //TODO: add item to stock
    }
});

product.controller('ManageStockController', function ($scope, $http, $state, $mdToast) {
    $scope.step = "Step 1: Create Stock";
    $scope.date = "";
    $('#add-items').hide();

    $scope.showCreateStock = function () {
        $('#modal-add-product').closeModal();
        $state.go('CreateStock');
    }
    $scope.createStock = function (stock) {
        $scope.step = "Step 2: Add Items to stock";
        $scope.date = moment($scope.stock.dateCreated).format("dddd, MMMM Do YYYY, h:mm:ss a");

        $('#add-items').fadeIn();
        $('#create-stock').hide();
        $mdToast.show(
           $mdToast.simple()
             .textContent('Stock has successfully been created')
             .position('top right')
             .hideDelay(3000)
        );
       
    }

    $scope.showViewStock = function () {

    }
});
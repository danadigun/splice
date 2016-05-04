product.controller('ViewStockController', function ($scope, $http, $state, $stateParams, $mdToast) {

    $scope.titleList = "Your Stock Listings";
    $scope.stock = {};
    $scope.isBusy = true;
    $scope.isAddingItem = false;
    $scope.showAddItem = function () {
        $scope.isAddingItem = true;
    }
    $scope.hideAddItem = function () {
        $scope.isAddingItem = false;
    }

    //show view existing stock
    $scope.showExistingStock = function () {
        $('#modal-add-product').closeModal();
        $state.go('ViewStock');
    }
    $http.get('/api/sales/stock').then(function (response) {
        $scope.stock = response.data;
        $scope.isBusy = false;
    })

    //format dateCreated
    $scope.formateDate = function (date) {
        return moment(date).format("dddd, MMMM Do YYYY, h:mm:ss a");
    }

    //Pagination
    $scope.currentPage = 0;
    $scope.pageSize = 7;
    $scope.numberOfPages = function () {
        return Math.ceil($scope.stock.items.length / $scope.pageSize);
    }

    //manage each stock
    $scope.stockId = $stateParams.stockId;
    $scope.stockById = {};
    var loadStockItems = function () {
        $http.get('/api/sales/stock?stockId=' + $stateParams.stockId).then(function (response) {
            $scope.stockById = response.data;
            $scope.isBusy = false;
        })
    }
    loadStockItems();


    //remove product
    $scope.removeProduct = function (id) {
        $scope.isBusy = true;
        $http.delete('/api/product?Id=' + id)
            .then(function (request) {
                $("product_" + id).fadeOut();
                $scope.isBusy = false;
                $mdToast.show(
                   $mdToast.simple()
                     .textContent('Product has successfully been removed')
                     .position('top right')
                     .hideDelay(3000)
                );
                loadStockItems();
            })
    }

    //add product
    $scope.addProduct = function () {

        $http.post('api/sales/stock', { item: $scope.product, stockId: $stateParams.stockId })
            .then(function (response) {
                //error?

            }, function (error) {
                $mdToast.show(
                 $mdToast.simple()
                   .textContent($scope.product.name + ' has successfully been added')
                   .position('top right')
                   .hideDelay(3000)
               );
                alert(response.data);
                loadStockItems();
            })

    }

    //remove stock
    $scope.removeStock = function () {
        $http.delete('/api/sales/stock?stockId='+$stateParams.stockId)
             .then(function (response) {
                 $state.go('removeStockSuccess')
             })
    }



})
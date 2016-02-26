product.controller('TransactionController', function ($scope, $http, $state) {

    $scope.transactionId = "";
    $scope.transactionItems = {};
    $scope.shopItems = [];
    $scope.isBusy = true;

    /*
     * on_page load create a new sales transaction
     * and load items for that transaction
     * 
     * TODO: change 'soldBy' field to unthenticated user
     */
    $http.post('api.ashx/api/sales/transaction', { transaction: { soldBy: 'Daniel Adigun' } })
        .then(function (response) {
            $scope.transactionId = response.data;
            //load items
            $http.get('/api.ashx/api/product')
               .then(function (response) {
                   $scope.shopItems = response.data;
                   $scope.isBusy = false;
               });
        })
    /**
     * load items by transactionId
     */
    var loadItems = function () {
        $http.get('api.ashx/api/sales/transaction?transactionId='+ $scope.transactionId)
            .then(function (response) {
                $scope.transactionItems = response.data.transactionItems;
            })
    }
    loadItems();

    /**
     * Add items to transaction
     */
    $scope.AddItemToTransaction = function (product) {
        var itemToAdd = {
            name: product.name,
            price: product.sellingPrice,
            qty: product.quantity
        };

        $http.post('api.ashx/api/sales/transaction', { transactionId: $scope.transactionId, item: itemToAdd })
            .then(function () {
                $('#product_' +product.Id).fadeOut();
                loadItems();
            })
       
    }

    /**
     * Get the sum of items added
     */
    $scope.getTransactionSum = function () {
        var total = 0;

        angular.forEach($scope.transactionItems, function (item) {
            total = total + item.price;
        })
        return total;
    }
    
    //Pagination
    $scope.currentPage = 0;
    $scope.pageSize = 7;
    $scope.numberOfPages = function () {
        return Math.ceil($scope.shopItems.length / $scope.pageSize);
    }

    //format dateCreated
    $scope.formatDate = function (date) {
        return moment(date).format("dddd, MMMM Do YYYY, h:mm:ss a");
    }

})
product.controller('TransactionController', function ($scope, $http, $state) {

    $scope.transactionId = "";
    $scope.transactionItems = {};
    $scope.shopItems = [];
    $scope.isBusy = true;
    $scope.isEditing = false;

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
            qty: 1 //set initial quantity to 1
        };

        $http.post('api.ashx/api/sales/transaction', { transactionId: $scope.transactionId, item: itemToAdd })
            .then(function (response) {
                $('#product_' + product.Id).fadeOut();
                loadItems();
              
            })
       
    }

    $scope.isEditing = function (index) {
      return  $scope.transactionItems[index].isEditing = true;
    }
    $scope.updateItem = function (Id) {
        $scope.isEditing = true;
    }

    /**
     * Get the sum of items added
     */
    $scope.getTransactionSum = function () {
        var total = 0;

        angular.forEach($scope.transactionItems, function (item) {
            total = total + (item.price * item.qty);
        })
        return total;
    }
    
    /**
     * remove item from transaction
     */
    $scope.removeItem = function (id) {
        $http.delete('api.ashx/api/sales/transaction?itemId=' + id)
           .then(function () {
               loadItems();
               alert('item has successfully been removed');
           })
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
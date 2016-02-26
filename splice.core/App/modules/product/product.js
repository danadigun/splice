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
                    templateUrl: '/App/modules/product/StockList.html'
                }

            },
            url: '/stock/view'
        })
    .state('viewStockbyId', {
        views: {
            'index': {
                templateUrl:'/App/modules/product/StockById.html'
            }
        },
        url:'/stock/view/:stockId'
    })
    .state('removeStockSuccess', {
        views: {
            'index': {
                templateUrl:'/App/modules/product/stockRemoved.html',
            }
        },
        url:'/stock/delete/sucess'
    })
});

product.controller('ProductController', function ($scope, $http, $mdToast) {

    $scope.DisplayManageProduct = function () {
        $('#modal-add-product').openModal();
    }       
});

product.controller('ManageStockController', function ($scope, $http, $state, $mdToast, $interval) {
    $scope.step = "Step 1: Create Stock";
    $scope.date = "";
    $scope.stockId = 0;

 
    $scope.hasList = false; 
    $scope.isBusy = false;

    $('#add-items').hide();
    $('#table-list').hide();

    //Create Stock
    $scope.showCreateStock = function () {
        $('#modal-add-product').closeModal();
        $state.go('CreateStock');
    }
    $scope.createStock = function (stock) {
        $scope.isBusy = true;
        $http.post('api.ashx/api/sales/stock', { stock: $scope.stock })
            .then(function (response) {
                $scope.stockId = response.data;
                $scope.hasList = true;
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
                $scope.isBusy = false;
            }, function (error) {
                alert('unable to create new stock')
            })
    }
    $scope.addItemToStock = function () {

        $http.post('api.ashx/api/sales/stock', { stockId: $scope.stockId, item: $scope.product })
           .then(function (response) {
               //error?
           }, function (error) {
               //load items to display;
               loadAddedItems();

               //display success toast
               $mdToast.show(
                   $mdToast.simple()
                     .textContent($scope.product.name + ' has successfully been created')
                     .position('top right')
                     .hideDelay(3000)
                );
               $scope.showViewItems();
           });
    }

    //Display List of Items Added 
    $scope.addedItems = {};
    var loadAddedItems = function () {
        $http.get('/api.ashx/api/sales/stock?stockId=' + $scope.stockId)
         .then(function (response) {
             $scope.addedItems = response.data;
             
         }, function (error) {
             console.log("Unable to load Stock");
         })
    }
   

    //toggle views
    $scope.showViewItems = function () {
        $('#add-items').hide();
        $('#table-list').fadeIn();
    }
    $scope.showAddItems = function () {
        $('#table-list').hide();
        $('#add-items').fadeIn();
    }

    //Pagination
    $scope.currentPage = 0;
    $scope.pageSize = 7;
    $scope.numberOfPages = function () {
        return Math.ceil($scope.addedItems.items.length / $scope.pageSize);
    }

   
    //display list of stock items
    $scope.showStockItems = function () {
        $("#create-stock").hide();
        $('#add-items').hide();
        $("#table-list").fadeIn();
        
        //$scope.step = "Stock Items"
    }

    //remove product
    $scope.removeProduct = function (id) {
        $scope.isBusy = true;
        $http.delete('api.ashx/api/product?Id='+id)
            .then(function (request) {
                $("product_" + id).fadeOut();
                $scope.isBusy = false;
                $mdToast.show(
                   $mdToast.simple()
                     .textContent('Product has successfully been removed')
                     .position('top right')
                     .hideDelay(3000)
                );
                loadAddedItems();
            })
       // alert("Product : " + id + " has been successfully removed!");
    }

});


//We already have a limitTo filter built-in to angular,
//let's make a startFrom filter
product.filter('startFrom', function () {
    return function (input, start) {
        start = +start; //parse to int
        return input.slice(start);
    }
});
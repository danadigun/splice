﻿var customer = angular.module('splice.customer', []);

customer.controller('CustomerController', function ($scope, $timeout, $mdBottomSheet, $mdToast) {

    $scope.showGridBottomSheet = function () {
        $scope.alert = '';
        $mdBottomSheet.show({
            templateUrl: 'App/modules/customer/bottom-sheet-grid-template.html',
            controller: 'GridBottomSheetCtrl',
            clickOutsideToClose: false
        }).then(function (clickedItem) {
            $mdToast.show(
                  $mdToast.simple()
                    .textContent(clickedItem['name'] + ' clicked!')
                    .position('top right')
                    .hideDelay(1500)
                );
        });
    };
});

customer.controller('GridBottomSheetCtrl', function ($scope, $mdBottomSheet) {
    $scope.items = [
      { name: 'Hangout', icon: 'hangout' },
      { name: 'Mail', icon: 'mail' },
      { name: 'Message', icon: 'message' },
      { name: 'Copy', icon: 'copy2' },
      { name: 'Facebook', icon: 'facebook' },
      { name: 'Twitter', icon: 'twitter' },
    ];
    $scope.listItemClick = function ($index) {
        var clickedItem = $scope.items[$index];
        $mdBottomSheet.hide(clickedItem);
    };
})
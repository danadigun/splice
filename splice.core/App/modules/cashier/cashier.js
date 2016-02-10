﻿angular.module('splice.cashier', []).controller('ListCtrl', function ($scope, $mdDialog) {
    $scope.toppings = [
      { name: 'Pepperoni', wanted: true },
      { name: 'Sausage', wanted: false },
      { name: 'Black Olives', wanted: true },
      { name: 'Green Peppers', wanted: false }
    ];
    $scope.settings = [
      { name: 'Wi-Fi', extraScreen: 'Wi-fi menu', icon: 'device:network-wifi', enabled: true },
      { name: 'Bluetooth', extraScreen: 'Bluetooth menu', icon: 'device:bluetooth', enabled: false },
    ];
    $scope.messages = [
      { id: 1, title: "Message A", selected: false },
      { id: 2, title: "Message B", selected: true },
      { id: 3, title: "Message C", selected: true },
    ];
    $scope.people = [
      { name: 'Janet Perkins', img: 'img/thumbnail.jpg', newMessage: true },
      { name: 'Mary Johnson', img: 'img/thumbnail.jpg', newMessage: false },
      { name: 'Peter Carlsson', img: 'img/thumbnail.jpg', newMessage: false }
    ];
    $scope.goToPerson = function (person, event) {
        $mdDialog.show(
          $mdDialog.alert()
            .title('Navigating')
            .textContent('Inspect ' + person)
            .ariaLabel('Person inspect demo')
            .ok('Neat!')
            .targetEvent(event)
        );
    };
    $scope.navigateTo = function (to, event) {
        $mdDialog.show(
          $mdDialog.alert()
            .title('Navigating')
            .textContent('Imagine being taken to ' + to)
            .ariaLabel('Navigation demo')
            .ok('Neat!')
            .targetEvent(event)
        );
    };
    $scope.doPrimaryAction = function (event) {
        $mdDialog.show(
          $mdDialog.alert()
            .title('Primary Action')
            .textContent('Primary actions can be used for one click actions')
            .ariaLabel('Primary click demo')
            .ok('Awesome!')
            .targetEvent(event)
        );
    };
    $scope.doSecondaryAction = function (event) {
        $('#modal1').openModal();
    };
    $scope.addNewStaff = function () {
        $('#modal2').openModal();
    }
   
})


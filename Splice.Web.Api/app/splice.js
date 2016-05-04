var splice = angular.module('spliceApp', ['ngMaterial', 'ui.router', 'splice.dashboard', 'splice.customer', 'splice.cashier', 'splice.product', 'JDatePicker']);

splice.config(function ($stateProvider, $urlRouterProvider, $mdThemingProvider) {

    $mdThemingProvider.theme('docs-dark', 'default')
     .primaryPalette('blue')
     .dark();

    $urlRouterProvider.otherwise(function ($injector) {
        var $state = $injector.get("$state");
        $state.go('dashboard');
    });

    $stateProvider.state('dashboard', {
        views: {
            'index': {
                templateUrl: '/App/modules/dashboard/dashboard.html'
            }
        },
        url: '/dashboard'
    })
    .state('sell', {
        views: {
            'index': {
                templateUrl: '/App/modules/sell/sell.html'
            }
        },
        url: '/sell'
    })
    .state('customer', {
        views: {
            'index': {
                templateUrl: '/App/modules/customer/customer.html'
            }
        },
        url: '/customer'
    })
    .state('product', {
        views: {
            'index': {
                templateUrl: '/App/modules/product/product.html'
            }
        },
        url: '/product'
    })
    .state('profile', {
        views: {
            'index': {
                templateUrl: '/App/modules/profile/profile.html'
            }
        },
        url: '/profile'
    })
    .state('report', {
        views: {
            'index': {
                templateUrl: '/App/modules/reports/reports.html'
            }
        },
        url: '/report'
    })
    .state('cashier', {
        views: {
            'index': {
                templateUrl: '/App/modules/cashier/cashier.html'
            }
        },
        url: '/cashier'
    })
});

//controller for sidenav open
splice.controller('SliderController', function ($scope, $mdSidenav) {
    $scope.slideOpenLeft = function () {
        $mdSidenav('left').toggle();
    }
});

splice.run(function ($log) {
    $log.debug("splice running");
});
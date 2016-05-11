var splice = angular.module('spliceApp', ['ngMaterial', 'ui.router', 'splice.dashboard', 'splice.customer', 'splice.cashier', 'splice.product', 'JDatePicker', 'angular-growl', 'ngMask', 'ngCookies']);

splice.value("baseUrl", '');
splice.config(['growlProvider', function (growlProvider) {
    growlProvider.globalTimeToLive(3000);
}]);
splice.config(function ($stateProvider, $urlRouterProvider, $mdThemingProvider) {
   
    $mdThemingProvider.theme('docs-dark', 'default')
     .primaryPalette('blue')
     .dark();

    $urlRouterProvider.otherwise(function ($injector) {
        var $state = $injector.get("$state");
        $state.go('login');
    });

    $stateProvider.state('login', {
        views: {
            'index': {
                templateUrl: 'modules/login/login.html',
                controller: 'loginController',
                theme: ''
            }
        },
        url: '/login'
    })
     .state('signup', {
         views: {
             'index': {
                 templateUrl: '/App/modules/login/signup.html',
                 controller: 'retailerController',
                 theme: ''
             }
         },
         url: '/signup'
     })
    .state('dashboard', {
        views: {
            'index': {
                templateUrl: '/App/modules/dashboard/dashboard.html',
                controller: 'StoreHealthController'
            }
        },
        url: '/dashboard'
    })
    .state('stock', {
        views: {
            'index': {
                templateUrl: '/App/modules/stock/stock.html',
                controller: 'retailerController'
            }
        },
        url: '/stock'
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

splice.run(function ($log, $rootScope, $location, $cookieStore, $http, loginService) {
    $rootScope.hidebar = false;
    $rootScope.globals = $cookieStore.get('globals');
    $log.debug("splice running");


    $rootScope.Logout = function () {
        loginService.logout({ AuthToken: $rootScope.globals })
        .then(function () {
            $rootScope.globals = ''
            $cookieStore.remove('globals');
            $location.path('login');
        })
    };


    if ($rootScope.globals != "" && $rootScope.globals != undefined) {
        $rootScope.hidebar = true;
        $http.defaults.headers.common['Authorization'] = $rootScope.globals;

        if ($.inArray($location.path(), ['/login', '/dashboard']) !== -1)
            $location.path("dashboard");
    }
    else {
        $rootScope.hidebar = false;
        $location.path("login");

    }


});
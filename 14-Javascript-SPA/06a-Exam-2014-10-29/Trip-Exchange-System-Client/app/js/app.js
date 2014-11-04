'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/partials/home-page.html'
            })

            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'RegisterCtrl'
            })

            .when('/unauthorized', {
                templateUrl: 'views/partials/unauthorized.html'
            })

            .when('/trips', {
                templateUrl: 'views/partials/trips.html',
                controller: 'TripsController'
            })

            .when('/trips/:id', {
                templateUrl: 'views/partials/trip-info.html',
                controller: 'TripsController'
            })

            .when('/trip/create', {
                templateUrl: 'views/partials/create-trip.html',
                controller: 'TripsController'
            })


            .when('/drivers', {
                templateUrl: 'views/partials/drivers.html',
                controller: 'DriversController'
            })

            .when('/drivers/:id', {
                templateUrl: 'views/partials/driver-info.html',
                controller: 'DriversController'
            })

            .otherwise({ redirectTo: '/' });
    }])
    .value('toastr', toastr)
    .constant('cookieStorageUserKey', 'TripSystemUser')
    .constant('baseServiceUrl', 'http://spa2014.bgcoder.com/')
    .constant('registerUrl', '/api/users/register')
    .constant('loginUrl', '/api/users/login')
    .constant('logoutUrl', '/api/users/logout');

app.constant('paginationConfig', {
    itemsPerPage: 10,
    boundaryLinks: false,
    directionLinks: true,
    firstText: 'First',
    previousText: 'Previous',
    nextText: 'Next',
    lastText: 'Last',
    rotate: true
});
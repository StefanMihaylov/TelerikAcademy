'use strict';

app.controller('TripsController', ['$scope', '$location', '$routeParams', '$route', 'notifier', 'identity', 'authorization', 'tripData', 'statisticData', 'citiesData',
    function ($scope, $location, $routeParams, $route, notifier, identity, authorization, tripData, statisticData, citiesData) {

        $scope.identity = identity;

        tripData.get()
            .then(function (data) {
                $scope.trips = data;
            },
            function (response) {
                notifier.responseError(response);
            });

        citiesData.get()
            .then(function (data) {
                $scope.cities = data;
            },
            function (response) {
                notifier.responseError(response);
            });

        $scope.currentPage = 1;
        refreshMaxPage();

        $scope.setPage = function (pageNo) {
            $scope.currentPage = pageNo;
        };

        $scope.pageChanged = function () {
            newSearch();
        };

        $scope.newSearch = newSearch;
        $scope.search = {};
        $scope.search.orderBy = 'asc';

        newSearch();

        if ($routeParams.id) {
            var id = $routeParams.id;
            tripData.getById(id)
                .then(function (data) {
                    $scope.tripDetails = data;
                    $scope.validData = true;
                },
                function (response) {
                    notifier.responseError(response);
                    $scope.validData = false;
                });
        }

        $scope.join = function () {
            if ($scope.tripDetails) {
                var freeSeats = $scope.tripDetails.numberOfFreeSeats;
                if (freeSeats > 0) {
                    var id = $scope.tripDetails.id;
                    tripData.join(id)
                        .then(function (data) {
                            notifier.success('You join the trip successfully');
                            $route.reload();
                        },
                        function (response) {
                            notifier.responseError(response);
                            $scope.validData = false;
                        });
                }
            }
        };

        $scope.createNew = function (data) {

            if (data) {
                var from = data.from;
                var to = data.to;
                var date = data.departureTime;
                var seats = parseInt(data.availableSeats);
                var currentDate = new Date();

                if(!from){
                    notifier.error("Select From city");
                }
                else if(!to){
                    notifier.error("Select To city");
                }
                else if (from === to) {
                    notifier.error("From city and To city must be different");
                }
                else if (!date || date <= currentDate) {
                    notifier.error("Departure date must be in the future");
                }
                else if (!seats|| seats <= 0) {
                    notifier.error("Number of free seats must be greater than zero");
                }
                else {
                    tripData.create(data)
                        .then(function (resultData) {
                            notifier.success('New trip created successfully');
                            $location.path('/trips');
                        },
                        function (response) {
                            notifier.responseError(response);
                        });
                }
            }
        };

        $scope.SwitchToNew = function () {
            $location.path('/trip/create');
        }

        function newSearch() {
            refreshMaxPage();

            var isFinished = undefined;
            var isMine = undefined;
            var sortBy = undefined;
            var orderBy = undefined;
            var from = undefined;
            var to = undefined;

            if ($scope.search) {
                isFinished = $scope.search.isFinished;
                isMine = $scope.search.isMine;
                sortBy = $scope.search.sortBy;
                orderBy = $scope.search.orderBy;
                from = $scope.search.from;
                to = $scope.search.to;
            }

            if (true) {
                tripData.getByParams($scope.currentPage, isFinished, isMine, sortBy, orderBy, from, to)
                    .then(function (data) {
                        $scope.tripsPagged = data;
                    },
                    function (response) {
                        notifier.responseError(response);
                    });
            }
        }

        function refreshMaxPage() {
            statisticData.get(undefined, undefined)
                .then(function (data) {
                    if (!$scope.search || !$scope.search.isFinished) {
                        $scope.totalItems = data.trips - data.finishedTrips;
                    }
                    else {
                        $scope.totalItems = data.trips;
                    }

                },
                function (response) {
                    notifier.responseError(response);
                });
        }
    }]);

'use strict';

app.controller('DriversController', ['$scope', '$location', '$routeParams', 'notifier', 'identity', 'authorization', 'driverData', 'statisticData',
    function ($scope, $location, $routeParams, notifier, identity, authorization, driverData, statisticData) {

        $scope.identity = identity;

        driverData.get()
            .then(function (data) {
                $scope.drivers = data;
            },
            function (response) {
                notifier.responseError(response);
            });

        statisticData.get(undefined, undefined)
            .then(function (data) {
                $scope.totalItems = data.drivers;
            },
            function (response) {
                notifier.responseError(response);
            });

        $scope.currentPage = 1;

        $scope.setPage = function (pageNo) {
            $scope.currentPage = pageNo;
        };

        $scope.pageChanged = function () {
            newSearch();
        };

        $scope.newSearch = newSearch;

        newSearch();

        $scope.sort = 'id';

        if ($routeParams.id) {
            var id = $routeParams.id;
            driverData.getByTd(id)
                .then(function (data) {
                    $scope.driverDetails = data;
                },
                function (response) {
                    notifier.responseError(response);
                });
        }

        function newSearch() {
            var name = undefined;
            if ($scope.search) {
                name = $scope.search.name;
            }

            driverData.get($scope.currentPage, name)
                .then(function (data) {
                    $scope.driversPagged = data;
                },
                function (response) {
                    notifier.responseError(response);
                });
        }
    }]);

'use strict';

app.controller('StatsController', ['$scope', '$location', 'notifier', 'identity', 'authorization', 'statisticData',
    function ($scope, $location, notifier, identity, authorization, statisticData) {

        statisticData.get()
            .then(function (data) {
                $scope.stats = data;
            },
            function (response) {
                notifier.responseError(response);
            });
    }]);

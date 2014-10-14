app.controller('MainCtrl', function($scope, cachedTrips) {
    $scope.trips = cachedTrips.query();
});
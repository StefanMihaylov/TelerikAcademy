app.controller('TripsListCtrl', function($scope, cachedTrips) {
    $scope.trips = cachedTrips.query();
});
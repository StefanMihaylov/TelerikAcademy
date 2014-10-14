app.controller('TripDetailsCtrl', function($scope, $routeParams, cachedTrips) {

    $scope.trip = cachedTrips.query().$promise.then(function(collection) {
        collection.forEach(function(trip) {
            if (trip._id === $routeParams.id) {
                $scope.trip = trip;
            }
        })
    })
});
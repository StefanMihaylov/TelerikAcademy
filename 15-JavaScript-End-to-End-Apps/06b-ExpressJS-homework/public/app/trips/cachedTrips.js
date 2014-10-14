app.factory('cachedTrips', function(TripResource) {
    var cachedTrips;

    return {
        query: function() {
            if (!cachedTrips) {
                cachedTrips = TripResource.query();
            }

            return cachedTrips;
        }
    }
});

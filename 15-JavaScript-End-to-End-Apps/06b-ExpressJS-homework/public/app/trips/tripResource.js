app.factory('TripResource', function($resource) {
    var TripResource = $resource('/api/trips/:id', {id:'@id'}, { update: {method: 'PUT', isArray: false}});

    return TripResource;
})
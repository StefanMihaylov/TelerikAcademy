var Trip = require('mongoose').model('Trip');

module.exports = {
    getAllTrips: function(req, res, next) {
        Trip.find({}).exec(function(err, collection) {
            if (err) {
                console.log('Trips could not be loaded: ' + err);
            }

            res.send(collection);
        })
    },
    getTripById: function(req, res, next) {
        Trip.findOne({_id: req.params.id}).exec(function(err, Trip) {
            if (err) {
                console.log('Trip could not be loaded: ' + err);
            }

            res.send(Trip);
        })
    }
};

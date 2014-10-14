var mongoose = require('mongoose');
require('../models/User');
require('../models/City');

var User = mongoose.model('User');
var City = mongoose.model('City');

var tripSchema = mongoose.Schema({
    driver: { type: String, require: '{PATH} is required'},
    from: { type: String, require: '{PATH} is required' },
    to: { type: String, require: '{PATH} is required' },
    date: { type: Date, require: '{PATH} is required' }
});

var Trip = mongoose.model('Trip', tripSchema);

module.exports.seedInitialData = function () {
    Trip.find({}).count({}, function (err, numberOfTrips) {
        if (err) {
            console.log('Cannot find trips: ' + err);
        }

        if (!numberOfTrips) {
            City.find({})
                .select('name')
                .exec(function (err, cityCollection) {
                    if (err) {
                        console.log('Cannot find cities: ' + err);
                        return;
                    }

                    var cities = cityCollection;
                    var numberOfCities = cityCollection.length;

                    User.find({'username': {'$ne': 'admin' }})
                        .select('username')
                        .exec(function (err, userCollection) {
                            if (err) {
                                console.log('Cannot find users: ' + err);
                                return;
                            }

                            var users = userCollection;
                            var numberOfUsers = userCollection.length;

                            for (var i = 0; i < 100; i++) {
                                var driverId = getRandomInt(0, numberOfUsers - 1);
                                var fromId = getRandomInt(0, numberOfCities - 1);
                                var toId = getRandomInt(0, numberOfCities - 1);
                                Trip.create({
                                    driver: users[driverId].username,
                                    from: cities[fromId].name,
                                    to: cities[toId].name,
                                    date: getRandomDate()
                                });
                            }

                            console.log('Trips added to database...');
                        });
                });
        }
    });
};

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function getRandomDate() {
    var year = getRandomInt(2000, 2020);
    var month = getRandomInt(1, 12);
    var day = getRandomInt(1, 31);
    var hour = getRandomInt(0, 23);
    var minute = getRandomInt(0, 59);
    var second = getRandomInt(0, 59);

    return new Date(year, month, day, hour, minute, second);
}
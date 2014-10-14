'use strict';

var mongoose = require('mongoose'),
    categoryModel = require('../data/models/Category'),
    eventModel = require('../data/models/Event'),
    initiativeModel = require('../data/models/Initiative'),
    seasonModel = require('../data/models/Season'),
    userModel = require('../data/models/User');

module.exports = function (config) {
    mongoose.connect(config.dbConnectionString);

    var db = mongoose.connection;

    db.once('open', function (err) {
        if (err) {
            console.log('Database could not be opened: ' + err);
            return;
        }

        console.log('Database up and running...')
    });

    db.on('error', function (err) {
        console.dir(err);
        console.log('Database error: ' + err);
    });

    categoryModel.seedInitialData();
    initiativeModel.seedInitialData();
    seasonModel.seedInitialData();

    eventModel.seedInitialData();
    userModel.seedInitialData();
};

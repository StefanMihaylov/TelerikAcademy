var mongoose = require('mongoose'),
    user = require('../model/User'),
    message = require('../model/Message');

module.exports = function (config) {
    mongoose.connect(config.db);
    var db = mongoose.connection;

    db.once('open', function (err) {
        if (err) {
            console.log('Database cannot be opened: ' + err);
            return;
        }

        console.log('Database up and running...');
    });

    db.on('error', function (err) {
        console.log('Database error: ' + err);
    });

    // seed test data
    user.seedInitialData();
    message.seedInitialData();
};

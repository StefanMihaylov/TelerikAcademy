'use strict';
var mongoose = require('mongoose');

var seasonSchema = mongoose.Schema({
    name: { type: String, require: '{PATH} is required', unique: true}
});

var Season = mongoose.model('Season', seasonSchema);

module.exports.seedInitialData = function () {

    Season.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find seasons: ' + err);
            return;
        }

        if (collection.length === 0) {
            Season.create({name: 'Started 2010'});
            Season.create({name: 'Started 2011'});
            Season.create({name: 'Started 2012'});
            Season.create({name: 'Started 2013'});

            console.log('Seasons added to database...');
        }
    });
};

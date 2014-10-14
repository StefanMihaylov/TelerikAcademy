'use strict';
var memoize = require('memoizee'),
    events = require('../data/eventsData'),
    common = require('../data/commonData');

var memoizedEvent = memoize(getEvents, { maxAge: 600000, async: true }); // 600.000s = 10 min

module.exports = {
    getLastData: function (req, res) {
        common.categories();
        common.initiative();
        common.seasons();

        memoizedEvent(10, function (err, collection) {
            if (err) {
                console.log('Events could not be loaded: ' + err);
            }
            else {
                res.render('index', {passedEvents: collection});
            }
        });
    }
};

function getEvents(count, callback) {
    var currentDate = new Date();
    var query = events.getAll({ "date": { $lt: currentDate}})
        .sort('-date')
        .limit(count)
        .exec(function (err, collection) {
           // console.log(new Date());
            callback(err, collection);
        });
}
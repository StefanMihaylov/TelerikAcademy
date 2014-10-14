'use strict';
var Event = require('mongoose').model('Event');

module.exports = {
    add: function (event, callback) {
        Event.create(event, callback);
    },
    getAll: function (query) {
        var newQuery = query || {};
        return Event.find(newQuery);
    },
    findOne: function (query) {
        var newQuery = query || {};
        return Event.findOne(newQuery);
    }
};

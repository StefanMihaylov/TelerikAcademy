'use strict';
var User = require('mongoose').model('User');

module.exports = {
    create: function (user, callback) {
        User.create(user, callback)
    },
    getAll: function (query) {
        var query = query || {};
        return User.find(query)
    },
    findOne: function (query) {
        var query = query || {};
        return User.findOne(query)
    }
};

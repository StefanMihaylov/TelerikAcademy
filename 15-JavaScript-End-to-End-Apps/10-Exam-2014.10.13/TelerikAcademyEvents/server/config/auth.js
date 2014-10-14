'use strict';
var passport = require('passport');

module.exports = {
    isAuthenticated: function (req, res, next) {
        if (!req.isAuthenticated()) {
            res.redirect('/login');
            res.end();
        }
        else {
            next();
        }
    }
};
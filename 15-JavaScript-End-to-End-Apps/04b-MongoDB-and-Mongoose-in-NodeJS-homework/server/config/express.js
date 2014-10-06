'use strict';

var express = require('express'),
    path = require('path'),
    stylus = require('stylus'),
    bodyParser = require('body-parser'),
    logger = require('morgan'),
    cookieParser = require('cookie-parser'),
    session = require('express-session'),
    passport = require('passport');


module.exports = function (app, config) {
    app.set('view engine', 'jade');
    app.set('views', path.join(config.rootPath, 'server/views'));

    app.use(stylus.middleware({  src: config.rootPath + '/public',
        compile: function (str, path) {
            return stylus(str).set('filename', path);
        }}));
    app.use(express.static(path.join(config.rootPath, 'public')));

    app.use(cookieParser());
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({extended: true}));
    app.use(session({
        secret: 'secret password',
        resave: true,
        saveUninitialized: true
    }));
    app.use(passport.initialize());
    app.use(passport.session());
    app.use(logger('dev'));
};


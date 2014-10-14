'use strict';
var usersController = require('./UsersController'),
    homeController = require('./HomeController'),
    eventsController = require('./EventsController');


module.exports = {
    users: usersController,
    home: homeController,
    events: eventsController
};

'use strict';
var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function (app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', controllers.users.postLogin);
    app.get('/logout', auth.isAuthenticated, controllers.users.logout);

    app.get('/profile', auth.isAuthenticated, controllers.users.getById);
    app.post('/profile', auth.isAuthenticated, controllers.users.update);

    app.get('/create', auth.isAuthenticated, controllers.events.getCreate);
    app.post('/create', auth.isAuthenticated, controllers.events.postCreate);

    app.get('/active', auth.isAuthenticated, controllers.events.getActive);
    app.post('/active', auth.isAuthenticated, controllers.events.changePage);

    app.get('/past', auth.isAuthenticated, controllers.events.getPast);
  //  app.post('/past', auth.isAuthenticated, controllers.events.changePage);

    app.get('/details/:id',auth.isAuthenticated, controllers.events.getById);
    app.post('/details/:id',auth.isAuthenticated, controllers.events.postById);

    app.get('index', controllers.home.getLastData);
    app.get('*', controllers.home.getLastData);
};

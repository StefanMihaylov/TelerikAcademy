var usersController = require('../controllers/usersController');
var coursesController = require('../controllers/coursesController');
var tripsController = require('../controllers/tripsController');

module.exports = {
    users: usersController,
    courses: coursesController,
    trips: tripsController
};
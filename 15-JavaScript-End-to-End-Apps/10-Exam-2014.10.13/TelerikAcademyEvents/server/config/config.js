'use strict';

var path = require('path');
var rootPath = path.normalize(__dirname + '/../../');

module.exports = {
    development: {
        rootPath: rootPath,
        dbConnectionString: 'mongodb://localhost:27017/TelerikAcademyEvents',
        port: process.env.PORT || 3000
    },
    production: {
        rootPath: rootPath,
        dbConnectionString: 'mongodb://',
        port: process.env.PORT || 3000
    }
};


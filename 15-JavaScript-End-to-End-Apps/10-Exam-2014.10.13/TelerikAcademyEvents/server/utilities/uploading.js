'use strict';
var fs = require('fs'),
    makeDir = require('mkdirp'),
    path = require('path');

var filesDir = path.normalize(__dirname + '/../../files');


module.exports = {
    createDir: function(path, dirName) {
        dirName = dirName || '';
        makeDir.sync(filesDir + path + dirName);
    },
    saveFile: function(file, path, fileName) {
        if (!fs.existsSync(filesDir + path)) {
            this.createDir(path);
        }

        var fileStream = fs.createWriteStream(filesDir + path + fileName);
        file.pipe(fileStream);
    }
};

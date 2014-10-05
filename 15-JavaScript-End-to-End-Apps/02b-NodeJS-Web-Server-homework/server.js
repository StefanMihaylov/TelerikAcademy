"use strict";
var formidable = require('formidable'),
    http = require('http'),
    fs = require('fs'),
    url = require('url'),
    uuid = require('node-uuid');

var port = 9876;
var storage = './data';
var db = [];

http.createServer(function (request, response) {
   // console.log(request.url);

    var parsedRequest = url.parse(request.url, true, true);

    if (parsedRequest.pathname == '/upload' && request.method.toLowerCase() === 'post') {
        // parse a file upload
        var form = new formidable.IncomingForm();
        form.uploadDir = storage;
        form.multiples = true;
        form.keepExtensions = true;

        form.on('fileBegin', function (name, file) {
            var originalFileName = file.name;
            var dotIndex = originalFileName.lastIndexOf('.');
            var extension = originalFileName.substring(dotIndex);
            var fileName = uuid.v4() + extension;
            file.path = form.uploadDir + "/" + fileName;
            db.push({link: fileName, name: originalFileName});
        });

        form.parse(request, function (err, fields, files) {
            if (err) {
                console.log(err);
            } else {
                response.writeHead(200, {'content-type': 'text/html'});
                var fileNames = [];
                if (files.upload.length) {
                    for (var i = 0; i < files.upload.length; i += 1) {
                        fileNames.push(files.upload[i].name);
                    }
                }
                else {
                    fileNames.push(files.upload.name);
                }

                var names = fileNames.join(', ');
                response.write('<h2>File <em>' + names + '</em> uploaded!</h2>');
                response.write('<div> <a href="/">Back</a></div>');
                response.end();
            }
        });

        return;
    }

    if (parsedRequest.pathname == '/download') {
        var fileName = parsedRequest.query['link'];

        var originalFileName='';
        for(var i=0; i<db.length; i+=1){
            var record = db[i];
            if(record.link === fileName ){
                originalFileName = record.name;
                break;
            }
        }

        fs.readFile(storage + '/' + fileName, function (err, data) {
            if (err) {
                console.log(err);
            }
            response.writeHead(200, {
                'Content-type': 'image/png',
               // 'Content-Disposition': 'attachment; filename=' + originalFileName
            });
            response.end(data, 'binary');
        });
    }

    if (parsedRequest.pathname == '/' && request.method.toLowerCase() === 'get') {
        // show a file upload form
        response.writeHead(200, {'content-type': 'text/html'});

        var view = '<form action="/upload" enctype="multipart/form-data" method="post">' +
            '<input type="file" name="upload" multiple="multiple"><br>' +
            '<input type="submit" value="Upload">' +
            '</form>';

        view += '<ol>';
        view += '<h4>Download files</h4>';
        for (var i = 0; i < db.length; i += 1) {
            view += '<li><a href="/download?link=' + db[i].link + '">' + db[i].name + '</a></li>'
        }
        view += '</ol>';

        response.end(view);
    }

}).listen(port);

console.log('Server is running on port ' + port + '...');
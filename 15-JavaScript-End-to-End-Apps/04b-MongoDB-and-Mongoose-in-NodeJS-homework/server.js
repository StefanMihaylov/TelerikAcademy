var express = require('express');

// var env = process.env.NODE_ENV || 'development';

var app = express();
var config = require('./server/config/config')['development'];

require('./server/config/express')(app, config);
require('./server/config/mongoose')(config);

app.listen(config.port, function () {
    console.log('Server running on port ' + config.port);
    console.log('Restart the server if chat results do not appear');
});

// homework
var chatDb = require('./server/modules/chat-db');

//inserts a new user records into the DB
chatDb.registerUser({user: 'Ali Raza', pass: 'qwerty'});
chatDb.registerUser({user: 'Ferhunde', pass: 'qwerty'});

//inserts a new message record into the DB the message has two references to users (from and to)
chatDb.sendMessage({ from: 'Ali Raza', to: 'Ferhunde', text: 'Vay, Vay!'});
chatDb.sendMessage({ from: 'Ferhunde', to: 'Ali Raza', text: 'Speak in English, Please'});
chatDb.sendMessage({ from: 'Ali Raza', to: 'Ferhunde', text: 'Come here to cry together'});

//returns an array with all messages between two users
chatDb.getMessages({ with: 'Ali Raza', and: 'Ferhunde' }, function (message) {
    console.log(message.from + ' => ' + message.to + ' : ' + message.text);
});

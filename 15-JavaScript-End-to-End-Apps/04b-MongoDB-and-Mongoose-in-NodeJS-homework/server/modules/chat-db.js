'use strict';

var mongoose = require('mongoose');
require('../model/User');
require('../model/Message');

var User = mongoose.model('User');
var Message = mongoose.model('Message');

module.exports = {
    registerUser: function (user) {
        User.create(user);
    },

    sendMessage: function (message) {
        User.findOne({ user: message.from }, function (err, result) {
            if (err) {
                console.log('Cannot find the user');
                return;
            }
            var fromUser = result;
            User.findOne({ user: message.to }, function (err, result) {
                if (err) {
                    console.log('Cannot find the user');
                    return;
                }
                var toUser = result;
                Message.create({ from: fromUser, to: toUser, text: message.text});
            });
        });
    },

    getMessages: function (users, callback) {
        User.findOne({user: users.with}, function (err, result) {
            if (err) {
                console.log('Cannot find the user');
                return;
            }
            var fromUser = result;
            User.findOne({user: users.and}, function (err, result) {
                if (err) {
                    console.log('Cannot find the user');
                    return;
                }
                var toUser = result;

                var query = Message.find({});
                query.or([
                    { from: fromUser },
                    { to: toUser },
                    { from: toUser },
                    { to: fromUser }
                ]);
                query.exec(function (err, result) {
                    if (err) {
                        console.log('Cannot messages between the two users');
                        return;
                    }

                    result.forEach(NormalizeMessage);
                });
            });
        });
    }
};

function NormalizeMessage(message, index, array) {
    User.findOne({_id: message.from}, function (err, result) {
        if (err) {
            console.log('Cannot find the user');
            return;
        }
        var fromUser = result;

        User.findOne({_id: message.to}, function (err, result) {
            if (err) {
                console.log('Cannot find the user');
                return;
            }
            var toUser = result;

            var newMessage = { from: fromUser.user, to: toUser.user, text: message.text};
            console.log(newMessage.from + ' => ' + newMessage.to + ' : ' + newMessage.text);
        });
    });
}

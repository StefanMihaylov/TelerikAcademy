var mongoose = require('mongoose');

var messageSchema = mongoose.Schema({
    from: { type: mongoose.Schema.ObjectId, ref: 'User', required: '{PATH} is required' },
    to: { type: mongoose.Schema.ObjectId, ref: 'User', required: '{PATH} is required' },
    text: { type: String, required: '{PATH} is required' }
});

var Message = mongoose.model('Message', messageSchema);

module.exports.seedInitialData = function () {
    var firstUser;
    var secondUser;

    var User = mongoose.model('User');
    User.find({}).exec(function (err, users) {
        if (err) {
            console.log('Cannot find users in database: ' + err);
            return;
        }

        firstUser = users[0];
        secondUser = users[1];
    });

    Message.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find messages: ' + err);
            return;
        }

        if (collection.length === 0) {
            Message.create({from: firstUser, to: secondUser, text: "Test message from first to second"});
            Message.create({from: secondUser, to: firstUser, text: "Test message from second to first"});
            console.log('Messages added to database...');
        }
    });
};

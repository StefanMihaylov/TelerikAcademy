var mongoose = require('mongoose');

var userSchema = mongoose.Schema({
    user: { type: String, require: '{PATH} is required', unique: true },
    pass: { type: String, require: '{PATH} is required' }
});

var User = mongoose.model('User', userSchema);

module.exports.seedInitialData = function () {
    User.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find users: ' + err);
            return;
        }

        if (collection.length === 0) {
            User.create({user: 'test user 1', pass: '12345'});
            User.create({user: 'test user 2', pass: '23456'});

            console.log('Users added to database...');
        }
    });
};

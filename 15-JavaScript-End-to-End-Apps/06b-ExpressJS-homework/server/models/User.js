var mongoose = require('mongoose'),
    encryption = require('../utilities/encryption');

var userSchema = mongoose.Schema({
    username: { type: String, require: '{PATH} is required', unique: true },
    firstName: { type: String, require: '{PATH} is required' },
    lastName: { type: String, require: '{PATH} is required' },
    salt: String,
    hashPass: String,
    roles: [String]
});

userSchema.method({
    authenticate: function (password) {
        if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
            return true;
        }
        else {
            return false;
        }
    }
});

var User = mongoose.model('User', userSchema);

module.exports.seedInitialUsers = function () {
    User.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find users: ' + err);
            return;
        }

        if (collection.length === 0) {
            var salt;
            var hashedPwd;

            salt = encryption.generateSalt();
            hashedPwd = encryption.generateHashedPassword(salt, 'admin');
            User.create({username: 'admin', firstName: 'admin', lastName: 'admin', salt: salt, hashPass: hashedPwd, roles: ['admin']});

            for (var i = 0; i < 30; i++) {
                salt = encryption.generateSalt();
                var firstName = 'Firstname #' + i;
                hashedPwd = encryption.generateHashedPassword(salt, firstName);
                User.create({
                    username: 'Username #' + i,
                    firstName: firstName,
                    lastName: 'Lastname #' + i,
                    salt: salt,
                    hashPass: hashedPwd,
                    roles: ['standard']});
            }

            console.log('Users added to database...');
        }
    });
};
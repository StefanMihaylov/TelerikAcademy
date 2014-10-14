'use strict';
var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption'),
    Initiative = require('./Initiative'),
    Season = require('./Season');

var userSchema = mongoose.Schema({
    username: { type: String, require: '{PATH} is required', unique: true, validate: [validator, 'Username must be from 6 to 20 symbols long'] },
    salt: { type: String, require: '{PATH} is required' },
    hashPass: { type: String, require: '{PATH} is required' },
    firstName: { type: String, require: '{PATH} is required' },
    lastName: { type: String, require: '{PATH} is required' },
    email: { type: String, require: '{PATH} is required' },
    organizationPoints: { type: Number, default: 0},
    venuePoints: { type: Number, default: 0},
    phoneNumber: { type: String},
    facebookLink: { type: String},
    twitterLink: { type: String},
    googleLink: { type: String},
    linkedInLink: { type: String},
    avatarUrl: { type: String},
    initiatives: [
        {type: mongoose.Schema.ObjectId, ref: 'Initiative'}
    ],
    seasons: [
        {type: mongoose.Schema.ObjectId, ref: 'Season'}
    ]
});

function validator(value) {
    return value.length >= 6 && value.length <= 20;
}

userSchema.method({
    authenticate: function (password) {
        var newHashedPass = encryption.generateHashedPassword(this.salt, password);
        return (newHashedPass === this.hashPass);
    }
});

userSchema.statics.createNew = function (user) {
    var newUser = user;
    newUser.salt = encryption.generateSalt();
    newUser.hashPass = encryption.generateHashedPassword(newUser.salt, user.password);
    newUser.password = undefined;
    this.create(newUser);
};

var User = mongoose.model('User', userSchema);

module.exports.seedInitialData = function () {

    User.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find users: ' + err);
            return;
        }

        if (collection.length === 0) {

            User.createNew({username: 'administrator', password: 'admin', firstName: 'admin', lastName: 'admin',
                email: 'admin@telerik.com', phoneNumber: '0888777666555', facebookLink: 'www.facebook.com/admin',
                googleLink: 'www.google.com/admin', twitterLink: 'www.twitter.com/admin',
                linkedInLink: 'www.linkedIn.com/admin'});

            User.createNew({username: 'PeterPetrov', password: 'pesho', firstName: 'Peter', lastName: 'Petrov', email: 'peter@pesho.com'});
            User.createNew({username: 'IvanIvanov', password: 'vankata', firstName: 'Ivan', lastName: 'Ivanov', email: 'ivan@vankata.com'});
            User.createNew({username: 'VasilVasilev', password: 'vasko', firstName: 'Vasil', lastName: 'vasilev', email: 'vasil@vasko.com'});
            User.createNew({username: 'StefanStefanov', password: 'stefcho', firstName: 'Stefan', lastName: 'Stefanov', email: 'stefan@stefcho.com'});

            console.log('Users added to database...');
        }
    });
};

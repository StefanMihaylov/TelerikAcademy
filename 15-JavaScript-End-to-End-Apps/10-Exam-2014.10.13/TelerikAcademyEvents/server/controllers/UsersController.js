var passport = require('passport');
var encryption = require('../utilities/encryption');
var usersData = require('../data/usersData');

var controller_Name = 'users';
var register_Route = '/register';
var login_Route = '/login';
var profile_Route = '/profile';

var registerView = controller_Name + register_Route;
var loginView = controller_Name + login_Route;
var profileView = controller_Name + profile_Route;

module.exports = {
    getRegister: function (req, res, next) {
        if (req.user) {
            res.redirect('/')
        }
        else {
            res.render(registerView);
        }
    },
    postRegister: function (req, res, next) {
        var newUserData = req.body;
        console.log(newUserData);
        if (newUserData.username.length < 6 || newUserData.username.length > 20) {
            req.session.error = "Username must be from 6 to 20 symbols long";
            res.redirect(register_Route);
        }
        else if (newUserData.password != newUserData.confirmPassword) {
            req.session.error = "Passwords do not match!";
            res.redirect(register_Route);
        }
        else if (newUserData.password.length < 5) {
            req.session.error = 'Password must be at least 5 symbols long!';
            res.redirect(register_Route);
        }
        else {
            var userToSave = newUserData;
            userToSave.salt = encryption.generateSalt();
            userToSave.hashPass = encryption.generateHashedPassword(userToSave.salt, newUserData.password);
            userToSave.password = undefined;

            usersData.create(userToSave, function (err, user) {
                if (err) {
                    console.log(err);
                    req.session.error = 'Failed to register new user';
                    res.redirect(register_Route);
                }
                else {
                    req.logIn(user, function (err) {
                        if (err) {
                            req.session.error = 'Login unsuccessful';
                            res.redirect('/');
                        }
                        else {
                            //res.send(user);
                            res.redirect('/');
                        }
                    })
                }
            });
        }
    },
    getLogin: function (req, res, next) {
        if (req.user) {
            res.redirect('/')
        }
        else {
            res.render(loginView);
        }
    },
    postLogin: function (req, res, next) {
        var auth = passport.authenticate('local', function (err, user) {
            if (err) {
                next(err);
            }
            else {
                if (!user) {
                    req.session.error = 'Invalid user and/or password';
                    res.redirect(login_Route);
                }
                else {
                    req.logIn(user, function (err) {
                        if (err) {
                            next(err);
                        }
                        else {
                            //  res.send({success: true, user: user});
                            res.redirect('/');
                        }
                    })
                }
            }
        });

        auth(req, res, next);
    },
    logout: function (req, res, next) {
        req.logout();
        res.redirect('/');
        res.end();
    },
    getById: function (req, res) {
        usersData.findOne({_id: req.user._id})
            .exec(function (err, currentUser) {
                if (err) {
                    console.log('User cannot be found by Id :' + err);
                } else {
                    res.render(profileView, {user: currentUser});
                }
            })
    },
    update: function(reg, res){
        usersData.findOne({_id: reg.user._id})
            .exec(function (err, currentUser) {
                if (err) {
                    console.log('User cannot be found by Id :' + err);
                } else {
                    var data = reg.body;
                    currentUser.phoneNumber = data.phoneNumber;
                    currentUser.facebookLink = data.facebookLink;
                    currentUser.twitterLink = data.twitterLink;
                    currentUser.googleLink = data.googleLink;
                    currentUser.linkedInLink = data.linkedInLink;

                    currentUser.save();

                    res.redirect('/');
                }
            })
    }
};

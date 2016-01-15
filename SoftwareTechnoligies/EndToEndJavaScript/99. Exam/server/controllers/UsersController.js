var encryption = require('../utilities/encryption');
var users = require('../data/users');

var CONTROLLER_NAME = 'users';

module.exports = {
    getRegister: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/register')
    },
    getProfile : function (req, res, next) {
        res.render(CONTROLLER_NAME + '/profile', {
            user: req.user,
        });
    },
    postRegister: function (req, res, next) {
        var newUserData = req.body;
        
        if (newUserData.password != newUserData.confirmPassword) {
            req.session.error = 'Passwords do not match!';
            res.redirect('/register');
        }
        else {
            newUserData.salt = encryption.generateSalt();
            newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
            users.create(newUserData, function (err, user) {
                if (err) {
                    if (!req.session.error) {
                        req.session.error = '';
                    }
                    
                    if (err.errors.username) {
                        
                        req.session.error += 'Incorrect username.Should be between 6 and 20 letters.Only letters, digits and underscore are allowed! ';
                    }
                    
                    if (err.errors.firstName) {
                        req.session.error += 'First Name is required! ';
                    }
                    
                    if (err.errors.lastName) {
                        req.session.error += 'Last Name is required! ';
                    }
                    
                    if (err.errors.email) {
                        req.session.error += 'email is required! ';
                    }
                    
                    res.redirect('/register');
                    return;
                }
                
                req.logIn(user, function (err) {
                    if (err) {
                        req.session.error = 'Incorrect user name and/or password!';
                        res.redirect('/login');
                    }
                    else {
                        res.redirect('/');
                    }
                })
            });
        }
    },
    getLogin: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    }
};
﻿var passport = require('passport');

module.exports = {
    login: function (req, res, next) {
        var auth = passport.authenticate('local', function (err, user) {
            console.log(user);
            if (err) {
                return next(err);
            }
            
            if (!user) {
                res.send({ success: false }); // TODO:
            }
            
            req.logIn(user, function (err) {
                if (err) {
                    return next(err);
                }
                
                res.redirect('/');
            });
        });
        
        auth(req, res, next);
    },
    logout: function (req, res, next) {
        req.logout();
        res.redirect('/');
    },
    isAuthenticated: function (rea, reg, next) {
        if (!(req.isAuthenticated())) {
            res.redirect('/');
        } else {
            next();
        }
    }
};
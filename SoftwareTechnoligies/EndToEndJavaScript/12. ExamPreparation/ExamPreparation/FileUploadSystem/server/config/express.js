﻿var express = require('express'),
    bodyParser = require('body-parser'),
    cookieParser = require('cookie-parser'),
    session = require('express-session'),
    busboy = require('connect-busboy'),
    passport = require('passport');

module.exports = function (app, config) {
    app.set('view engine', 'jade');
    app.set('views', config.roothPath + '/server/views');
    app.use(cookieParser());
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({ extended: true }));
    app.use(busboy({ immediate: false }));
    app.use(session({
        secret : 'magic unicorns',
        resave: true,
        saveUninitialized: true
    }));
    app.use(passport.initialize());
    app.use(passport.session());
    app.use(express.static('public'));
    app.use(function (req, res, next) {
        if (req.session.error) {
            var message = req.session.error;
            req.session.error = undefined;
            app.locals.errorMessage = message;
        } else {
            app.locals.errorMessage = undefined;
        }
        
        next();
    });
};
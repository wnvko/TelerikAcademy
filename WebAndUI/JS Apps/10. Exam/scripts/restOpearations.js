/// <reference path="libs/jquery-2.1.1.js" />
/// <reference path="libs/q.js" />
/// <reference path="libs/require.js" />

define(['jQuery', 'Q'], function ($, q) {
    'use strict';
    var RestOperations = (function () {
        function RestOperations(params) {
        };

        //var url = 'http://localhost:3000/';
        var url = 'http://jsapps.bgcoder.com/';

        RestOperations.prototype.GETpost = function (params, succes, error) {
            $.ajax({
                url: url + 'post' + params
            })
            .done(succes)
            .fail(error);
        };

        RestOperations.prototype.REGuser = function (user, succes, error) {
            $.ajax({
                url: url + 'user',
                type: 'POST',
                timeout: 5000,
                data: user,
            })
            .done(succes)
            .fail(error);
        };

        RestOperations.prototype.LOGuser = function (user, succes, error) {
            $.ajax({
                url: url + 'auth',
                type: 'POST',
                timeout: 5000,
                data: user,
            })
            .done(succes)
            .fail(error);
        }

        RestOperations.prototype.LOGout = function (user, succes, error) {
            $.ajax({
                url: url + 'auth',
                type: 'PUT',
                timeout: 5000,
                data: user,
            })
            .done(succes)
            .fail(error);
        }


        return RestOperations;
    }());

    return RestOperations;
});
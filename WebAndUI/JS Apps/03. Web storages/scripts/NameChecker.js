/// <reference path="require.js" />
/// <reference path="jquery-2.1.1.min.js" />
'use strict';

define(['Cookies'], function (cookies) {
    var NameChecker = (function () {
        function NameChecker(name) {
            this.name = name || ' ';
        }

        var myCookie = new cookies();
        myCookie.createCookies('milko', 'test', 1);
        console.log(myCookie);

        return NameChecker;
    }());

    return NameChecker;
});
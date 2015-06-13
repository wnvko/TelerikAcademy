/// <reference path="require.js" />
/// <reference path="cookies.js" />
/// <reference path="jquery-2.1.1.min.js" />

define(['Cookies'], function (cookies) {
    'use strict';
    var NameChecker = (function () {
        function NameChecker(name, tries) {
            this.name = 'SandR:' + name || ' ';
            this.tries = tries || 0;

            if (this.name && this.name !== ' ') {
                var myCookie = new cookies();
                myCookie.createCookies(this.name, this.tries, 1);
            }
        }

        return NameChecker;
    }());

    return NameChecker;
});
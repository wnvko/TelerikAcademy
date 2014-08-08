/// <reference path="libs/require.js" />

define([], function () {
    var Cookies = (function () {

        function Cookies() {

        };

        if (!String.prototype.startsWith) {
            String.prototype.startsWith = function (str) {
                if (this.length < str.length) {
                    return false;
                }
                for (var i = 0; i < str.length; i++) {
                    if (this[i] !== str[i]) {
                        return false;
                    }
                }
                return true;
            }
        }

        Cookies.prototype.readCookies = function (name) {
            var allCookiess = document.cookie.split(";");
            for (var i = 0; i < allCookiess.length; i++) {
                var Cookies = allCookiess[i];
                var trailingZeros = 0;
                for (var j = 0; j < Cookies.length; j++) {
                    if (Cookies[j] !== " ") {
                        break;
                    }
                }
                Cookies = Cookies.substring(j);
                if (Cookies.startsWith(name + "=")) {
                    return Cookies;
                }
            }
        }

        Cookies.prototype.createCookies = function (name, value, days) {
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                var expires = "; expires=" + date.toGMTString();
            } else var expires = "";
            document.cookie = name + "=" + value + expires + "; path=/";
        }

        Cookies.prototype.removeCookies = function (name) {
            createCookies(name, "", -1);
        }

        return Cookies;
    }());

    return Cookies;
});




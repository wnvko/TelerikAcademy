/// <reference path="lib/jquery-2.1.1.js" />
/// <reference path="lib/require.js" />
(function () {
    requirejs.config({
        paths: {
            'jQuery': 'libs/jquery-2.1.1',
            'Main': 'main',
            'Random': 'randomNumberGetter',
            'FindNumber': 'findNumber',
            'NameChecker': 'nameChecker',
            'Cookies': 'cookies',
            'GetHighScores': 'getHighScores',
        },
        shim: {
            'jQuery': {
                exports: '$'
            }
        }
    });

    require(['Main', 'Random'], function (Main, rnd) {
        Main();
    });
}());
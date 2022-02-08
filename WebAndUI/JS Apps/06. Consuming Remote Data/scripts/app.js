/// <reference path="students/main.js" />
(function () {
    'use strict';
    require.config({
        paths: {
            'jquery': 'libs/jquery-2.1.4',
            'q': 'libs/q',
            'main': 'students/main',
            'api': 'students/studentsAPI'
        }
    });

    require(['jquery', 'q', 'main', 'api'], function ($, q, main, api) {
        var mainApp = new main();
    });
}());
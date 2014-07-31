/// <reference path="libs/handlebars-v1.3.0.js" />
/// <reference path="libs/jquery-2.1.1.js" />
/// <reference path="libs/require.js" />

define(['jQuery', 'Handlebars'], function ($, handlebars) {
    'use strict';
    var UI = (function () {
        function UI(params) {
        };

        UI.prototype.Post = function (posts) {
            var $container = $('#post-window'),
                $data = $('<dl>'),
                userName,
                postDate,
                title,
                body;

            for (var i = 0, len = posts.length; i < len; i++) {
                userName = posts[i].user.username;
                postDate = posts[i].postDate;
                title = posts[i].title;
                body = posts[i].body;
                $data.append($('<dt>').html(userName + ' said at ' + postDate));
                $data.append($('<dd>').append($('<h5>').html(title)).append($('<p>').html(body)));
            };
            $container.html('');
            $container.append($data);
            //var a = $('#post-window').html('<p>' + JSON.stringify(posts) + '</p>');

            //var postTemplate = hbars.Compile($('#postUI').html());
            //var $('#post-window').html(postTemplate({
            //    posts: posts
            //}));
        };

        return UI;
    }());

    return UI;
});
//POST
//Body: { "user": "USER_NAME", 
//        "text": "MESSAGE_TEXT"}

//GET
/// <reference path="jquery-2.1.1.js" />
/// <reference path="sammy/sammy.js" />

(function ($) {
    var url = 'http://crowd-chat.herokuapp.com/posts';

    var app = $.sammy('#main', function () {

        this.get('#/', function (context) {
            this.load(url)
            .then(function (items) {
                var $main = $('#main').append('<ul>');
                items = $.parseJSON(items);
                for (var i = 0, len = items.length; i < len; i++) {
                    $main.append($('<li>').html(items[i].by + ' said: ' + items[i].text));
                }
            });
        });
    });

    $(function () {
        app.run('#/');
    });

})(jQuery);
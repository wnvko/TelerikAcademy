/// <reference path="jquery-2.1.1.min.js" />

$(document).ready(function () {
    var $container = $('#container'),
        $storage = $('#storage');

    $('#left').on('click', getPrevious);
    $('#right').on('click', getNext);
    $('.navigation').mouseover(showArrow);
    $('.navigation').mouseout(hideArrow);


    function getPrevious() {
        $storage.prepend($container.children());
        $container.prepend($storage.children().last());
    }

    function getNext() {
        $storage.append($container.children());
        $container.prepend($storage.children().first());
    }

    function showArrow() {
        console.log($(this));
        $(this).children().show();
    }

    function hideArrow() {
        console.log($(this));
        $(this).children().hide();
    }
})
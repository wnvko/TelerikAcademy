/// <reference path="jquery-2.1.1.min.js" />

$('#befor').on('click', function () {
    $('<div />', {
        text: 'Added befor'
    }).prependTo($('#anchor'))
});

$('#after').on('click', function () {
    $('<div />', {
        text: 'Added after'
    }).appendTo($('#anchor'))
});
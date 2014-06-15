/// <reference path="jquery-2.1.1.min.js" />

$(document).ready(function () {
    $('input').on('change', function () {
        $('body').css('background-color', $('input').val());
    })
})
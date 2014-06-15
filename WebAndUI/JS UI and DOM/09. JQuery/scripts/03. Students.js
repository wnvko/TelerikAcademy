/// <reference path="jquery-2.1.1.min.js" />

$(document).ready(function () {

    $('#add-student').on('click', function () {
        var firstName = $('#firstName').val(),
            lastName = $('#lastName').val(),
            grade = $('#grade').val(),
            $newTableRow = $('<tr />');

        $newTableRow.append($('<td />').text(firstName));
        $newTableRow.append($('<td />').text(lastName));
        $newTableRow.append($('<td />').text(grade));

        $('#students-list').append($newTableRow);

        $('#firstName').val(''),
        $('#lastName').val(''),
        $('#grade').val('');

    })
})
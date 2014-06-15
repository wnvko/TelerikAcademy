/// <reference path="jquery-2.1.1.min.js" />

(function ($) {
    $.fn.dropdown = function () {
        var $this = $(this);

        var $dropdownList = $('#dropdown').hide(),
            $container = $('<div />').addClass('dropdown-list-container'),
            $newUlList = $('<ul />').addClass('dropdown-list-options');


        // not workink. Do not iterate each items - will be happy to know why this is not working
        //$dropdownList.each(function (index) {
        //    $newUlList.append($('<li />')
        //        .text($(this).text())
        //        .addClass('dropdown - list - options')
        //        .attr('data-value', index));
        //});

        for (var i = 0, length = $('#dropdown option').length; i < length; i++) {
            $newUlList.append($('<li />')
                .text($dropdownList.children().eq(i).text())
                .addClass('dropdown-list-options')
                .attr('data-value', i));
        }
        $container.append($newUlList);
        $('body').append($container);

        $newUlList.on('click', 'li', function () {
            if ($(this).css('color') == 'rgb(255, 0, 0)') {
                $(this).css('color', '');
                $dropdownList
                    .find('[value=' + (parseInt($(this).attr('data-value')) + 1) + ']')
                    .removeAttr('selected');
            } else {
                $(this).css('color', 'rgb(255, 0, 0)');
                $dropdownList
                    .find('[value=' + (parseInt($(this).attr('data-value')) + 1) + ']')
                    .attr('selected', 'selected');
            }
        })

        return this;
    };
}(jQuery));
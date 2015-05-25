/// <reference path="jquery.min.js" />
$.fn.tabs = function () {
    var $this = $(this),
        $tabItems = $('.tab-item'),
        $tabItemTitles = $('.tab-item-title'),
        $tabItemsContent = $('.tab-item-content'),
        $selectedItem = $('.selected');

    $this.css({
        'border': '2px solid black',
        'border-radius': '10px',
        'width': '1004px',
        'height': '500px',
        'position': 'relative',
        'background-color': '#aaa',
    });

    $tabItemsContent.css({
        'display': 'none',
        'position': 'absolute',
        'top': '60px',
        'margin': '0 20px',
    });

    $tabItemTitles.css({
        'display': 'inline-block',
        'border-left': '1px solid black',
        'border-bottom': '1px solid black',
        'width': '200px',
        'height': '20px',
        'float': 'left',
        'padding': '15px 0',
        'text-align': 'center',
        'background-color': '#fff',
    });
    $tabItemTitles.first().toggleClass('selected');
    $tabItemTitles.first().css({
        'border-left': 'none',
        'border-bottom': 'none',
        'border-top-left-radius': '8px',
        'background-color': '#aaa',
    });
    $tabItemTitles.last().css({
        'border-top-right-radius': '8px',
    });
    $tabItemTitles.first().siblings('.tab-item-content').css({
        'display': 'block',
    });

    $selectedItem.css({
    });

    $this.on('click', '.tab-item-title', onItemClick);

    function onItemClick() {
        var $this = $(this),
            $oldSelected = $('.selected');

        $oldSelected.toggleClass('selected');
        $oldSelected.css({
            'border-bottom': '1px solid black',
            'background-color': '#fff',
        });
        $oldSelected.siblings('.tab-item-content').css({
            'display': 'none',
        });

        $this.toggleClass('selected').css({
            'border-bottom': 'none',
            'background-color': '#aaa',
        });
        $this.siblings('.tab-item-content').css({
            'display': 'block',
        });
    };
};
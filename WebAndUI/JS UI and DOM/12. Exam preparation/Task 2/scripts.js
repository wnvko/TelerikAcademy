/// <reference path="jquery.min.js" />
$.fn.tabs = function () {
    var $container = $(this),
        $tabItemContent = $container.find('.tab-item-content'),
        $tabItem = $container.find('.tab-item');

    $container.addClass('tabs-container');
    $tabItemContent.hide();
    $tabItemContent.first().show();
    $tabItem.first().toggleClass('current');

    $tabItem.click(showContent);
};

function showContent(e) {
    var $this = $(this);

    $this.parent().find('.current').toggleClass('current');
    $this.parent().find('.tab-item-content').hide();
    $this.toggleClass('current');
    $this.find('.tab-item-content').show();
}
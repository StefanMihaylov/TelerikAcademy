/// <reference path="jquery.min.js" />
$.fn.tabs = function () {
    var $this = $(this)
    $this.addClass('tabs-container');

    var $tabItems = $this.find('.tab-item');
    $tabItems.find('.tab-item-content').hide();
    $tabItems.first().addClass('current').find('.tab-item-content').show();

    $tabItems.find('.tab-item-title').on('click', function () {
        $tabItems.removeClass('current').find('.tab-item-content').hide();
        $(this).parent().addClass('current').find('.tab-item-content').show();
    });
};
/// <reference path="../libs/jquery-2.1.1.min.js" />
(function ($) {
    $.fn.messageBox = function () {
        var $this = $(this).hide();

        return {
            success: function (text) {
                if ($this.filter(':visible').length === 0) {
                    $this.css('background-color', 'green')
                        .css('color', 'black')
                        .text(text)
                        .fadeIn(1000)
                        .delay(3000)
                        .fadeOut(1000);
                }
                return $this;

            },
            error: function (text) {
                if ($this.filter(':visible').length === 0) {
                    $this.css('background-color', 'red')
                        .css('color', 'yellow')
                        .text(text)
                        .fadeIn(1000)
                        .delay(3000)
                        .fadeOut(1000);
                }
                return $this;
            }
        }
    }
})(jQuery);
/// <reference path="../libs/jquery-2.1.1.min.js" />
(function ($) {
    $.fn.dropdown = function () {
        var $this = this;
        $this.hide();

        var $divElement = $('<div/>')
            .addClass('dropdown-list-container')
            .insertAfter($this);
        var $ulElement = $('<ul/>')
            .addClass('dropdown-list-options')
            .appendTo($divElement);

        $('<img>').attr('src', 'imgs/arrow-big-down-512.png')
            .addClass('dropdown-list-arrow')
            .attr('width', '15px')
            .attr('height', '20px')
            .appendTo($divElement)
            .on('click', openDropdown);

        var $selectChildren = $this.children();
        for (var i = 0; i < $selectChildren.length; i++) {
            var $currentOption = $($selectChildren[i]);
            $('<li/>')
                .attr('data-value', $currentOption.val() - 1)
                .addClass('list-item')
                .text($currentOption.text())
                .appendTo($ulElement);
        }

        var $listItems = $ulElement.children('.list-item').hide();;
        var $firstLi = $listItems.first();
        var $selectedLi = $firstLi.clone(true)
                        .addClass('dropdown-list-options')
                        .addClass('selected')
                        .removeClass('list-item')
                        .show()
                        .insertBefore($firstLi)
                        .on('click', openDropdown);

        $listItems.on('click', function () {
            var $this = $(this);
            $listItems.removeClass('selected').hide();
            $this.addClass('selected');
            $selectedLi.attr('data-value', $this.attr('data-value'))
                    .text($this.text());

            $selectChildren.attr('selected', false);
            var value = parseInt($this.attr('data-value')) + 1;
            $selectChildren.filter('[value =' + value + ']').attr('selected', true);
        });

        $firstLi.click();

        function openDropdown() {
            if ($listItems.filter(':visible').length) {
                $listItems.hide();
            }
            else {
                $listItems.show();
            }
        }

        return $this;
    }
})(jQuery)
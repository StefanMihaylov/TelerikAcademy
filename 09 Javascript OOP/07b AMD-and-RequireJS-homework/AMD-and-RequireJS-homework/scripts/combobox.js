define(['jquery', 'handlebars'], function ($) {
    var combobox = function (containerID) {
        var render = function (templateID, data) {
            var templateHtml = $(templateID).html();
            var template = Handlebars.compile(templateHtml);
            $(containerID).html(template({
                data: data
            }));

            var $container = $(containerID);
            var $pictures = $container.find('.picture');            

            $container.on('click', '.picture', function () {
                var $this = $(this);
                if ($this.hasClass('selected')) {
                    $this.removeClass('selected');
                    $pictures.removeClass('invisible');
                }
                else {
                    $pictures.addClass('invisible');
                    $this.addClass('selected').removeClass('invisible');
                }
            });

            $pictures.first().click();
        }

        return {
            render: render
        }
    }

    return combobox;
});
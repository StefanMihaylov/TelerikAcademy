/// <reference path="jquery.min.js" />
$.fn.gallery = function (columns) {
    var $this = $(this);
    var cols = columns || 4;
    $this.addClass('gallery');

    var $selected = $this.find('.selected');
    var $currentSelected = $selected.find('#current-image');
    var $nextSelected = $selected.find('#next-image');
    var $prevSelected = $selected.find('#previous-image');

    var $galleryList = $this.find('.gallery-list');
    var $container = $galleryList.find('.image-container');

    var containerPadding = parsePixels($container.css('padding'));
    var containerMargin = parsePixels($container.css('margin'));
    var containerWidth = ($container.width() + 2 * (containerPadding + containerMargin)) * cols;
    $this.css('width', containerWidth);

    $galleryList.on('click', 'img', function () {
        if (isSelected()) {
            changeSources($(this));
            $selected.show();
            $galleryList.addClass('blurred');
        }
    });

    $currentSelected.on('click', function () {
        $selected.hide();
        $galleryList.removeClass('blurred');
    }).click();

    $nextSelected.on('click', function () {
        onClickChangeNextImage(this);
    });

    $prevSelected.on('click', function () {
        onClickChangeNextImage(this);
    });

    function onClickChangeNextImage(element) {
        var $this = $(element);
        var $clickedSource = $this.attr('src');
        var $listElement = $galleryList.find('[src="' + $clickedSource + '"]');
        changeSources($listElement);
    }

    function parsePixels(string) {
        return parseInt(string.substr(0, string.length - 2), 10);
    }

    function isSelected() {
        return $selected.filter(':visible').length === 0;
    }

    function changeSources(clicked) {
        var $this = $(clicked);

        var $next = $this.parent().next();
        if ($next.length === 0) {
            $next = $container.first();
        }
        var $nextImg = $next.find('img');

        var $previous = $this.parent().prev();
        if ($previous.length === 0) {
            $previous = $container.last();
        }
        var $previousImg = $previous.find('img');

        $currentSelected.attr('src', $this.attr('src'));
        $nextSelected.attr('src', $nextImg.attr('src'));
        $prevSelected.attr('src', $previousImg.attr('src'));
    }

    return $this;
};
/// <reference path="libs/jquery-2.1.1.min.js" />

// old version of the script that uses show() and hide() over DOM elements
$(document).ready(function () {
    var pictures = [{
        image: 'images/IMG100_0670.JPG',
        title: 'Popovo ezero lake, Pirin mountain'
    }, {
        image: 'images/IMG100_143.JPG',
        title: 'Kademliisko praskalo waterfall, Balkan range mountain'
    }, {
        image: 'images/IMG101_2447.jpg',
        title: 'Sinanica lake and Sinanica hut, Pirin mountain'
    }, {
        image: 'images/IMG101_2516.jpg',
        title: 'Sinanica peak, Pirin mountain'
    }, {
        image: 'images/IMG101_4824.jpg',
        title: 'Ribni ezera lakes, Rila mountain'
    }, {
        image: 'images/P1150508.JPG',
        title: 'Kamenica peak and Tevno ezero lake, Pirin mountain'
    }];

    // create DOM structure
    for (var i = 0; i < pictures.length; i++) {
        $('<figure/>')
            .append($('<img/>')
                .attr({
                    'src': pictures[i].image,
                    width: "500",
                    height: "334",
                    alt: pictures[i].title
                })
            )
            .append($('<figcaption/>').text(pictures[i].title))
            .appendTo('#slider').hide();
    }

    var $pictures = $('#slider').children();
    $pictures.first().show();

    var startSlideShow;

    $('#navigation button').hover(
    function () {
        $(this).css('background-color', 'darkgray');
    },
    function () {
        $(this).css('background-color', '');
    });

    $('#next-btn').on('click', function () {
        showNext();
    }).on('hover', function () {
        $(this).css('background-color', 'darkgrey');
    });

    $('#prev-btn').on('click', function () {
        var $selected = $pictures.filter(':visible');
        $pictures.hide();
        var $prev = $selected.prev();
        if ($prev.length) {
            $prev.show();
        } else {
            $pictures.last().show();
        }
    });

    $('#slideshow-btn').on('click', function () {
        var $this = $(this);
        $this.toggleClass('selected');

        if ($this.filter('.selected').length) {
            startSlideShow = window.setInterval(showNext, 4000);
        } else {
            clearInterval(startSlideShow);
        }
    }).click();

    function showNext() {
        var $selected = $pictures.filter(':visible');
        $pictures.hide();
        var $next = $selected.next();
        if ($next.length) {
            $next.show();
        } else {
            $pictures.first().show();
        }
    }
})
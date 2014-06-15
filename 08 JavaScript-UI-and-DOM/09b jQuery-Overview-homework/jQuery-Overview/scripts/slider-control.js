/// <reference path="../libs/jquery-2.1.1.min.js" />

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

    var current = 0;
    // create DOM structure
    var $picture = $('<figure/>')
        .append($('<img/>')
            .attr({
                'src': pictures[current].image,
                width: "500",
                height: "334"
            })
        )
        .append($('<figcaption/>').text(pictures[current].title))
        .appendTo('#slider');

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
        current--;
        if (current < 0) {
            current = pictures.length - 1;
        }
        changePicture(current);
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
        current++;
        if (current >= pictures.length) {
            current = 0;
        }
        changePicture(current);
    }

    function changePicture(index) {
        var fadeTime = 500;
        $picture.fadeTo(fadeTime, 0.3, function () {

            $picture.find('img')
                    .attr('src', pictures[index].image);
            $picture.find('figcaption')
                    .text(pictures[index].title);
        }).fadeTo(fadeTime, 1.0);
    }
})
window.onload = function () {

    var initialRadius = 0,
        step = 60 / (2 * Math.PI),
        dotRaduis = 0.5,
        angleStep = 0.01,
        turns = 3;


    var paper = Raphael('spiral', 400, 350);

    var centerX = paper.width / 2,
        centerY = paper.height / 2,
        radius;

    var circle = paper.circle(centerX, centerY, dotRaduis).attr({
        fill: '#000000',
        stroke: '#000000'
    });

    for (var angle = 0; angle < turns * (2 * Math.PI) ; angle += angleStep) {

        radius = initialRadius + step * angle;
        var xCoord = centerX + radius * Math.cos(-angle);
        var yCoord = centerY + radius * Math.sin(-angle);

        paper.add(circle.clone().attr({
            cx: xCoord,
            cy: yCoord
        }));
    }
}
window.onload = function () {

    var paper = Raphael('logos', 1100, 218);


    // Telerik
    paper.rect(0, 0, 589, 218).attr({
        fill: '#FFFFFF',
        stroke: '#E0FFA3',
        'stroke-width': 5
    });

    paper.setStart();
    paper.path('M79 72 L62 56 L47 71 L46 71 L37 62 L62 37 L123 98 L123 99 L88 134 L53 99 L53 98 L114 37 L139 62 L130 71 L115 56 L114 56 L97 72').attr({
        fill: '#5CE600',
        stroke: 'none'
    });
    paper.path('M88 82 L104 98 L104 99 L88 115 L72 99 L72 98').attr({
        fill: '#FFFFFF',
        stroke: 'none'
    });
    paper.setFinish();

    paper.setStart();
    paper.text(155, 96, 'Telerik').attr({
        'font-size': 100,
        'font-family': 'Calibri, Arial',
        'text-anchor': 'start',
        'font-weight': 'bold'
    });

    paper.circle(452, 93, 10).attr({
        fill: '#FFFFFF',
        stroke: '#000000',
        'stroke-width': 3
    });

    paper.text(452, 94, 'R').attr({
        'font-size': 15,
        'font-weight': 'bold'
    });
    paper.setFinish();

    paper.text(170, 167, 'Develop Experiences').attr({
        'font-size': 40,
        'text-anchor': 'start'
    });

    // Youtube
    paper.text(630, 100, 'You').attr({
        'font-size': 110,
        'font-family': 'Arial narrow, Calibri, Arial',
        'text-anchor': 'start',
        'font-weight': 'bold',
        fill : '#4B4B4B'
    });

    paper.rect(810, 30, 260, 140, 50).attr({
        fill: '#EC2828',
        stroke: 'none'
    });

    paper.text(830, 100, 'Tube').attr({
        'font-size': 110,
        'font-family': 'Arial narrow, Calibri, Arial',
        'text-anchor': 'start',
        'font-weight': 'bold',
        fill: '#FFFFFF'
    });
}
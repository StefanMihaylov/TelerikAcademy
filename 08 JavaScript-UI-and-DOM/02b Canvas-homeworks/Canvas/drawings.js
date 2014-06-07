window.onload = function () {
    var canvas = document.getElementById('canvas-element');
    canvas.style.backgroundColor = 'rgb(50, 50, 50)';
    var content = canvas.getContext('2d');

    content.save();
    content.translate(20, 50);

    var headColour = 'rgb(144,200,215)';
    var headBorderColour = 'rgb(30,83,63)';
    var headBorderWidth = '2';
    var hatColour = 'rgb(57,102,147)';
    var hatBorder = 'black';

    content.fillStyle = headColour;
    content.strokeStyle = headBorderColour;
    content.lineWidth = headBorderWidth;

    // face
    content.beginPath();
    content.arc(100, 100, 55, 0, 2 * Math.PI);
    content.fill();
    content.stroke();

    // eyes    
    content.save();
    content.scale(1.5, 1);
    content.beginPath();
    content.arc(75, 80, 7, 0, 2 * Math.PI);
    content.stroke();
    content.beginPath();
    content.arc(45, 80, 7, 0, 2 * Math.PI);
    content.stroke();
    content.restore();

    //pupils
    content.save();
    content.scale(1, 2);
    content.fillStyle = headBorderColour;
    content.beginPath();
    content.arc(110, 40, 3, 0, 2 * Math.PI);
    content.fill();
    content.beginPath();
    content.arc(65, 40, 3, 0, 2 * Math.PI);
    content.fill();
    content.restore();

    // nose
    content.beginPath();
    content.moveTo(90, 80);
    content.lineTo(75, 110);
    content.lineTo(90, 110);
    content.stroke();

    // mouth
    content.save();
    content.beginPath();
    content.lineWidth = '1';
    content.rotate(10 * Math.PI / 180);
    content.scale(3, 0.8);
    content.arc(38, 140, 8, 0, 2 * Math.PI);
    content.stroke();
    content.restore();

    // hat
    content.fillStyle = hatColour;
    content.strokeStyle = hatBorder;

    content.save();
    content.beginPath();
    content.scale(4, 1);
    content.arc(25, 50, 15, 0, 2 * Math.PI);
    content.stroke();
    content.fill();
    content.restore();

    content.save();
    content.beginPath();
    content.scale(3, 1);

    content.moveTo(47, -20);
    content.lineTo(47, 36);
    content.arc(35, 36, 12, 0, Math.PI);
    content.lineTo(23, -20);
    content.stroke();
    content.fill();

    content.beginPath();
    content.arc(35, -20, 12, 0, 2 * Math.PI);
    content.stroke();
    content.fill();

    content.restore();

    // bicycle
    content.save();
    content.translate(10, 150);

    content.fillStyle = headColour;
    content.strokeStyle = 'rgb(58,143,163)';

    // wheels
    content.beginPath();
    content.arc(35, 200, 50, 0, 2 * Math.PI);
    content.stroke();
    content.fill();
    content.beginPath();
    content.arc(130, 200, 15, 0, 2 * Math.PI);
    content.stroke();
    content.beginPath();
    content.arc(250, 200, 50, 0, 2 * Math.PI);
    content.stroke();
    content.fill();

    // frame
    content.beginPath();
    content.moveTo(35, 200);
    content.lineTo(130, 200);
    content.lineTo(240, 130);
    content.lineTo(250, 200);
    content.lineTo(233, 80);
    content.lineTo(260, 50);
    content.lineTo(233, 80);
    content.lineTo(190, 100);
    content.lineTo(233, 80);
    content.lineTo(240, 130);
    content.lineTo(90, 130);
    content.lineTo(130, 200);
    content.lineTo(75, 104);
    content.lineTo(100, 104);
    content.lineTo(50, 104);
    content.lineTo(75, 104);
    content.lineTo(90, 130);
    content.closePath();
    content.stroke();

    content.beginPath();
    content.moveTo(120, 190);
    content.lineTo(105, 175);
    content.stroke();

    content.beginPath();
    content.moveTo(140, 210);
    content.lineTo(155, 225);
    content.stroke();

    // end bicycle
    content.restore();

    // House
    content.save();
    content.translate(350, 100);

    var houseColour = 'rgb(151, 91, 91)';
    var houseBorder = 'black';
    var houseWindow = 'black';

    content.fillStyle = houseColour;
    content.strokeStyle = houseBorder;

    content.fillRect(10, 10, 230, 180);
    content.strokeRect(10, 10, 230, 180);

    var windowWidth = 83;
    var windowHeight = 55;
    drawWindow(30, 30, windowWidth, windowHeight);
    drawWindow(140, 30, windowWidth, windowHeight);
    drawWindow(140, 110, windowWidth, windowHeight);

    // door
    var center = 70;
    var doorWidth = 30;
    content.beginPath();
    content.moveTo(center - doorWidth, 190);
    content.lineTo(center - doorWidth, 135);
    content.bezierCurveTo(center - 20, 110, center + 20, 110, center + doorWidth, 135);
    content.lineTo(center + doorWidth, 190);
    content.stroke();

    content.beginPath();
    content.moveTo(center, 190);
    content.lineTo(center, 115);
    content.stroke();

    content.beginPath();
    content.arc(center - doorWidth / 3, 170, 3, 0, 2 * Math.PI);
    content.stroke();
    content.beginPath();
    content.arc(center + doorWidth / 3, 170, 3, 0, 2 * Math.PI);
    content.stroke();

    // roof
    content.beginPath();
    content.moveTo( -20, 10);
    content.lineTo(125, -120);
    content.lineTo(270, 10);
    content.closePath();
    content.fill();
    content.stroke();

    // chimney
    content.save();

    content.fillRect(167, -90, 30, 70);
    content.strokeRect(167, -90, 30, 70);
    content.strokeStyle = houseColour;
    content.beginPath();
    content.moveTo(168, -20);
    content.lineTo(196, -20);
    content.stroke();
    content.strokeStyle = houseBorder;

    content.beginPath();
    content.scale(3.25, 1);
    content.arc(56, -90, 4, 0, 2 * Math.PI);
    content.stroke();
    content.fill();
    content.restore();

    // end house
    content.restore();

    function drawWindow(startX, startY, width, heigth) {
        content.save();
        content.fillStyle = houseWindow;
        content.strokeStyle = houseColour;

        content.fillRect(startX, startY, width, heigth);
        var centerX = startX + width / 2;
        var centerY = startY + heigth / 2;

        content.beginPath();
        content.moveTo(centerX, startY);
        content.lineTo(centerX, startY + heigth);
        content.stroke();

        content.beginPath();
        content.moveTo(startX, centerY);
        content.lineTo(startX + width, centerY);
        content.stroke();

        content.restore();
    }
};
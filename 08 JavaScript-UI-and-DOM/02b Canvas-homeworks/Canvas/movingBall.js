window.onload = function () {
    var canvas = document.getElementById('canvas-element'),
        content = canvas.getContext('2d'),
        width = canvas.clientWidth,
        height = canvas.clientHeight;

    canvas.style.backgroundColor = 'gray';

    // initial states and ball settings
    var ballColour = 'green',
        ballRaduis = 18,
        angle = 43,
        step = 3,
        maxRandomRebound = 2,
        positionX = ballRaduis,
        positionY = ballRaduis,
        displayRandomRebound = 0;

    function drawBall(XCoord, YCoord) {
        content.fillStyle = ballColour;
        content.beginPath();
        content.arc(XCoord, YCoord, ballRaduis, 0, 2 * Math.PI);
        content.fill();
        content.stroke();
    }

    function moveBall() {
        content.clearRect(0, 0, width, height);
        content.strokeRect(0, 0, width, height);

        drawBall(positionX, positionY);

        positionX += step * Math.cos(angle * Math.PI / 180);
        positionY += step * Math.sin(angle * Math.PI / 180);

        var bottomContactPoint = positionY + ballRaduis,
            upContactPoint = positionY - ballRaduis,
            rightContactPoint = positionX + ballRaduis,
            leftContactPoint = positionX - ballRaduis;

        // random correction of the angle
        var randomRebound = (Math.random() * 2 * maxRandomRebound) - maxRandomRebound;

        // Change direction. I am not sure if this calculations are correct, but it works :)
        if (upContactPoint <= 0 || bottomContactPoint >= height) {
            angle = 360 - angle + randomRebound;
            displayRandomRebound = randomRebound;
        }

        if (leftContactPoint <= 0 || rightContactPoint >= width) {
            angle = 180 - angle + randomRebound;
            displayRandomRebound = randomRebound;
        }

        angle %= 360;

        // print some results
        /*document.getElementById('angle').innerHTML =
           'Angle: ' + parseInt(angle * 100) / 100 +
           '; Random: ' + parseInt(displayRandomRebound * 100) / 100; */

        // 
        setTimeout(moveBall, 10);
    }

    moveBall();
};
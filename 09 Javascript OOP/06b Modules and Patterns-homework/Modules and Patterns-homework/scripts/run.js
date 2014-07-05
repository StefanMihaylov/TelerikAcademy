
// Warning: Most of OOP principes and design patterns in this project are violated intentionally :)

var game = (function () {
    var canvas = new Canvas(600, 400, 10, 15);

    var snake = new Snake(canvas).draw();
    snake.attachEventHandlers(document);

    function run() {
        canvas.redraw();

        if (snake.move() !== false) {
            var speed = 100 - canvas._score;
            if (speed <= 20) {
                speed = 20;
            }
            setTimeout(run, speed);
        } else {
            canvas.drawGameOver();
        }
    }

    run();

}());
var Canvas = (function () {

    var randomValue = function (min, max, step) {
        return Math.floor(Math.random() * ((max - min) / step) + (min / step)) * step;
    }

    var getRandomPosition = function () {
        var borderFreeZone = 4 * this._cellSize;
        return {
            x: randomValue(borderFreeZone, this._width - borderFreeZone, this._cellSize),
            y: randomValue(borderFreeZone, this._height - borderFreeZone, this._cellSize)
        }
    }

    var Apple = (function () {
        var changePosition = function () {
            var applePosition = getRandomPosition.call(this._canvas);
            this._x = applePosition.x;
            this._y = applePosition.y;
        }

        function Apple(canvas) {
            this._canvas = canvas;
            this._x;
            this._y;
            changePosition.call(this);

        }

        Apple.prototype.changePosition = changePosition;

        Apple.prototype.draw = function () {
            new Rect(this._x, this._y, 'red', this._canvas).draw();
        }

        return Apple;
    })();

    var generateObstaclesPosition = function (obstacleCount) {
        var obstacles = [];
        for (var i = 0; i < obstacleCount; i++) {
            obstacles.push(getRandomPosition.call(this));
        }
        return obstacles;
    }

    var drawObstacles = function () {
        for (var i = 0, len = this._obstacles.length; i < len; i++) {
            var x = this._obstacles[i].x;
            var y = this._obstacles[i].y;
            new Rect(x, y, 'black', this).draw();
        }
    }

    var init = function () {
        var canvas = document.createElement('canvas');
        canvas.width = this._width;
        canvas.height = this._height + 50;
        canvas.style.backgroundColor = this._background;
        canvas.style.border = '10px solid black';
        document.body.appendChild(canvas);
        this._content = canvas.getContext('2d');
    };

    function Canvas(width, height, cellSize, obstacleCount) {
        this._width = width;
        this._height = height;
        this._cellSize = cellSize;
        this._background = 'grey';
        this._content;
        this._obstacles = generateObstaclesPosition.call(this, obstacleCount);
        this._apple = new Apple(this);
        this._score = 0;
        init.call(this);
    }

    var redraw = function () {
        this._content.clearRect(0, 0, this._width, this._height);
        drawObstacles.call(this);
        this._apple.draw();

        this._content.fillStyle = '#222';
        this._content.fillRect(0, this._height, this._width, 50);
        this._content.fillStyle = 'white';
        this._content.font = "30px Arial";
        this._content.fillText('Score: ', 50, this._height + 35);
        this._content.fillText(this._score, 140, this._height + 35);
    }

    var checkCrashed = function (point) {
        var len = this._obstacles.length;
        for (var i = 0; i < len; i++) {
            var obstacle = this._obstacles[i];
            if (obstacle.x === point.x && obstacle.y === point.y) {
                return true;
            }
        }
        return false;
    }

    var drawGameOver = function () {
        this._content.fillStyle = 'Red';
        this._content.font = '40px Arial';
        this._content.fillText('Game Over', this._width / 2, this._height + 40);
    }

    Canvas.prototype = {
        redraw: redraw,
        checkCrashed: checkCrashed,
        drawGameOver: drawGameOver
    }

    return Canvas;
})();

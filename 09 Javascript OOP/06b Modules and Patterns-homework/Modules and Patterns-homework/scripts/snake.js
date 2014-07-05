/// <reference path="rectangle.js" />
/// <reference path="canvas.js" />
var Snake = (function () {

    var init = function (count) {
        var body = [];
        var initX = 0;
        var initY = this._canvas._height / 2;
        for (var i = 0; i < count; i++) {
            body.push({
                x: initX + i * this._canvas._cellSize,
                y: initY
            });
        }

        return body.reverse();
    }

    function Snake(Canvas) {
        this._canvas = Canvas;
        this._body = init.call(this, 5, Canvas);
        this._direction = 'right';
        this._x = this._body[0].x;
        this._y = this._body[0].y;
    }

    var checkEatApple = function (newHead) {
        if (newHead.x === this._canvas._apple._x && newHead.y === this._canvas._apple._y) {
            this._canvas._score += this._body.length;
            this._body.unshift(newHead);
            this.draw();
            this._canvas._apple.changePosition(this._canvas);            
        }
    }

    var tailEaten = function (newHead) {
        var len = this._body.length;
        for (var i = 0; i < len; i++) {
            var block = this._body[i];
            if (newHead.x === block.x && newHead.y === block.y) {
                return true;
            }
        }

        return false;
    }

    Snake.prototype.draw = function () {
        var len = this._body.length;
        for (var i = 0; i < len; i++) {
            var position = this._body[i];
            if (i == 0) {
                new Rect(position.x, position.y, 'darkgreen', this._canvas).draw();
            }
            else {
                new Rect(position.x, position.y, 'green', this._canvas).draw();
            }
        }

        return this;
    };

    Snake.prototype.move = function () {
        var newHead = {
            x: this._body[0].x,
            y: this._body[0].y
        };

        // next step
        switch (this._direction) {
            case 'right':
                newHead.x += this._canvas._cellSize;
                break;
            case 'left':
                newHead.x -= this._canvas._cellSize;
                break;
            case 'down':
                newHead.y += this._canvas._cellSize;
                break;
            case 'up':
                newHead.y -= this._canvas._cellSize;
                break;
        }

        // move through walls
        if (newHead.x >= this._canvas._width) {
            newHead.x = 0;
        }
        else if (newHead.x < 0) {
            newHead.x = this._canvas._width;
        }

        if (newHead.y >= this._canvas._height) {
            newHead.y = 0;
        }
        else if (newHead.y < 0) {
            newHead.y = this._canvas._height;
        }  

        // crash on obstacles, eat tail and eat apple
        var isCrashed = this._canvas.checkCrashed(newHead);
        var isTailEaten = tailEaten.call(this, newHead);
        checkEatApple.call(this, newHead);

        if (!isCrashed && !isTailEaten) {
            this._body.pop();
            this._body.unshift(newHead);
            this.draw();
        }
        else {
            this.draw();
            return false;
        }

        return this;
    };

    Snake.prototype.attachEventHandlers = function (element) {
        var self = this;
        element.addEventListener('keydown', function (event) {
            event = event || window.event;
            var keyCode = event.keyCode;

            if (keyCode === 37 && self._direction !== 'right') // left
                self._direction = 'left';

            if (keyCode === 38 && self._direction !== 'down') // up
                self._direction = 'up';

            if (keyCode === 39 && self._direction !== 'left') // right
                self._direction = 'right';

            if (keyCode === 40 && self._direction !== 'up') // down
                self._direction = 'down';
        }, false);
    };

    return Snake;

}());

var Rect = (function () {
    function Rect(x, y, colour,canvas) {
        this._x = x;
        this._y = y;
        this._colour = colour;
        this._canvas = canvas;
    }

    Rect.prototype.draw = function () {
        this._canvas._content.fillStyle = this._colour;
        this._canvas._content.fillRect(this._x, this._y, this._canvas._cellSize, this._canvas._cellSize);
        return this;
    }

    return Rect;
}());
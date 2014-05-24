function IsInCircleAndRectangule() {
    var x = jsConsole.read("#x"),
        y = jsConsole.read("#y"),
        resultCircle,
        resultRectangle,
        expression,
        result;

    if (isNaN(x) || x === null || x === "" ||
        isNaN(y) || y === null || y === "") {
        jsConsole.writeLine("Entered value is not a number!");
    }
    else {
        resultCircle = ((x - 1) * (x - 1)) + ((y - 1) * (y - 1))  <= 9;
        resultRectangle = x >= -1 && x <= 5 && y >= -1 && y <= 1;
        expression = resultCircle && !resultRectangle;

        result = expression ? "is" : "isn't";
        jsConsole.writeLine("The point (" + x + ", " + y + ") " + result + " inside the preset area.");
    }
}
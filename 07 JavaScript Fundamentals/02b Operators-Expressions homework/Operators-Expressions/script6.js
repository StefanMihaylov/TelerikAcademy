function IsInCircle() {
    var x = jsConsole.read("#x"),
        y = jsConsole.read("#y"),
        expression,
        result;

    if (isNaN(x) || x === null || x === "" ||
        isNaN(y) || y === null || y === "") {
        jsConsole.writeLine("Entered value is not a number!");
    }
    else {
        expression = (x * x + y * y) <= 25;
        result = expression ? "is" : "isn't";

        jsConsole.writeLine("Point (" + x + "," + y + ") " + result + " inside the circle K((0,0),5)");
    }
}
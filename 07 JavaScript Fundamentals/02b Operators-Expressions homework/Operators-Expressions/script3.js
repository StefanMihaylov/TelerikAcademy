function AreaCalculation() {
    var width = jsConsole.read("#width"),
        height = jsConsole.read("#height");

    if (isNaN(width) || width === null || width === "" ||
        isNaN(height) || height === null || height === "") {
        jsConsole.writeLine("Entered value is not a number!");
    }
    else {

        if (width <= 0) {
            jsConsole.writeLine("Width cannot be negative or zero!");
            return;
        }
        if (height <= 0) {
            jsConsole.writeLine("Height cannot be negative or zero!");
            return;
        }

        jsConsole.writeLine(width + "x" + height + " rectangule's area is " + width * height);
    }
}
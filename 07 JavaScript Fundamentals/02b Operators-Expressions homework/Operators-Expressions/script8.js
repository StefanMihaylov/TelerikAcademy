function TrapezoidArea() {
    var a = parseFloat(jsConsole.read("#a")),
        b = parseFloat(jsConsole.read("#b")),
        h = parseFloat(jsConsole.read("#h")),
        result;

    if (isNaN(a) || a === null || a === "" ||
        isNaN(b) || b === null || b === "" ||
        isNaN(h) || h === null || h === "") {
        jsConsole.writeLine("Entered value is not a number!");
    }
    else {

        if (a > 0 && b > 0 && h > 0) {
            result = (a + b) * h / 2;
            jsConsole.writeLine("Trapezoid's area is " + result);
        }
        else {
            jsConsole.writeLine("Trapezoid's dimentions must be positive");
        }
        ;
    }
}
function SolveQuadraticEquation() {
    var a = parseFloat(jsConsole.read("#number1")),
        b = parseFloat(jsConsole.read("#number2")),
        c = parseFloat(jsConsole.read("#number3")),
        discriminant,
        root1,
        root2;

    if (isNaN(a) || a === null || a === "" ||
            isNaN(b) || b === null || b === "" ||
            isNaN(c) || c === null || c === "") {
        jsConsole.writeLine("The entered value is not a number!");
    }
    else {
        discriminant = b * b - 4 * a * c;

        if (discriminant > 0) {
            root1 = (-b - Math.sqrt(discriminant)) / (2 * a);
            root2 = (-b + Math.sqrt(discriminant)) / (2 * a);
            jsConsole.writeLine("Two Roots: " + root1 + " and " + root2);
        }
        else if (discriminant === 0) {
            root1 = -b / (2 * a);
            jsConsole.writeLine("One Root: " + root1);
        }
        else {
            jsConsole.writeLine("No real roots");
        }
    }
}

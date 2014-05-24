function CheckThirdBit() {
    var num = jsConsole.read("#number"),
        result,
        binary;
    if (isNaN(num) || num === null || num === "") {
        jsConsole.writeLine("Entered value is not a number!");
    }
    else {
        if (num % 1 !== 0) {
            jsConsole.writeLine("Entered number " + num + " should be an integer");
            return;
        }
        if (num < 0) {
            jsConsole.writeLine("Entered number " + num + " should be positive");
            return;
        }

        result = num & (true << 3);
        if (result > 0) {
            result = 1;
        }

        binary = parseInt(num).toString(2);

        jsConsole.writeLine("Third bit of " + num + " ("+ binary + ") is " + result);

    }
}
function DigitName() {
    var digit = parseFloat(jsConsole.read("#digit")),
        result;
    if (isNaN(digit) || digit === null || digit === "" ) {
        jsConsole.writeLine("The entered value is not a number!");
    }
    else {
        if (digit < 0 || digit > 9 || digit % 1 !== 0) {
            jsConsole.writeLine("Please enter integer digit from 0 to 9");
            return;
        }

        switch (digit) {
            case 0: result = "Zero"; break;
            case 1: result = "One"; break;
            case 2: result = "Two"; break;
            case 3: result = "Three"; break;
            case 4: result = "Four"; break;
            case 5: result = "Five"; break;
            case 6: result = "Six"; break;
            case 7: result = "Seven"; break;
            case 8: result = "Eight"; break;
            case 9: result = "Nine"; break;
        }

        jsConsole.writeLine(digit + " -> " + result);
    }
}

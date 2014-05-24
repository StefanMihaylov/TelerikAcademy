function IsDivided() {
    var num = jsConsole.read("#number"),
        result;

    if (isNaN(num) || num === null || num === "") {
        jsConsole.writeLine("Entered value is not a number!");
    }
    else {

        if (num % 35 === 0) {
            result = " is";
        }
        else {
            result = " isn't";
        }

        jsConsole.writeLine(num + result + " divided without remainder by 7 and 5 in the same time");
    }
}
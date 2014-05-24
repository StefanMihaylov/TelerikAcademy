function EvenOrOdd() {
    var num = jsConsole.read("#number");
    if (isNaN(num) || num === null || num === ""){
        jsConsole.writeLine("Entered value is not a number!");
    }        
    else {

        if (num % 2 === 0) {
            jsConsole.writeLine(num + " is even number");
        }
        else {
            jsConsole.writeLine(num + " is odd number");
        }
    }
}
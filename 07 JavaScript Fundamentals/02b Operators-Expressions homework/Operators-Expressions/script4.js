function CheckThirdDigit() {
    var num = jsConsole.read("#number"),
        result;
    if (isNaN(num) || num === null || num === ""){
        jsConsole.writeLine("Entered value is not a number!");
    }        
    else {
        result = parseInt(num / 100) % 10;
        if (result === 7) {
            jsConsole.writeLine("Third digit of " + num + " is seven");
        }
        else {
            jsConsole.writeLine("Third digit of " + num + " isn't seven");
        }
    }
}
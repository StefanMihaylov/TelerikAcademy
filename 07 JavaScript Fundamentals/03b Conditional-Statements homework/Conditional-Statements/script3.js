function BiggestOfThree() {
    var num1 = parseFloat(jsConsole.read("#number1")),
        num2 = parseFloat(jsConsole.read("#number2")),
        num3 = parseFloat(jsConsole.read("#number3")),
        result;
    if (isNaN(num1) || num1 === null || num1 === "" ||
        isNaN(num2) || num2 === null || num2 === "" ||
        isNaN(num3) || num3 === null || num3 === "") {
        jsConsole.writeLine("The entered value is not a number!");
    }
    else {

        if (num1 > num2) {
            if (num1 > num3) {
                result = num1;
            }
            else {
                result = num3;
            }            
        }
        else {
            if (num2 > num3) {
                result = num2;
            }
            else {
                result = num3;
            }
        }

        jsConsole.writeLine("The biggest of " + num1 + ", " + num2 + ", " + num3 + " is " + result);      
    }
}
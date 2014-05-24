function CheckSign() {
    var num1 = parseFloat(jsConsole.read("#number1")),
        num2 = parseFloat(jsConsole.read("#number2")),
        num3 = parseFloat(jsConsole.read("#number3")),
        counter,
        result;
    if (isNaN(num1) || num1 === null || num1 === "" ||
        isNaN(num2) || num2 === null || num2 === "" ||
        isNaN(num3) || num3 === null || num3 === "") {
        jsConsole.writeLine("The entered value is not a number!");
    }
    else {
        counter = 0;
        if (num1 < 0) counter++;
        if (num2 < 0) counter++;
        if (num3 < 0) counter++;

        
        if (counter % 2 === 0) {
            result = "positive";
        }
        else {
            result = "negative";
        }

        jsConsole.writeLine("Product of " + num1 + ", " + num2 + ", " + num3 + " is " + result);      
    }
}
function Swap() {
    var num1 = parseFloat(jsConsole.read("#number1")),
        num2 = parseFloat(jsConsole.read("#number2")),
        temp;
    if (isNaN(num1) || num1 === null || num1 === "" ||
        isNaN(num2) || num2 === null || num2 === "") {
        jsConsole.writeLine("The entered value is not a number!");
    }
    else {
        
        jsConsole.writeLine("Entered values: " + num1 + ", " + num2);       

        if (num1 > num2) {
            temp = num1;
            num1 = num2;
            num2 = temp;

            /* other possible algorithms:
                a = a ^ b;
                b = a ^ b;
                a = a ^ b;

                a=a+b;
                b=a-b;
                a=a-b;

                b=a+(a=b)-b;

                b = [a, a = b][0];
             */
            jsConsole.writeLine("Values " + num1 + " and " + num2 + " exchanged!");
        }
    }
}
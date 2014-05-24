function SortUsingIf() {
    var num1 = parseFloat(jsConsole.read("#number1")),
        num2 = parseFloat(jsConsole.read("#number2")),
        num3 = parseFloat(jsConsole.read("#number3")),
        temp;
    if (isNaN(num1) || num1 === null || num1 === "" ||
        isNaN(num2) || num2 === null || num2 === "" ||
        isNaN(num3) || num3 === null || num3 === "") {
        jsConsole.writeLine("The entered value is not a number!");
    }
    else {
        if (num1 < num2) {
            temp = num1;
            num1 = num2;
            num2 = temp;

            if (num1 < num3) {
                temp = num1;
                num1 = num3;
                num3 = temp;
            }
        }
        else {
            if (num1 < num3) {
                temp = num1;
                num1 = num3;
                num3 = temp;
            }
        }

        if (num2 < num3) {
            temp = num2;
            num2 = num3;
            num3 = temp;
        }

        jsConsole.writeLine("Sorted numbers: " + num1 + ", " + num2 + ", " + num3);
    }
}

function ConvertNumber() {
    var number = parseFloat(jsConsole.read("#digits")),
        unitsArray = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                      "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"],
        tensArray = ["twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];

    if (isNaN(number) || number === null || number === "") {
        jsConsole.writeLine("The entered value is not a number!");
    } else {
        if (number < 0 || number > 999 || number % 1 !== 0) {
            jsConsole.writeLine("Please enter integer digit from 0 to 999");
            return;
        }

        if (number === 0) {
            jsConsole.writeLine(number + " -> Zero");
            return;
        }

        var hundreds = parseInt(number / 100),
            hundredsRemainder = number % 100, // number = hundreds*100 + hundredsReminder;
            tens = parseInt(hundredsRemainder / 10),
            units = hundredsRemainder % 10, // number = hundreds*100 + tens*10 + units;
            result = "";

        if (hundreds !== 0) {
            result += unitsArray[hundreds] + " hundred ";
            if (hundredsRemainder > 0 && hundredsRemainder < 20) {
                result += "and ";
            }
        }

        if (hundredsRemainder > 0) {
            if (hundredsRemainder < 20) {
                result += unitsArray[hundredsRemainder] + " ";
            } else {
                result += tensArray[tens - 2] + " ";
                if (units !== 0) {
                    result += unitsArray[units];
                }
            }
        }

        result = result.trim(); // remove spaces, if any
        result = result.charAt(0).toUpperCase() + result.slice(1); // uppercase of first letter

        jsConsole.writeLine(number + " -> " + result);
    }
}

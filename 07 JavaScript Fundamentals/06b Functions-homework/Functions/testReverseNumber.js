/*jslint plusplus: true */
function reverseNumber(number) {
    var i,
        digits,
        len;

    number = number.toString();
    len = number.length;
    for (i = 0; i < len; i++) {
        digits[i] = number[len - 1 - i];
    }

    return parseInt(digits.join(''), 10);
}

function testReverseNumber() {

    var number = jsConsole.readInteger("#number"),
        result;

    if (isNaN(number) || number === null || number === "") {
        jsConsole.writeLine("The entered value is not a number!");
        return;
    }

    if (number < 0) {
        jsConsole.writeLine("Please enter positive number!");
    } else {
        result = reverseNumber(number);
        jsConsole.writeLine(number + " --> " + result);
    }
}
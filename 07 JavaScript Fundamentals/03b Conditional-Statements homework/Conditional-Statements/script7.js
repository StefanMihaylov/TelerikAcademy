function GreatestOfFive() {
    var data = new Array(5),
        i,
        result;

    data[0] = parseFloat(jsConsole.read("#number1"));
    data[1] = parseFloat(jsConsole.read("#number2"));
    data[2] = parseFloat(jsConsole.read("#number3"));
    data[3] = parseFloat(jsConsole.read("#number4"));
    data[4] = parseFloat(jsConsole.read("#number5"));

    for (i = 0; i < data.length; i++) {
        if (isNaN(data[i]) || data[i] === null || data[i] === "") {
            jsConsole.writeLine("The entered value #" + (i + 1) + " is not a number!");
            return;
        }
    }

    result = data[0];
    for (i = 1; i < data.length; i++) {
        if (data[i] > result) {
            result = data[i];
        }
    }

    jsConsole.writeLine("The Biggest number is: " + result);
}

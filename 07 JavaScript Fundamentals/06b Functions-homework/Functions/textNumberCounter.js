/*jslint plusplus: true */
function countNumberInArray(array, number) {
    var i,
        counter = 0;

    for (i = 0; i < array.length; i++) {
        if (array[i] === number) {
            counter++;
        }
    }
    return counter;
}

function textNumberCounter() {
    var i,
        number = jsConsole.readInteger("#number"),
        text = jsConsole.read("#text"),
        sequence,
        result;

    if (isNaN(number) || number === null || number === "") {
        jsConsole.writeLine("The entered value is not a number!");
        return;
    }

    if (text === undefined || text === null || text === "") {
        jsConsole.writeLine("The entered value is not a text!");
        return;
    }

    sequence = text.split(/[\s,]+/);
    for (i = 0; i < sequence.length; i++) {
        sequence[i] = parseInt(sequence[i], 10);
    }

    result = countNumberInArray(sequence, number);
    jsConsole.writeLine('Number "' + number + '" is found ' + result +
        ' times in preset sequence');
}
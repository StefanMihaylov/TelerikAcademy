/*jslint plusplus: true */
function biggerThanNeighbours(array, index) {
    var result = false;
    if (index >= 1 && index <= array.length - 2) {
        if (array[index] > array[index + 1] &&
                array[index] > array[index - 1]) {
            result = true;
        }
    }
    return result;
}

function biggerThanNeighboursIndex(array) {
    var i;
    for (i = 1; i < array.length - 1; i++) {
        if (biggerThanNeighbours(array, i)) {
            return i;
        }
    }
    return -1;
}

function testBiggerThanNeighbours() {
    var i,
        text = jsConsole.read("#text"),
        sequence,
        index;

    if (text === undefined || text === null || text === "") {
        jsConsole.writeLine("The entered value is not a text!");
        return;
    }

    // convert string to array of integers
    sequence = text.split(/[\s,]+/);
    for (i = 0; i < sequence.length; i++) {
        // TODO: check if the array is filled with numbers
        sequence[i] = parseInt(sequence[i], 10);
    }

    index = biggerThanNeighboursIndex(sequence);
    if (index === -1) {
        jsConsole.writeLine("Element that is bigger than its neighbours doesn't exist");
    } else {
        jsConsole.writeLine("Bigger than its neighbours: value '" +
            sequence[index] + "', index '" + index + "'");
    }
}
function binarySearch() {

    function randomIntFromInterval(min, max) {
        return Math.floor(Math.random() * (max - min + 1) + min);
    }

    var i,
        lowIndex,
        highIndex,
        testIndex,
        text = jsConsole.read("#text"),
        number = jsConsole.readInteger("#number"),
        sequence = new Array();

    if (text === undefined || text === null || text === "") {
        // initialize random values
        for (i = 0; i < 10; i++) {
            sequence[i] = randomIntFromInterval(-10, 10);
        }
    } else {
        sequence = text.split(/[\s,]+/);
        // covert form string to integer
        for (i = 0; i < sequence.length; i++) {
            sequence[i] = parseInt(sequence[i]);
        }
    }

    if (isNaN(number) || number === null || number === "") {
        // initialize random values
        number = randomIntFromInterval(-10, 10);
    }

    if (sequence.length < 2) {
        jsConsole.writeLine('Invalid sequence');
        return;
    }

    sequence = sequence.sort(function (a, b) { return (a === b) ? 0 : (a > b) ? 1 : -1; });
    jsConsole.writeLine(" Sorted Sequence: " + sequence.join(', '));

    // binary search
    lowIndex = 0;
    highIndex = sequence.length - 1;
    while (lowIndex + 1 < highIndex) {
        testIndex = parseInt((highIndex + lowIndex) / 2);
        if (sequence[testIndex] > number) {
            highIndex = testIndex;
        } else {
            lowIndex = testIndex;
        }
    }

    if (sequence[lowIndex] === number) {
        jsConsole.writeLine("Value '" + number + "' found on index '" + lowIndex + "'");
    } else if (sequence[highIndex] === number) {
        jsConsole.writeLine("Value '" + number + "' found on index '" + highIndex + "'");
    } else {
        jsConsole.writeLine("Value '" + number + "' doesn't exist in the sequence");
    }
}
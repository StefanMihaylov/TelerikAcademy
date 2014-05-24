function selectionSort() {

    function randomIntFromInterval(min, max) {
        return Math.floor(Math.random() * (max - min + 1) + min);
    }

    var i,
        j,
        text = jsConsole.read("#text"),
        sequence = new Array(),
        position,
        oldValue;

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

    if (sequence.length < 2) {
        jsConsole.writeLine('Invalid sequence');
        return;
    }

    jsConsole.writeLine("Entered Sequence: " + sequence.join(', '));

    // selection sort
    for (i = 0; i < sequence.length; i++) {
        position = i;
        for (j = i + 1; j < sequence.length; j++) {
            // find minimal value in the array
            if (sequence[j] < sequence[position]) {
                position = j;
            }
        }

        // exchange the places of current and minimal element
        oldValue = sequence[i];
        sequence[i] = sequence[position];
        sequence[position] = oldValue;
    }

    jsConsole.writeLine(" Sorted Sequence: " + sequence.join(', '));
}
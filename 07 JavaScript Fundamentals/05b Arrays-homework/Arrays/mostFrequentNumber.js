function mostFrequentNumber() {
    var i,
        j,
        text = jsConsole.read("#text"),
        sequence = new Array(),
        maxCounter,
        maxElement,
        currentCounter;

    if (text === undefined || text === null || text === "") {
        // initialize default values
        sequence = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];
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

    maxCounter = 0;
    maxElement = 0;
    for (i = 0; i < sequence.length - 1; i++) {
        currentCounter = 1;
        for (j = i + 1; j < sequence.length; j++) {
            if (sequence[i] === sequence[j]) {
                currentCounter++;
            }
        }
        if (currentCounter > maxCounter) {
            maxCounter = currentCounter;
            maxElement = sequence[i];
        }
    }

    if (maxCounter > 1) {
        jsConsole.writeLine(" Most frequent number is " + maxElement + ", found " + maxCounter + " times");
    } else {
        jsConsole.writeLine(" All elements are different ");
    }
}
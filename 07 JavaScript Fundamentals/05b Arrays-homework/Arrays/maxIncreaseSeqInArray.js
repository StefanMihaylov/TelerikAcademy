function MaxIncreaseSeqInArray() {
    var i,
        text = jsConsole.read("#text"),
        sequence,
        result,
        startPosition,
        previousElement,
        numberOfElements,
        maxSequenceStart,
        maxSequenceLenght;

    if (text === undefined || text === null || text === "") {
        sequence = [3, 2, 3, 4, 2, 2, 4];
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

    jsConsole.writeLine("Sequence: " + sequence.join(', '));

    startPosition = 0;
    previousElement = sequence[0]; // first element
    numberOfElements = 1;

    maxSequenceStart = startPosition;
    maxSequenceLenght = numberOfElements;

    for (i = 1; i < sequence.length; i++) {
        if (sequence[i] === (previousElement + 1)) {
            numberOfElements++;
        } else {
            if (numberOfElements > maxSequenceLenght) {
                maxSequenceLenght = numberOfElements;
                maxSequenceStart = startPosition;
            }

            numberOfElements = 1;
            startPosition = i;
        }

        previousElement = sequence[i];
    }

    // check if last element is part of the subsequence
    if (numberOfElements > maxSequenceLenght) {
        maxSequenceLenght = numberOfElements;
        maxSequenceStart = startPosition;
    }

    if (maxSequenceLenght === 1) {
        result = "Sequence not found";
    } else {
        result = sequence.slice(maxSequenceStart, maxSequenceStart + maxSequenceLenght).join(', ');

    }

    jsConsole.writeLine("- Result: " + result);
}
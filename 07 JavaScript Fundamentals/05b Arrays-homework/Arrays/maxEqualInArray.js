function MaxEqualInArray() {
    var i,
        text = jsConsole.read("#text"),
        sequence,
        result,
        startPosition,
        startElement,
        numberOfElements,
        maxSequenceStart,
        maxSequenceLenght;

    if (text === undefined || text === null || text === "") {
        sequence = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];
    } else {
        sequence = text.split(/[\s,]+/);
    }

    if (sequence.length < 2) {
        jsConsole.writeLine('Invalid sequence');
        return;
    }

    jsConsole.writeLine("Sequence: " + sequence.join(', '));

    startPosition = 0;
    startElement = sequence[0]; // first element
    numberOfElements = 1;

    maxSequenceStart = startPosition;
    maxSequenceLenght = numberOfElements;

    for (i = 1; i < sequence.length; i++) {
        if (sequence[i] === startElement) {
            numberOfElements++;
        } else {
            startElement = sequence[i];
            if (numberOfElements > maxSequenceLenght) {
                maxSequenceLenght = numberOfElements;
                maxSequenceStart = startPosition;
            }

            numberOfElements = 1;
            startPosition = i;
        }
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
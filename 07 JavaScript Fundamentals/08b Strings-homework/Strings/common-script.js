function readInt(id) {
    var number = jsConsole.readFloat("#" + id);
    if (isNaN(number) || number === null || number === "") {
        jsConsole.writeLine("The entered value in box '" + id + "' is not a number!");
        return null;
    }
    return number;
}

function readString(id) {
    var number = jsConsole.read("#" + id);
    if (number === undefined || number === null || number === "") {
        jsConsole.writeLine("The entered value in box '" + id + "' is not a text!");
        return null;
    }
    return number;
}

function readArray(id) {
    var i,
    text = jsConsole.read("#" + id),
    sequence,
    currentValue;

    if (text === undefined || text === null || text === "") {
        jsConsole.writeLine("The entered value is not a text!");
        return null;
    }

    // convert string to array of integers
    sequence = text.split(/[\s,]+/);
    for (i = 0; i < sequence.length; i++) {
        currentValue = parseInt(sequence[i], 10);
        if (!isNaN(currentValue)) {
            sequence[i] = currentValue;
        }
    }

    return sequence;
}

function buildPerson(fname, lname, age) {
    return {
        fname: fname,
        lname: lname,
        age: parseInt(age),
        toString: function () {
            return this.fname + ' ' + this.lname;
        }
    }
}
/*jslint plusplus: true */
function wordCounter(text, word, caseSensitive) {
    var i,
        words,
        counter = 0;

    if (!caseSensitive) {
        word = word.toLowerCase();
        text = text.toLowerCase();
    }

    words = text.split(/[\s,.!?]+/);
    for (i = 0; i < words.length; i++) {
        if (words[i] === word) {
            counter++;
        }
    }

    return counter;
}

function testWordCounter() {

    var text = jsConsole.read("#text"),
        word = jsConsole.read("#word").trim(),
        caseSensitive = document.querySelector('#case').checked,
        result;

    if (text === undefined || text === null || text === "" ||
            word === undefined || word === null || word === "") {
        jsConsole.writeLine("The entered value is not a text!");
        return;
    }

    result = wordCounter(text, word, caseSensitive);
    jsConsole.writeLine("Word '" + word + "' is found " + result + " times");
}
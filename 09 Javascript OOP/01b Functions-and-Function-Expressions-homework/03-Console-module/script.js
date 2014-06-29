'use strict';
var specialConsole = (function () {
    function format(input) {
        if (input.length === 1) {
            return input[0].toString();
        }
        else {
            var result = '';
            var len = input[0].length;
            for (var i = 0; i < len; i++) {
                var char = input[0][i];
                if (char === '{') {
                    var index = input[0].indexOf('}', i);
                    var number = input[0].substring(i+1, index);
                    var position = parseInt(number) + 1;
                    i = index;
                    result += input[position].toString();
                    continue;
                }

                result += char;
            }
            return result;
        }
    }

    function writeLine() {
        console.log(format(arguments));
    }

    function writeError() {
        console.error(format(arguments));
    }

    function writeWarning() {
        console.warn(format(arguments));
    }

    return{
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    }
})();

specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0} {1}", "Hello", 2);
specialConsole.writeError("Error: {0}", "Something happened");
specialConsole.writeWarning("Warning: {0}", "A warning");


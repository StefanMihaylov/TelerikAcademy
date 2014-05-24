(function () {
    var i;

    if (!Array.prototype.remove) {
        Array.prototype.remove = function (value) {
            if (this === null) {
                throw new TypeError();
            }

            var size = this.length;
            for (i = 0; i < size; i++) {
                if (this[i] === value) {
                    this.splice(i, 1);
                    size--;
                    i--;
                }
            }

            return this;
        };
    }
})();

function testRemoveByValue() {
    var array = readArray("text"), // function "readArray" is in file "common-script.js"
        number = readInt("number"); // function "readInt" is in file "common-script.js"
    if (array === null || number === null) {
        return;
    }

    jsConsole.writeLine("Input Array: " + array.join(", "));
    array.remove(number);
    jsConsole.writeLine("Result Array: " + array.join(", "));
}
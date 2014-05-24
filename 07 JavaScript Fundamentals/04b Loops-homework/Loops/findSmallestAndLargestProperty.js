(function findSmallestAndLargestProperty() {

    function findSmallestAndLargest(obj) {
        var index,
            smallest,
            largest,
            result = {};

        for (index in obj) {
            if (smallest === undefined || index < smallest) {
                smallest = index;
            }
            if (largest === undefined || index > largest) {
                largest = index;
            }
        }

        result.smallest = smallest;
        result.largest = largest;

        return result;
    }

    var result;

    result = findSmallestAndLargest(document);
    jsConsole.writeLine('"document" smallest property is "' + result.smallest + '"');
    jsConsole.writeLine('"document" largest property is "' + result.largest + '"');
    jsConsole.writeLine(' ');

    result = findSmallestAndLargest(window);
    jsConsole.writeLine('"window" smallest property is "' + result.smallest + '"');
    jsConsole.writeLine('"window" largest property is "' + result.largest + '"');
    jsConsole.writeLine(' ');

    result = findSmallestAndLargest(navigator);
    jsConsole.writeLine('"navigator" smallest property is "' + result.smallest + '"');
    jsConsole.writeLine('"navigator" largest property is "' + result.largest + '"');
    jsConsole.writeLine(' ');
})();
function FindMinAndMax() {

    function randomIntFromInterval(min, max) {
        return Math.floor(Math.random() * (max - min + 1) + min);
    }

    var i,
        minLimit = -10,
        maxLimit = 10,
        numbers = new Array(10),
        minValue,
        maxValue;

    //fill array with random numbers and print them
    jsConsole.write('Random numbers: ');
    for (i = 0; i < numbers.length; i++) {
        numbers[i] = randomIntFromInterval(minLimit, maxLimit);
        jsConsole.write(numbers[i] + ' ');
    }
    jsConsole.writeLine('');

    // find the minimal and maximal value
    minValue = numbers[0];
    maxValue = numbers[0];
    for (i = 1; i < numbers.length; i++) {
        if (numbers[i] < minValue) {
            minValue = numbers[i];
        }
        if (numbers[i] > maxValue) {
            maxValue = numbers[i];
        }
    }
    jsConsole.writeLine(' Minimal value: ' + minValue + '; Maximal value: ' + maxValue);

}
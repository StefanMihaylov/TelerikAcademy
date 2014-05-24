function IsPrime() {
    var num = jsConsole.read("#number"),
        i,
        max,
        notPrime = false,
        result;

    if (isNaN(num) || num === null || num === "") {
        jsConsole.writeLine("Entered value is not a number!");
    }
    else {
        if (num % 1 !== 0 || num < 2 || num > 100) {
            jsConsole.writeLine("Entered number " + num + " should be an integer in range[2...100]");
            return;
        }

        max = parseInt(Math.sqrt(num))
        for (i = 2; i <= max; i++) {
            if (num % i === 0) {
                notPrime = true;
                break;
            }
        }
        result = notPrime ? "composite number" : "prime number";
        jsConsole.writeLine(num + " is " + result);

    }
}
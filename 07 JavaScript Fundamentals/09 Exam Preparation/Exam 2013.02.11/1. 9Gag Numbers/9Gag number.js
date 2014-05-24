function solve(inputs) {

    function contains(array, pattern) {
        for (var i = 0; i < array.length; i++) {
            if (array[i] === pattern) {
                return i;
            }
        }
        return -1;
    }

    function convert(digits, power) {
        var multiplier = 1;
        var result = 0;
        for (var i = digits.length - 1; i >= 0; i--) {
            result += digits[i] * multiplier;
            multiplier *= power;
        }
        return result;
    }

    var input = inputs[0];
    var digitsAsString = ['-!', '**', '!!!', '&&', '&-', '!-', '*!!!', '&*!', '!!**!-'];
    var pattern = '';
    var digits = [];
    for (var i = 0; i < input.length; i++) {
        pattern += input[i];
        var index = contains(digitsAsString, pattern);
        if (index !== -1) {
            digits.push(index);
            pattern = '';
        }
    }

    //console.log(digits);

    return convert(digits, 9);
}

var test1 = ['*!!!'];
var test2 = ['***!!!'];
var test3 = ['!!!**!-'];
var test4 = ['!!**!--!!-'];

console.log('----Result: 6  = ' + solve(test1));
console.log('----Result: 15  = ' + solve(test2));
console.log('----Result: 176  = ' + solve(test3));
console.log('----Result: 653  = ' + solve(test4));
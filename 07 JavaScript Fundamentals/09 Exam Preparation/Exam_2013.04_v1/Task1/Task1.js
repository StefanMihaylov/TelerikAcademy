function Solve(input) {
    input = input.map(Number);
    var result = 1;
    for (var i = 2; i < input.length; i++) {
        if (input[i-1] > input[i]) {
            result++;
        }
    }
    return result;
}

var args = [
    '7  ',
    '1  ',
    '2  ',
    '-3 ',
    '4  ',
    '4  ',
    '0  ',
    '1 '];

console.log(Solve(args));
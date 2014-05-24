function Solve(params) {
    var numbers = params.map(Number);
    var max = numbers[1];   
    for (var i = 1; i <= numbers[0]; i++) {       
        for (var j = i; j <= numbers[0]; j++) {
            var sum = 0;
            for (var k = i; k <= j; k++) {
                sum += numbers[k];
            }
            if (sum > max) {
                max = sum;
            }
        }
    }
    return max;
}
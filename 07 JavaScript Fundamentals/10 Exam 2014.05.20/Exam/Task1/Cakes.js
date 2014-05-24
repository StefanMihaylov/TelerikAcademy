function solve(inputs) {

    function parse() {
        if (typeof arguments[0] === 'string') {
            return arguments[0].split(' ').map(Number);
        }
        else {
            return arguments[0].map(Number);
        }
    }

    var numbers = parse(inputs);
    var money = numbers[0];
    var C1 = numbers[1];
    var C2 = numbers[2];
    var C3 = numbers[3];
    var result = 0;
    var sum;
    var maxC1 = parseInt(money / C1);
    var maxC2 = parseInt(money / C2);
    var maxC3 = parseInt(money / C3);

    //console.log(maxC1 + ' ' + maxC2 + ' ' + maxC3);;

    for (var i = 0; i <= maxC1; i++) {
        for (var j = 0; j <= maxC2; j++) {
            for (var k = 0; k <= maxC3; k++) {
                sum = i * C1 + j * C2 + k * C3;
                if (sum <= money && sum >= result) {
                    result = sum;
                    //console.log(i + ' ' + j + ' ' + k);
                }
            }
        }
    }

    return result;
}

var test1 = [
'110', 
'13', 
'15 ',
'17'
];

var test2 = [
'20',
'11',
'200',
'300'];

var test3 = [
'110',
'19', 
'29', 
'39'];

console.log('---result: 110 = ' + solve(test1));
console.log('---result: 11 = ' + solve(test2));
console.log('---result: 107 = ' + solve(test3));

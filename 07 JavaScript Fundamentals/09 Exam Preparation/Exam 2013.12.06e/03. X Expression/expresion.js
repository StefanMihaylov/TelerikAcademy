function solve(inputs) {
    var result = parseInt(inputs[0][0]);
    var operator = '';
    var symbol;
    var nestedResult = '';
    var nestedOperator = '';
    var isNested = false;
    for (var i = 1; i < inputs[0].length; i++) {
        symbol = inputs[0][i];

       // console.log('#:' + symbol + ' R: ' + result + ' O: ' + operator + ' | ' + isNested + ' NR: ' + nestedResult + ' NO: ' + nestedOperator);

        if (symbol === '+' || symbol === '-' || symbol === '*' || symbol === '/') {
            if (isNested) {
                nestedOperator = symbol;
            }
            else {
                operator = symbol;
            }
            continue;
        }

        if (symbol === '(') {
            isNested = true;
            continue;
        }

        if (symbol === ')') {
            isNested = false;
            switch (operator) {
                case '+': result += nestedResult; break;
                case '-': result -= nestedResult; break;
                case '*': result *= nestedResult; break;
                case '/': result /= nestedResult; break;
            }
            operator = '';
            nestedResult = '';
            continue;
        }

        if (isFinite(symbol)) {
            var digit = parseInt(symbol);
            if (isNested) {
                if (nestedResult === '') {
                    nestedResult = digit;
                }
                else {
                    switch (nestedOperator) {
                        case '+': nestedResult += digit; break;
                        case '-': nestedResult -= digit; break;
                        case '*': nestedResult *= digit; break;
                        case '/': nestedResult /= digit; break;
                    }
                }
            }
            else {
                switch (operator) {
                    case '+': result += digit; break;
                    case '-': result -= digit; break;
                    case '*': result *= digit; break;
                    case '/': result /= digit; break;
                }
            }
        }
    }
    //console.log(result);
    return Math.round(result * 100) / 100;
}

var test1 = ['4+6/5+(4*9-8)/7*2='];
var test2 = ['3+(6/5)+(2*3/7)*7/2*(9/4+4*1)='];

console.log('---- Result: 8.57 = ' + solve(test1));
console.log('---- Result: 110.63 = ' + solve(test2));
function solve(input) {

    var lines = {};
    for (var i = 0; i < input.length; i++) {
        var currentLine = input[i].trim();
        var defIndex = currentLine.indexOf('def ');
        var command = {};
        if (defIndex === 1) {
            var line;
            if (currentLine[currentLine.length - 1] === ')') {
                line = currentLine.substring(defIndex + 'def_'.length, currentLine.length - 1).trim();
            }
            else {
                line = currentLine.substring(defIndex + 'def_'.length).trim();
            }

            var spaceIndex = line.indexOf(' ');
            var funcName = line.substring(0, spaceIndex).trim();
            var expression = line.substring(spaceIndex).trim();
            if (expression[0] === '(' && expression[expression.length - 1] !== ')') {
                expression += ')';
            }
            command['expression'] = expression;
            command['line'] = i + 1;
            lines[funcName] = command;
        }
        else {
            command['expression'] = currentLine;
            command['line'] = i + 1;
            lines[''] = command;
        }
    }

    //console.log(lines);

    for (var name in lines) {
        var expression = lines[name].expression.trim();
        if (expression[0] !== '(') {
            if (isFinite(expression)) {
                lines[name]['value'] = parseInt(expression);
            }
            else {
                lines[name]['value'] = lines[expression].value;
            }
        }
        else {
            var currentExpression = expression.substring(1, expression.length - 1);
            var items = currentExpression.trim().split(' ');

            //console.log(name + ' - ' + items.join('|'));

            var data = [];
            for (var j = 0; j < items.length; j++) {
                var currentItem = items[j].trim();
                if (currentItem === '') {
                    continue;
                }
                if (currentItem === '+' || currentItem === '-' || currentItem === '*' || currentItem === '/') {
                    data.push(currentItem);
                    continue;
                }

                if (isFinite(currentItem)) {
                    data.push(parseInt(currentItem));
                }
                else {

                    data.push(lines[currentItem].value);
                }
            }

            var result;

            if (data.length === 1) {
                result = data[0];
            }
            else if (data.length === 2) {
                result = data[1];
            }
            else {
                switch (data[0]) {
                    case '+': result = add(data); break;
                    case '-': result = sub(data); break;
                    case '*': result = mul(data); break;
                    case '/': result = div(data); break;
                }
            }

            if (result === null) {
                return 'Division by zero! At Line:' + lines[name].line;
            }
            else {
                lines[name]['value'] = result;
            }

            // console.log(name + ' - "' + data[0] + '" = ' + data.join('|') + ' = ' + result);
        }
    }

    //console.log('---------')
    //console.log(lines);

    return lines[''].value;

    function add(data) {
        var result = 0;
        for (var i = 1; i < data.length; i++) {
            result += data[i];
        }
        return result;
    }

    function sub(data) {
        var result = data[1];
        for (var i = 2; i < data.length; i++) {
            result -= data[i];
        }
        return result;
    }

    function mul(data) {
        var result = 1;
        for (var i = 1; i < data.length; i++) {
            result *= data[i];
        }
        return result;
    }

    function div(data) {
        var result = data[1];
        for (var i = 2; i < data.length; i++) {
            if (data[i] === 0) {
                return null;
            }
            result = parseInt(result / data[i]);
        }
        return result;
    }
}


var test1 = [
'(def func 10)',
'(def newFunc (      +  func    2    ))',
'(def sumFunc (+ func func newFunc 0 0 0))',
'(* sumFunc 2)'
];

var test2 = [
'(def func (+ 5 2))',
'(def func2 (/  func 5 2 1 0))',
'(def func3 (/ func 2))',
'(+ func3 func)'
];

var test3 = [
'(def myFunc 5)',
'(def myNewFunc (+  myFunc  myFunc 2))',
'(def MyFunc (* 2  myNewFunc))',
'(+ 23 4 8 myFunc 5 7)'
];

var test4 = [
'(def     go6o    (/ -7 1 1 1 1) )',
'(def asd (/ 0 5))',
'(def func2 asd  )',
'(           +        4          2      func2)'
];

var test5 = ['(- 4894894 5246 34123541 11)'];

var test6 = [
'(def joros 30)',
'(def newFunc (-  101 10))',
'(def tryFunc 500)',
'(def tryFunc2 (+ 500 tryFunc  )',
'(def tryFunc1 (+ 500 tryFunc2  )',
'(/ newFunc  )'
];

console.log('-----result: 64 = ' + solve(test1));
console.log('-----result: div-2 = ' + solve(test2));
console.log('-----result: 52 = ' + solve(test3));
console.log('-----result: 6 = ' + solve(test4));
console.log('-----result: -29233904 = ' + solve(test5));
console.log('-----Result: 91 = ' + solve(test6));
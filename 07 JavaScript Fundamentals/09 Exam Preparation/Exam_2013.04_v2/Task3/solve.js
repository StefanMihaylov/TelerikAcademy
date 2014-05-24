function Solve(input) {

    function sum(arr) {
        var result = 0;
        for (var i = 0; i < arr.length; i++) {
            result += arr[i];
        }
        return result;
    }

    function avg(arr) {
        return parseInt(sum(arr) / arr.length);
    }

    function min(arr) {
        var result = arr[0];
        for (var i = 1; i < arr.length; i++) {
            if (arr[i] < result) {
                result = arr[i];
            }
        }
        return result;
    }

    function max(arr) {
        var result = arr[0];
        for (var i = 1; i < arr.length; i++) {
            if (arr[i] > result) {
                result = arr[i];
            }
        }
        return result;
    }

    var variables = [];
    var result;

    for (var i = 0; i < input.length; i++) {
        var currentRow = input[i].trim();
        var inArray = false;
        var inDefCommand = false;
        var numberArray = [];
        var numberAsString = '';
        var currentCommand = '';
        var currentFunction = '';
        var text = '';

        for (var j = 0; j < currentRow.length; j++) {
            symbol = currentRow[j];

            if (symbol === ' ' || symbol === '[') {
                if (text.length > 0) {
                    if (!inDefCommand) {
                        if (text === 'def') {
                            inDefCommand = true;
                            text = '';
                        }
                    }

                    if (!inArray) {
                        if (text === 'min' || text === 'max' || text === 'sum' || text === 'avg') {
                            currentCommand = text;
                        }
                        else {
                            currentFunction = text;
                        }
                        text = '';
                    }

                }

                if (symbol === '[') {
                   // console.log("-!!!- " + text);
                    inArray = true;
                }

                continue;
            }

            if (inArray) {
                if (text.length === 0) {
                    if (!isNaN(symbol) || (symbol === '-')) {
                        numberAsString += symbol;
                        continue
                    }
                }

                if (symbol === ',' || symbol === ']') {
                    if (text.length === 0) {
                        numberArray.push(parseInt(numberAsString));
                        numberAsString = '';
                    }
                    else {

                        var getNumbers = variables[text];
                        //console.log('?: ' + getNumbers + ' : ' + text);
                        if (Array.isArray(getNumbers)) {
                            for (var k = 0; k < getNumbers.length; k++) {
                                numberArray.push(parseInt(getNumbers[k]));
                            }
                        }
                        else {
                            numberArray.push(parseInt(getNumbers));
                        }
                       // console.log('=: ' + numberArray + ' : ' + text);
                        text = '';
                    }

                    if (symbol === ']') {
                        inArray = false;

                        switch (currentCommand) {
                            case 'min': result = min(numberArray); break;
                            case 'max': result = max(numberArray); break;
                            case 'sum': result = sum(numberArray); break;
                            case 'avg': result = avg(numberArray); break;
                            default: result = numberArray;
                        }

                       // console.log("-]: " + currentCommand + " : " + result);

                        if (inDefCommand && variables[currentFunction] === undefined) {
                            variables[currentFunction] = result;
                        }
                    }

                    continue;
                }
            }

            text += symbol;
        }
        //console.log(numberArray);
       // console.log(variables);
    }

    return result.toString();
}


var args = [
    'def func sum[5, 3, 7, 2, 6, 3]',
    'def func2 [5, 3, 7, 2, 6, 3]',
    'def func3 min[func2]',
    'def func4 max[5, 3, 7, 2, 6, 3]',
    'def func5 avg[5, 3, 7, 2, 6, 3]',
    'def func6 sum[func2, func3, func4 ]',
    'sum[func6, func4]',
];

/*
args = [
'def definition[-100, -100, -100]',
'def definitionResult sum[definition]',
'def defTest sum[definitionResult, 6457457, 2345234, -234546]',
    'avg[defTest, 1, 2, 3]'
];

args = ['def test0[1]',
'def test1 sum[1,test0]',
'def test2 sum[1,test1]',
'def test3 sum[1,test2]',
'[test3]']; */

console.log('result 1: ' + Solve(args));
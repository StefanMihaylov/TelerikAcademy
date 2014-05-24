function solve(inputs) {
    function isArray(input) {
        return Array.isArray(input);
    }

    function isString(input) {
        return typeof input === 'string';
    }

    function parse() {
        if (isString(arguments[0])) {
            return arguments[0].split(',').map(Number);
        }
        else {
            return arguments[0].map(Number);
        }
    }

    var N = parse(inputs[0]);
    var rows = [];
    var visited = [];
    for (var i = 1; i <= N; i++) {
        visited[i - 1] = [];
        rows[i - 1] = parse(inputs[i]);
    }

    //console.log(rows);

    var maxPath = 0;
    for (var i = 0; i < rows[0].length; i++) {
        var rowIndex = 0;
        var colIndex = i;
        var path = 1;
        var result = 0;

        var visited = [];
        for (var j = 0; j <= N; j++) {
            visited[j] = [];
        }

        while (true) {
            var element = rows[rowIndex][colIndex];
            //console.log(rowIndex + ' ' + colIndex + '->' + element);

            if (visited[rowIndex][colIndex]) {
                break;
            }

            if (element < 0) {
                result = path + Math.abs(element);
               // console.log(' = ' + result);
                if (result > maxPath) {
                    maxPath = result;
                }
                break;
            }

            visited[rowIndex][colIndex] = true;
            rowIndex++;
            rowIndex = rowIndex % N;
            colIndex = element;
            path++;
            //console.log(rowIndex + ' ' + colIndex);
           // console.log(visited);
        }
    }

    return maxPath;
}

var test1 = [
'4',
'-1, 0, -3, -2, 0, -2',
'-1, 3, 1, 0, 2, 0',
'-9, 1, 1, -7',
'1, -5, -3, -1, 3, -2, 2, 1, 1'
];
var test2 = [
'6',
'5, -4, 8, -5, 0',
'1, -2, -1, 1, 0, -1, -1, -2, 1',
'3, -5',
'4, -9, -4, 4, 0, 7',
'1, -2, -8, 4, -8, 7, -5, -4, -4',
'4, -1, 0, -3, 2, 4, -4, 1'
];
var test3 = [
'2',
'0, -3, 0, 3',
'-3, 3, 0, 2, 0'
];
var test4 = [
'2',
'0, -3, 0, 3',
'0, 3, 0, 2, 0'
];

console.log('----Result: 4  = ' + solve(test1));
console.log('----Result: 8  = ' + solve(test2));
console.log('----Result: 7  = ' + solve(test3));
console.log('----Result: 4  = ' + solve(test4));
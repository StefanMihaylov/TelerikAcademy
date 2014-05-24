function solve(inputs) {

    function isArray(input) {
        return Array.isArray(input);
    }

    function isString(input) {
        return typeof input === 'string';
    }

    function parse() {
        if (typeof arguments[0] === 'string') {
            return arguments[0].split(' ').map(Number);
        }
        else {
            return arguments[0].map(Number);
        }
    }

    function point() {
        var inputRow;
        var inputCol;
        if (arguments.length === 1) {
            if (isArray(arguments[0])) {
                inputRow = arguments[0][0];
                inputCol = arguments[0][1];
            }
        }
        else {
            inputRow = arguments[0];
            inputCol = arguments[1];
        }
        return {
            Row: inputRow,
            Col: inputCol,
            toString: function () { return "{" + this.Row + ',' + this.Col + "}"; }
        }
    }

    function validCoordinates(position, limits) {
        return (position.Row >= 0 && position.Row < limits.Row) && (position.Col >= 0 && position.Col < limits.Col);
    }

    function power (digit){
        result = 1;
        for (var i = 0; i < digit; i++) {
            result*=2;
        }
        return result;
    }

    function move(position, direction) {
        var row;
        var col;
        switch (direction) {
            case 1: row = -2; col = 1; break;
            case 2: row = -1; col = 2; break;
            case 3: row = 1; col = 2; break;
            case 4: row = 2; col = 1; break;
            case 5: row = 2; col = -1; break;
            case 6: row = 1; col = -2; break;
            case 7: row = -1; col = -2; break;
            case 8: row = -2; col = -1; break;
        }
        position.Row += row;
        position.Col += col;
    }

    var limits = point(parse(inputs[0]));

    var field = [];
    var numbers = [];
    for (var i = 0; i < limits.Row; i++) {
        var row = inputs[i + 1];
        field[i] = [];
        numbers[i] = [];
        for (var j = 0; j < limits.Col; j++) {
            field[i][j] = parseInt(row[j]);
            numbers[i][j] = power(i) - j;
        }
    }

    var position = point(limits.Row - 1, limits.Col- 1);
    var sum = 0;
    var jumps = 0;
    while (true) {

        //console.log(position);
        if (!validCoordinates(position, limits)) {
            return 'Go go Horsy! Collected ' + sum + ' weeds';
        }

        if (numbers[position.Row][position.Col] === null) {
            return 'Sadly the horse is doomed in ' + jumps + ' jumps';
        }
        var currentDir = field[position.Row][position.Col];
        sum += numbers[position.Row][position.Col];
        jumps++;
        numbers[position.Row][position.Col] = null;
        move(position, currentDir);
    }
}


var test1 = [
'3 5',
'54561',
'43328',
'52388',
];

console.log(solve(test1));

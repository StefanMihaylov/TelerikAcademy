function Solve(params) {

    function isArray(input) {
        return Array.isArray(input);
    }

    function isString(input) {
        return typeof input === 'string';
    }

    function parse() {
        if (isString(arguments[0])) {
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

    var arg1 = parse(params[0])
    var limits = point(arg1);
    var jumps = arg1[2];
    var position = point(parse(params[1]));

    var jumpSteps = [];
    for (var i = 0; i < jumps; i++) {
        jumpSteps.push(point(parse(params[i + 2])));
    }

    var field = [];
    var counter = 1;
    for (i = 0; i < limits.Row; i++) {
        field[i] = [];
        for (var j = 0; j < limits.Col; j++) {
            field[i][j] = counter++;
        }
    }

    var sum = 0;
    var steps = 0;
    while (true) {
        if (!validCoordinates(position, limits)) {
            return "escaped " + sum;
        }

        if (field[position.Row][position.Col] === 'X') {
            return "caught " + steps;
        }

        sum += field[position.Row][position.Col];

        field[position.Row][position.Col] = 'X';

        position.Row += jumpSteps[steps % jumps].Row;
        position.Col += jumpSteps[steps % jumps].Col;

        steps++;
        //console.log(position.toString())
    }
}

var args = [
'6 7 3',
'0 0', 
'2 2',
'-2 2',
'3 -1'
];

console.log(Solve(args));

function Solve(params) {

    function parseNumbers(input) {
        return input.split(' ').map(Number)
    }

    function pointFromArray(inputArray) {
        return {
            Row: inputArray[0],
            Col: inputArray[1],
            toString: function () { return "{" + this.Row + ',' + this.Col + "}"; }
        }
    }

    function pointFromInt(row, col) {
        return {
            Row: row,
            Col: col,
            toString: function () { return "{" + this.Row + ',' + this.Col + "}"; }
        }
    }

    function validCoordinates(position, limits) {
        var rowValidation = position.Row >= 0 && position.Row < limits.Row;
        var colValidation = position.Col >= 0 && position.Col < limits.Col;
        return rowValidation && colValidation;
    }

    var limits = pointFromArray(parseNumbers(params[0]));
    var position = pointFromArray(parseNumbers(params[1]));

    var field = [];
    var directions = [];
    var counter = 1;
    for (var i = 0; i < limits.Row; i++) {
        field[i] = [];
        directions[i] = [];
        for (var j = 0; j < limits.Col; j++) {
            field[i][j] = counter++;
            directions[i][j] = params[i + 2][j];
        }
    }

    var sum = 0;
    var steps = 0;
    var isLose = false;
    while (true) {
        if (!validCoordinates(position, limits)) {
            return "out " + sum;
        }

        if (field[position.Row][position.Col] === 'X') {
            return "lost " + steps;
        }

        sum += field[position.Row][position.Col];

        field[position.Row][position.Col] = 'X';
        steps++;

        var currentDirection = directions[position.Row][position.Col];
        switch (currentDirection) {
            case 'l': position.Col--; break;
            case 'r': position.Col++; break;
            case 'd': position.Row++; break;
            case 'u': position.Row--; break;
        }
    }
}


var args = [
"3 4",
"1 3",
"lrrd",
"dlll",
"rddd"];

console.log('result 1:' + Solve(args));

args = [
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "durlddud",
 "urrrldud",
 "ulllllll"]

console.log('result 2:' + Solve(args));

args = [
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "lurlddud",
 "urrrldud",
 "ulllllll"]

console.log('result 3:' + Solve(args));
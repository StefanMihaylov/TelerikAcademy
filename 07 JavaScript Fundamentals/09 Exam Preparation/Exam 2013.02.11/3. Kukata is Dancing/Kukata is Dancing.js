function solve(inputs) {

    function rotateLeft(position) {
        switch (position.dir) {
            case 'up': position.dir = 'left'; break;
            case 'left': position.dir = 'down'; break;
            case 'down': position.dir = 'right'; break;
            case 'right': position.dir = 'up'; break;
        }
    }

    function rotateRight(position) {
        switch (position.dir) {
            case 'up': position.dir = 'right'; break;
            case 'left': position.dir = 'up'; break;
            case 'down': position.dir = 'left'; break;
            case 'right': position.dir = 'down'; break;
        }
    }

    function move(position) {
        switch (position.dir) {
            case 'up': position.row--; break;
            case 'left': position.col--; break;
            case 'down': position.row++; break;
            case 'right': position.col++; break;
        }

        if (position.row === -1) {
            position.row = 2;
        }
        else if (position.row === 3) {
            position.row = 0;
        }

        if (position.col === -1) {
            position.col = 2;
        }
        else if (position.col === 3) {
            position.col = 0;
        }
    }

    var field = [['RED', 'BLUE', 'RED'], ['BLUE', 'GREEN', 'BLUE'], ['RED', 'BLUE', 'RED']];
    var result = '';
    for (var i = 1; i < inputs.length; i++) {
        var commands = inputs[i];
        var position = {
            row: 1,
            col: 1,
            dir: 'up'
        }
        for (var j = 0; j < commands.length; j++) {
            switch (commands[j]) {
                case 'L': rotateLeft(position); break;
                case 'R': rotateRight(position); break;
                case 'W': move(position); break;
            }
            //console.log(commands[j] + ' - ' + position.dir + ' : {' + position.row + ',' + position.col + '}');
        }

        //console.log(field[position.row][position.col] + ' : {' + position.row + ',' + position.col + '}');
        result += field[position.row][position.col] + '\n';
    }

    return result.trim();
}

var test1 = [
'5',
'LLRR',
'WWWWWWWWWWWW',
'WLWRW',
'WWL',
'LWRL'
];
var test2 = [
'5',
'WWRLLW',
'RWLW',
'WWL',
'W',
'LWWW'
];

console.log('----Result: = ' + solve(test1));
console.log('----Result: = ' + solve(test2));
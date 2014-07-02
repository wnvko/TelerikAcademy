function Solver(input) {
    var answer = '';
    var NMJ = input[0].split(' ').map(Number);
    var N = NMJ[0];
    var M = NMJ[1];
    var J = NMJ[2];

    var field = [];
    var counter = 1;
    for (var i = 0; i < N; i++) {
        field[i] = [];
        for (var j = 0; j < M; j++) {
            field[i][j] = counter++;
        }
    }

    var whereIsJoro = input[1].split(' ').map(Number);
    var possition = {
        row: whereIsJoro[0],
        col: whereIsJoro[1]
    };

    var jumps = [];
    for (var i = 0; i < J; i++) {
        var jumpArray = input[i + 2].split(' ');
        jumpArray[0] = parseInt(jumpArray[0]);
        jumpArray[1] = parseInt(jumpArray[1]);
        var jump = {
            row: jumpArray[0],
            col: jumpArray[1]
        };
        jumps.push(jump);
    }

    var numberOfJumbs = 0;
    var sumOfNumbers = 0;
    var currentJump = 0;
    while (true) {
        if (possition.row < 0 || possition.row >= N ||
            possition.col < 0 || possition.col >= M) {
            answer = 'escaped ' + sumOfNumbers;
            break;
        }


        if (field[possition.row][possition.col] == 0) {
            answer = 'caught ' + numberOfJumbs;
            break;
        }

        sumOfNumbers += field[possition.row][possition.col];
        field[possition.row][possition.col] = 0;
        possition.row += jumps[currentJump].row;
        possition.col += jumps[currentJump].col;
        numberOfJumbs++;
        currentJump++;
        if (currentJump === J) {
            currentJump = 0;
        }
    }

    return answer;
}

input = [
    '6 7 3',
    '0 0',
    '2 2',
    '-2 2',
    '3 -1',
];

Solver(input);
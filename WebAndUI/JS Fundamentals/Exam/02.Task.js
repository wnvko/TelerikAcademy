function Solve(input) {
    var answer;
    var fieldSize = input[0].split(' ').map(Number);
    var rows = fieldSize[0];
    var cols = fieldSize[1];

    var directions = [];
    var fieldPoints = [];
    var counter = 0;

    for (var row = 0; row < rows; row++) {
        directions[row] = [];
        fieldPoints[row] = [];
        counter = Math.pow(2, row);

        for (var col = 0; col < cols; col++) {
            directions[row][col] = parseInt(input[row + 1][col]);
            fieldPoints[row][col] = counter - col;
        }
    }

    var possition = {
        row: rows - 1,
        col: cols - 1
    }

    var sumWeeds = 0;
    var jumps = 0;

    while (true) {
        if (possition.row >= rows || possition.row < 0 ||
            possition.col >= cols || possition.col < 0) {
            answer = 'Go go Horsy! Collected ' + sumWeeds + ' weeds';
            break;
        }

        if (directions[possition.row][possition.col] === 0) {
            answer = 'Sadly the horse is doomed in ' + jumps + ' jumps';
            break;
        }

        jumps++;
        sumWeeds += fieldPoints[possition.row][possition.col];

        moveHorsy();
    }


    return answer;

    function moveHorsy() {
        var move = directions[possition.row][possition.col];
        directions[possition.row][possition.col] = 0;
        switch (move) {
            case 1: {
                possition.row -= 2;
                possition.col++;
                break;
            }
            case 2: {
                possition.row--;
                possition.col += 2;
                break;
            }
            case 3: {
                possition.row++
                possition.col += 2;
                break;
            }
            case 4: {
                possition.row += 2;
                possition.col++;
                break;
            }
            case 5: {
                possition.row += 2;
                possition.col--;
                break;
            }
            case 6: {
                possition.row++;
                possition.col -= 2;
                break;
            }
            case 7: {
                possition.row--;
                possition.col -= 2;
                break;
            }
            case 8: {
                possition.row -= 2;
                possition.col--;
                break;
            }
            default:
        }
    }
}

input = [
    '3 5',
  '54361',
  '43326',
  '52888',

];

console.log(Solve(input));
function Solver(input) {
    var answer = 0;
    var fieldSize = input[0].split(' ').map(Number);
    var rows = fieldSize[0];
    var cols = fieldSize[1];

    var possitionArray = input[1].split(' ').map(Number);
    var possition = {
        row: possitionArray[0],
        col: possitionArray[1]
    };

    var field = [];
    var fieldNumbers = [];
    var counter = 0;
    for (var row = 0; row < rows; row++) {
        field[row] = [];
        fieldNumbers[row] = [];
        for (var col = 0; col < cols; col++) {
            field[row][col] = input[row + 2][col];
            fieldNumbers[row][col] = ++counter;
        }
    }

    var sumOfNumbersInThePath = 0;
    var numberOfCellInThePath = 0;
    while (true) {
        if (possition.row < 0 || possition.row >= rows ||
            possition.col < 0 || possition.col >= cols) {
            answer = 'out ' + sumOfNumbersInThePath;
            break;
        }

        if (fieldNumbers[possition.row][possition.col] === 0) {
            answer = 'lost ' + numberOfCellInThePath;
            break;
        } else {
            numberOfCellInThePath++;
        }

        sumOfNumbersInThePath += fieldNumbers[possition.row][possition.col];
        fieldNumbers[possition.row][possition.col] = 0;

        possition = move(field, possition);
    }

    return answer;

    function move(field, possition) {
        switch (field[possition.row][possition.col]) {
            case 'l': {
                possition.col--;
                break;
            }
            case 'r': {
                possition.col++;
                break;
            }
            case 'u': {
                possition.row--;
                break;
            }
            case 'd':{
                possition.row++;
                break;
            }
            default:{
                console.log('I am afraid you have some BUGGS!!')
                break;
            }
        }

        return possition;
    }

}


var input = [
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "durlddud",
 "urrrldud",
 "ulllllll"
];

Solver(input);
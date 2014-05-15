var arr = generataRandomArray(20);
var firstSpecial = checkArray(arr);

arr = arr.join(', ');
jsConsole.writeLine('Arr: ' + arr);
if (firstSpecial >= 0) {
    jsConsole.writeLine('First element bigger than his neighbours is on possition ' + firstSpecial);
} else {
    jsConsole.writeLine('There is no element bigger than his neighbours');
}


function checkArray(arr) {
    var possition = -1;
    for (var i = 0, length = arr.length; i < length; i++) {
        if (checkNeighbours(i)) {
            possition = i;
            break;
        }
    }

    return possition;
}

function generataRandomArray(length) {
    var randomArr = [];
    for (var i = 0; i < length; i++) {
        randomArr[i] = ~~(Math.random() * 10 + 1);
    }

    return randomArr;
}

function checkNeighbours(input) {

    isBiggerThanNeighbours = false;

    if (input === 0) {
        isBiggerThanNeighbours = arr[input] > arr[1];
    }
    else if (input === (arr.length - 1)) {
        isBiggerThanNeighbours = arr[input] > arr[arr.length - 2];
    } else {
        isBiggerThanNeighbours = ((arr[input] > arr[input + 1]) && (arr[input] > arr[input - 1]));
    }

    return isBiggerThanNeighbours;
}

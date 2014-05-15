var input,
    numberCount = 0,
    numbersArray = [],
    lookupNumber = '';

function setTextBoxOnFocus() {
    var textBox = document.getElementById('tb-number');
    textBox.focus();
    textBox.select();
}

function takeValueOnEnter(e) {
    if (e.keyCode == 13) {
        takeValue();
    }
}

setTextBoxOnFocus();

function generataRandomArray(length) {
    var randomArr = [];
    for (var i = 0; i < length; i++) {
        randomArr[i] = ~~(Math.random() * 10 + 1);
    }

    return randomArr;
}

function takeValue() {
    input = document.getElementById('tb-number').value;
    input = ~~input;
    checkNeighbours(input);
    setTextBoxOnFocus();
}

function checkNeighbours(input) {

    arr = generataRandomArray(20);
    isBiggerThanNeighbours = false;

    if (input === 0) {
        isBiggerThanNeighbours = arr[input] > arr[1];
    }
    else if (input === (arr.length - 1)) {
        isBiggerThanNeighbours = arr[input] > arr[arr.length - 2];
    } else {
        isBiggerThanNeighbours = ((arr[input] > arr[input + 1]) && (arr[input] > arr[input - 1]));
    }

    arr = arr.join(', ');
    jsConsole.writeLine('Arr: ' + arr);
    if (isBiggerThanNeighbours) {
        jsConsole.writeLine('Number on poissition ' + input + ' is bigger than its neighbours');
    } else {
        jsConsole.writeLine('Number on poissition ' + input + ' is not bigger than its neighbours');
    }
}
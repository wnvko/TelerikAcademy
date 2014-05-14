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
    var randomArr = []
    for (var i = 0; i < length; i++) {
        randomArr[i] = ~~(Math.random() * 10 + 1);
    }

    return randomArr;
}

function takeValue() {
    input = document.getElementById('tb-number').value;
    input = ~~input;
    countNumbers(input);
    setTextBoxOnFocus();
}

function countNumbers(input) {
    arr = generataRandomArray(20);
    var counter = 0;
    for (var i = 0, length = arr.length; i < length; i++) {
        if (arr[i] === input) {
            counter++;
        }
    }

    arr = arr.join(', ');
    jsConsole.writeLine('Arr: ' + arr);
    jsConsole.writeLine('Number ' + lookupNumber + ' appears ' + counter + ' times in the array');
}
var number;
var textBoxText = 'Enter a number: ';

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

function takeValue() {
    var labelTitle = document.getElementById('label');

    number = document.getElementById('tb-number').value;
    setTextBoxOnFocus();
    reversNumber(number);
}

function reversNumber(number) {
    var reversedNumber = '';
    number = number.toString();

    for (var i = 0, length = number.length; i < length; i++) {
        reversedNumber += number[length - i - 1];
    }

    jsConsole.writeLine('Input:');
    jsConsole.writeLine(number);
    jsConsole.writeLine('Reversed:');
    jsConsole.writeLine(reversedNumber);
}
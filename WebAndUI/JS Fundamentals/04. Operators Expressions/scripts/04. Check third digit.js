var input;
function setTextBoxOnFocus() {
    var textBox = document.getElementById('tb-number');
    textBox.focus();
    textBox.select();
}

setTextBoxOnFocus();

function takeValue() {

    input = document.getElementById('tb-number').value;
    checkNumber(input);
    setTextBoxOnFocus();
}

function takeValueOnEnter(e) {
    if (e.keyCode == 13) {
        input = document.getElementById('tb-number').value;
        checkNumber(input);
        setTextBoxOnFocus();
    }
}

function checkNumber(number) {
    number = number.toString();
    var numberLenght = number.length;

    if (number[numberLenght - 3] === '7') {
        jsConsole.writeLine('Your number ' + number + ' has 7 on third possition');
    } else {
        jsConsole.writeLine('Your number ' + number + ' has not 7 on third possition');
    }

    setTextBoxOnFocus();
}
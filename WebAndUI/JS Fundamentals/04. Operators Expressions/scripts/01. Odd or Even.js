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
    if (number % 2 === 0) {
        jsConsole.writeLine('Your number ' + number + ' is even');
    } else {
        jsConsole.writeLine('Your number ' + number + ' is odd');
    }
}

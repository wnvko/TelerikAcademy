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
    var mask = 1 << 3;
    var thirdBit = number & mask;

    if (thirdBit) {
        jsConsole.writeLine('Your number ' + number + ' third bit is 1');
    } else {
        jsConsole.writeLine('Your number ' + number + ' third bit is 0');
    }

    setTextBoxOnFocus();
}
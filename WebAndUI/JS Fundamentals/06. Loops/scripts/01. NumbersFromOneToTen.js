var upperLimit;
var textBoxLabel = 'Enter number N: ';

function setTextBoxOnFocus() {
    var textBox = document.getElementById('tb-number');
    textBox.focus();
    textBox.select();
}
setTextBoxOnFocus();

function takeValue() {
    var labelTitle = document.getElementById('label');
            upperLimit = document.getElementById('tb-number').value;
            labelTitle.innerHTML = textBoxLabel;
            switchNumbers();
    }

function takeValueOnEnter(e) {
    if (e.keyCode == 13) {
        takeValue();
    }
}

function switchNumbers() {
    upperLimit = parseInt(upperLimit);

    for (var i = 1; i <= upperLimit; i++) {
        jsConsole.writeLine(i);
    }
}
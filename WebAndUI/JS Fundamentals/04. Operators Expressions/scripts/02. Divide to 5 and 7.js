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
    var divideByFive = (number % 5 === 0);
    var divideBySeven = (number % 7 === 0);

    if (divideByFive && divideBySeven) {
        jsConsole.writeLine('Your number ' + number + ' can be divided (without remainder) by 7 and 5 in the same time');
    } else {
        jsConsole.writeLine('Your number ' + number + ' cannot be divided (without remainder) by 7 and 5 in the same time');
    }
}

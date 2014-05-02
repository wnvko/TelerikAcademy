var firstNumber;
var secondNumber;
var firstText = 'Enter first number: ';
var secondText = 'Enter second number: ';

function setTextBoxOnFocus() {
    var textBox = document.getElementById('tb-number');
    textBox.focus();
    textBox.select();
}
setTextBoxOnFocus();

function takeValue() {
    var labelTitle = document.getElementById('label');

    switch (labelTitle.innerHTML) {
        case firstText: {
            firstNumber = document.getElementById('tb-number').value;
            labelTitle.innerHTML = secondText;
            break;
        }
        case secondText: {
            secondNumber = document.getElementById('tb-number').value;
            labelTitle.innerHTML = firstText;
            switchNumbers();
            break;
        }
        default: {
            break;
        }
    }

    setTextBoxOnFocus();
}

function takeValueOnEnter(e) {
    if (e.keyCode == 13) {
        takeValue();
    }
}

function switchNumbers() {
    firstNumber = parseInt(firstNumber);
    secondNumber = parseInt(secondNumber);

    jsConsole.writeLine('First number = ' + firstNumber);
    jsConsole.writeLine('Second number = ' + secondNumber);

    var isFirstBigger = firstNumber > secondNumber;
    if (isFirstBigger) {
        jsConsole.writeLine('First number is bigger');
        firstNumber ^= secondNumber;
        secondNumber ^= firstNumber;
        firstNumber ^= secondNumber;
    } else {
        jsConsole.writeLine('First number is smaller');
    }

    jsConsole.writeLine('First number = ' + firstNumber);
    jsConsole.writeLine('Second number = ' + secondNumber);
}
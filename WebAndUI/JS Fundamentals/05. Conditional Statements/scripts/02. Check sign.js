var firstNumber;
var secondNumber;
var thirdNumber;
var firstText = 'Enter first number: ';
var secondText = 'Enter second number: ';
var thirdText = 'Enter third number: ';

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
            labelTitle.innerHTML = thirdText;
            break;
        }
        case thirdText: {
            thirdNumber = document.getElementById('tb-number').value;
            labelTitle.innerHTML = firstText;
            checkSign();
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

function checkSign() {
    firstNumber = parseFloat(firstNumber);
    secondNumber = parseFloat(secondNumber);
    thirdNumber = parseFloat(thirdNumber);

    var minusCount = 0;
    if (firstNumber < 0) {
        minusCount++;
    }

    if (secondNumber < 0) {
        minusCount++;
    }

    if (thirdNumber < 0) {
        minusCount++;
    }

    if (minusCount % 2 === 0) {
        jsConsole.writeLine('The product is possitive');
    } else {
        jsConsole.writeLine('The product is negative');
    }
}
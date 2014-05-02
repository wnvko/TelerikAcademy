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
    firstNumber = parseInt(firstNumber);
    secondNumber = parseInt(secondNumber);
    thirdNumber = parseInt(thirdNumber);

    if (firstNumber > secondNumber) {
        if (firstNumber > thirdNumber) {
            jsConsole.writeLine('The biggest number is first - ' + firstNumber);
        } else {
            jsConsole.writeLine('The biggest number is third - ' + thirdNumber);
        }
    } else {
        if (secondNumber > thirdNumber) {
            jsConsole.writeLine('The biggest number is second - ' + secondNumber);
        } else {
            jsConsole.writeLine('The biggest number is third - ' + thirdNumber);
        }
    }
}
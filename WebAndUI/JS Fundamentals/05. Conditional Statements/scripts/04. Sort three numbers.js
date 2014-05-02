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

    var biggest;
    var least;
    var middle;

    if (firstNumber > secondNumber) {
        if (firstNumber > thirdNumber) {
            biggest = firstNumber;
            if (secondNumber > thirdNumber) {
                middle = secondNumber;
                least = thirdNumber;
            } else {
                middle = thirdNumber;
                least = secondNumber;
            }

        } else {
            biggest = thirdNumber;
            middle = firstNumber;
            least = secondNumber;
        }

    } else {
        if (secondNumber > thirdNumber) {
            biggest = secondNumber;
            if (firstNumber > thirdNumber) {
                middle = firstNumber;
                least = thirdNumber;
            } else {
                middle = thirdNumber;
                least = firstNumber;
            }

        } else {
            biggest = thirdNumber;
            middle = secondNumber;
            least = firstNumber;
        }
    }

    jsConsole.writeLine('The biggest number: ' + biggest);
    jsConsole.writeLine('The middle number: ' + middle);
    jsConsole.writeLine('The biggest least: ' + least);
}
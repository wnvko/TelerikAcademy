var number1;
var number2;
var number3;
var number4;
var number5;
var text1 = 'Enter number 1: ';
var text2 = 'Enter number 2: ';
var text3 = 'Enter number 3: ';
var text4 = 'Enter number 4: ';
var text5 = 'Enter number 5: ';

function setTextBoxOnFocus() {
    var textBox = document.getElementById('tb-number');
    textBox.focus();
    textBox.select();
}
setTextBoxOnFocus();

function takeValue() {
    var labelTitle = document.getElementById('label');

    switch (labelTitle.innerHTML) {
        case text1: {
            number1 = document.getElementById('tb-number').value;
            labelTitle.innerHTML = text2;
            break;
        }
        case text2: {
            number2 = document.getElementById('tb-number').value;
            labelTitle.innerHTML = text3;
            break;
        }
        case text3: {
            number3 = document.getElementById('tb-number').value;
            labelTitle.innerHTML = text4;
            break;
        }
        case text4: {
            number4 = document.getElementById('tb-number').value;
            labelTitle.innerHTML = text5;
            break;
        }
        case text5: {
            number5 = document.getElementById('tb-number').value;
            labelTitle.innerHTML = text1;
            findBiggest();
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

function findBiggest() {
    number1 = parseFloat(number1);
    number2 = parseFloat(number2);
    number3 = parseFloat(number3);
    number4 = parseFloat(number4);
    number5 = parseFloat(number5);

    if (number1 > number2 && number1 > number3 && number1 > number4 && number1 > number5) {
        jsConsole.writeLine('The biggest number is number 1 = ' + number1);

    } else if (number2 > number3 && number2 > number4 && number2 > number5) {
        jsConsole.writeLine('The biggest number is number 2 = ' + number2);

    } else if (number3 > number4 && number3 > number5) {
        jsConsole.writeLine('The biggest number is number 3 = ' + number3);

    } else if (number4 > number5) {
        jsConsole.writeLine('The biggest number is number 4 = ' + number4);

    } else {
        jsConsole.writeLine('The biggest number is number 5 = ' + number5);
    }
}
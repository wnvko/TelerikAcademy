var number;
var textBoxText = 'Enter a number: ';

function setTextBoxOnFocus() {
    var textBox = document.getElementById('tb-number');
    textBox.focus();
    textBox.select();
}

function takeValueOnEnter(e) {
    if (e.keyCode == 13) {
        takeValue();
    }
}

setTextBoxOnFocus();

function takeValue() {
    var labelTitle = document.getElementById('label');

    number = document.getElementById('tb-number').value;
    sayLastDigit(number);
    setTextBoxOnFocus();
}

function sayLastDigit(number) {
    var lastDigit = number % 10;
    switch (lastDigit) {
        case 0: {
            jsConsole.writeLine('Last digit of ' + number + ' is ZERO');
            break;
        }
        case 1: {
            jsConsole.writeLine('Last digit of ' + number + ' is ONE');
            break;
        }
        case 2: {
            jsConsole.writeLine('Last digit of ' + number + ' is TWO');
            break;
        }
        case 3: {
            jsConsole.writeLine('Last digit of ' + number + ' is THREE');
            break;
        }
        case 4: {
            jsConsole.writeLine('Last digit of ' + number + ' is FOUR');
            break;
        }
        case 5: {
            jsConsole.writeLine('Last digit of ' + number + ' is FIVE');
            break;
        }
        case 6: {
            jsConsole.writeLine('Last digit of ' + number + ' is SIX');
            break;
        }
        case 7: {
            jsConsole.writeLine('Last digit of ' + number + ' is SEVEN');
            break;
        }
        case 8: {
            jsConsole.writeLine('Last digit of ' + number + ' is EIGHT');
            break;
        }
        case 9: {
            jsConsole.writeLine('Last digit of ' + number + ' is NINE');
            break;
        }
        default: {
            jsConsole.writeLine('WTF, are you kidding me?!?');
            break;
        }
    }
}
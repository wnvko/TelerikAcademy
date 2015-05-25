var inputdigit;

function setTextBoxOnFocus() {
    var textBox = document.getElementById('tb-number');
    textBox.focus();
    textBox.select();
}
setTextBoxOnFocus();

function takeValue() {
    inputdigit = document.getElementById('tb-number').value;
    sayNumber();
    setTextBoxOnFocus();
}

function takeValueOnEnter(e) {
    if (e.keyCode == 13) {
        takeValue();
    }
}

function sayNumber() {
    inputdigit = parseInt(inputdigit);

    switch (inputdigit) {
        case 0: {
            jsConsole.writeLine(inputdigit + ' - zero');
            break;
        }
        case 1: {
            jsConsole.writeLine(inputdigit + ' - one');
            break;
        }
        case 2: {
            jsConsole.writeLine(inputdigit + ' - two');
            break;
        }
        case 3: {
            jsConsole.writeLine(inputdigit + ' - three');
            break;
        }
        case 4: {
            jsConsole.writeLine(inputdigit + ' - four');
            break;
        }
        case 5: {
            jsConsole.writeLine(inputdigit + ' - five');
            break;
        }
        case 6: {
            jsConsole.writeLine(inputdigit + ' - six');
            break;
        }
        case 7: {
            jsConsole.writeLine(inputdigit + ' - seven');
            break;
        }
        case 8: {
            jsConsole.writeLine(inputdigit + ' - eight');
            break;
        }
        case 9: {
            jsConsole.writeLine(inputdigit + ' - nine');
            break;
        }
        default: {
            jsConsole.writeLine('Please enter a digit');
            break;
        }
    }
}
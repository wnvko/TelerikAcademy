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
    var upperLimit = parseInt(Math.sqrt(number) + 1);
    var isPrime = true;

    for (var i = 2; i < upperLimit; i++) {
        if (number % i === 0) {
            isPrime = false;
            break;
        }
    }

    if (isPrime) {
        jsConsole.writeLine('Your number ' + number + ' is prime');
    } else {
        jsConsole.writeLine('Your number ' + number + ' is not prime');
    }

    setTextBoxOnFocus();
}
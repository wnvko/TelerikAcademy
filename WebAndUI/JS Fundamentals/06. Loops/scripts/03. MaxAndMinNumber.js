var startNumber;
var endNumber;
var maxNumber = -Infinity;
var minNumber = +Infinity;
var someRandomNumber;
var firstText = 'Enter start of sequence: ';
var secondText = 'Enter end of sequence: ';

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
            startNumber = document.getElementById('tb-number').value;
            labelTitle.innerHTML = secondText;
            break;
        }
        case secondText: {
            endNumber = document.getElementById('tb-number').value;
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
    startNumber = parseInt(startNumber);
    endNumber = parseInt(endNumber);

    if (endNumber < startNumber) {
        endNumber ^= startNumber;
        startNumber ^= endNumber;
        endNumber ^= startNumber;
    }

    for (var i = startNumber; i < endNumber; i++) {

        someRandomNumber = parseInt(Math.random() * 20);
        jsConsole.writeLine('Number ' + i + ': ' + someRandomNumber);


        if (i < minNumber) {
            minNumber = i;
        }

        if (i > maxNumber) {
            maxNumber = i;
        }
    }

    jsConsole.writeLine('Max number = ' + maxNumber);
    jsConsole.writeLine('Min number = ' + minNumber);
}
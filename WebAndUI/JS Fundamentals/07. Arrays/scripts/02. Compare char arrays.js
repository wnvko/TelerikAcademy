var firstCharArray = [];
var secondCharArray = [];
var firstTextBoxLabel = 'Enter first array: ';
var secondTextBoxLabel = 'Enter second array: ';
var smalerArray = [];
var biggerArray = [];

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

    switch (labelTitle.innerHTML) {
        case firstTextBoxLabel: {
            firstCharArray = document.getElementById('tb-number').value;
            labelTitle.innerHTML = secondTextBoxLabel;
            break;
        }
        case secondTextBoxLabel: {
            secondCharArray = document.getElementById('tb-number').value;
            labelTitle.innerHTML = firstTextBoxLabel;
            checkArrays();
            break;
        }
    }
}

function checkArrays() {
    var minLength = firstCharArray.length;

    if (minLength > secondCharArray.length) {
        minLength = secondCharArray.length;
    }

    for (var i = 0; i < minLength; i++) {
        if (firstCharArray[i] < secondCharArray[i]) {
            smalerArray = firstCharArray;
            biggerArray = secondCharArray;
            break;
        } else if (firstCharArray[i] > secondCharArray[i]) {
            smalerArray = secondCharArray;
            biggerArray = firstCharArray;
            break;
        }
    }

    jsConsole.writeLine('Smaller array: ' + smalerArray);
    jsConsole.writeLine('Bigger array: ' + biggerArray);
}
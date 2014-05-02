var sideA;
var sideB;
var height;
var sideAText = 'Enter side a: ';
var sideBText = 'Enter side b: ';
var heightText = 'Enter height: '

function setTextBoxOnFocus() {
    var textBox = document.getElementById('tb-number');
    textBox.focus();
    textBox.select();
}
setTextBoxOnFocus();

function takeValue() {
    var labelTitle = document.getElementById('label');

    switch (labelTitle.innerHTML) {
        case sideAText: {
            sideA = document.getElementById('tb-number').value;
            labelTitle.innerHTML = sideBText;
            break;
        }
        case sideBText: {
            sideB = document.getElementById('tb-number').value;
            labelTitle.innerHTML = heightText;
            break;
        }
        case heightText: {
            height = document.getElementById('tb-number').value;
            labelTitle.innerHTML = sideAText;
            calculateArea();
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

function calculateArea() {
    sideA = parseFloat(sideA);
    sideB = parseFloat(sideB);
    height = parseFloat(height);

    var area = ((sideA + sideB) / 2) * height;
    jsConsole.writeLine('Side a = ' + sideA);
    jsConsole.writeLine('Side b = ' + sideB);
    jsConsole.writeLine('Height =  ' + height);
    jsConsole.writeLine('Area = ' + area);
}
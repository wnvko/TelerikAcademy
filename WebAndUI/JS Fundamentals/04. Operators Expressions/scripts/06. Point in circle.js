var xValue;
var yValue;
var xText = 'Enter X: ';
var yText = 'Enter Y: '

function setTextBoxOnFocus() {
    var textBox = document.getElementById('tb-number');
    textBox.focus();
    textBox.select();
}
setTextBoxOnFocus();

function takeValue() {
    var labelTitle = document.getElementById('label');

    if (labelTitle.innerHTML == xText) {
        xValue = document.getElementById('tb-number').value;
        labelTitle.innerHTML = yText;
    } else {
        yValue = document.getElementById('tb-number').value;
        labelTitle.innerHTML = xText;
        checkPoint();
    }

    setTextBoxOnFocus();
}

function takeValueOnEnter(e) {
    if (e.keyCode == 13) {
        takeValue();
    }
}

function checkPoint() {
    var distanceToO = Math.sqrt(xValue * xValue + yValue * yValue);
    jsConsole.writeLine('Point X = ' + xValue);
    jsConsole.writeLine('Point Y = ' + yValue);

    if (distanceToO < 5) {
        jsConsole.writeLine('The point is within circle K(O, 5)');
    } else {
        jsConsole.writeLine('The point is out of circle K(O, 5)');
    }
}

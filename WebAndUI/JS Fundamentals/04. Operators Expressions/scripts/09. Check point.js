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
    jsConsole.writeLine('Point X = ' + xValue);
    jsConsole.writeLine('Point Y = ' + yValue);

    var distanceTo1_1 = Math.sqrt((xValue - 1) * (xValue - 1) + (yValue - 1) * (yValue - 1));
    var inCircle = distanceTo1_1 < 3;

    var outOfRectangle = true;
    if ((xValue >= -1) && (xValue <= 5) && ((yValue >= -1) && (yValue <= 1))) {
        outOfRectangle = false;
    }
    if (inCircle && outOfRectangle) {
        jsConsole.writeLine('The point is within circle K((1, 1), 3) and out of rectangle[(-1,1)(5,1)(5,-1)(-1,-1)]');
    } else {
        jsConsole.writeLine('The point is not within circle K((1, 1), 3) and out of rectangle[(-1,1)(5,1)(5,-1)(-1,-1)]');
    }
}

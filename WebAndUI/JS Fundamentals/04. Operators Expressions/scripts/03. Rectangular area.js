var width;
var height;
var widthText = 'Enter width: ';
var heightText = 'Enter height: '

function setTextBoxOnFocus() {
    var textBox = document.getElementById('tb-number');
    textBox.focus();
    textBox.select();
}
setTextBoxOnFocus();

function takeValue() {
    var labelTitle = document.getElementById('label');

    if (labelTitle.innerHTML == widthText) {
        width = document.getElementById('tb-number').value;
        labelTitle.innerHTML = heightText;
    } else {
        height = document.getElementById('tb-number').value;
        labelTitle.innerHTML = widthText;
        calculateArea();
    }
    setTextBoxOnFocus();
}

function takeValueOnEnter(e) {
    if (e.keyCode == 13) {
        takeValue();
    }
}

function calculateArea() {
    var area = width * height;
    jsConsole.writeLine('Width = ' + width);
    jsConsole.writeLine('Height =  ' + height);
    jsConsole.writeLine('Area = ' + area);
}

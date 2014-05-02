var a;
var b;
var c;
var aText = 'Enter a: ';
var bText = 'Enter b: ';
var cText = 'Enter c: ';

function setTextBoxOnFocus() {
    var textBox = document.getElementById('tb-number');
    textBox.focus();
    textBox.select();
}
setTextBoxOnFocus();

function takeValue() {
    var labelTitle = document.getElementById('label');

    switch (labelTitle.innerHTML) {
        case aText: {
            a = document.getElementById('tb-number').value;
            labelTitle.innerHTML = bText;
            break;
        }
        case bText: {
            b = document.getElementById('tb-number').value;
            labelTitle.innerHTML = cText;
            break;
        }
        case cText: {
            c = document.getElementById('tb-number').value;
            labelTitle.innerHTML = aText;
            evaluateEquation();
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

function evaluateEquation() {
    a = parseFloat(a);
    b = parseFloat(b);
    c = parseFloat(c);

    var det;

    det = b * b - 4 * a * c;

    if (det > 0) {
        var x1 = (-b + Math.sqrt(det)) / (2 * a);
        var x2 = (-b - Math.sqrt(det)) / (2 * a);
        jsConsole.writeLine('There are two real roots:');
        jsConsole.writeLine('First root = ' + x1);
        jsConsole.writeLine('Second root = ' + x2);
    } else if (det === 0) {
        var x = -b / (2 * a);
        jsConsole.writeLine('There is one double root:');
        jsConsole.writeLine('First root = Second root = ' + x);
    } else {
        jsConsole.writeLine('There are no real roots.');
    }
}
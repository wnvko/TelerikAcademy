var input,
    isChecked = false,
    wordCount = 0,
    lookupWord = '',
    inputText = 'Enter some text: ',
    lookupWordText = 'Enter word to look for: ';

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
        case inputText: {
            input = document.getElementById('tb-number').value;
            labelTitle.innerHTML = lookupWordText;
            break;
        }
        case lookupWordText: {
            lookupWord = document.getElementById('tb-number').value;
            labelTitle.innerHTML = inputText;
            isChecked = document.getElementById('cb-case').checked;
            setTextBoxOnFocus();
            countWords(input, lookupWord);
            countWords(input, lookupWord, isChecked); break;
        }
    }
}

function countWords(input, lookupWord, isChecked) {
    var words = [],
        counter = 0;

    switch (arguments.length) {
        case 2: {
            words = input.split(/[\s,]+/);
            break;
        }
        case 3: {
            input = input.toLowerCase();
            words = input.split(/[\s,]+/);
        }
    }
    debugger;
    for (var i = 0, length = words.length; i < length; i++) {
        if (words[i] === lookupWord) {
            counter++;
        }
    }

    jsConsole.writeLine('lookup word ' + lookupWord + ' appears ' + counter + ' times in the text');
}
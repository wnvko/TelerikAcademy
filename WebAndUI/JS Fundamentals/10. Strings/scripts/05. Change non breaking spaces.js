function changeWhiteSpaces(input) {
    var changedText = input.split(' ').filter(function (n) {
        return n != ''
    }).join('&nbsp;');

    return changedText;
}

var input = 'Sample site text more text and more... in body';
var changedText = changeWhiteSpaces(input);

console.log(input);
console.log(changedText);
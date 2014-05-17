function checkBrackets(input) {
    var isCorrect = true;
    var bracketStorage = [];

    for (var i = 0, length = input.length; i < length; i++) {
        if (input[i] === '(') {
            bracketStorage.push(input[i]);
            continue;
        } else if (input[i] === ')') {
            if (bracketStorage.length > 0) {
                bracketStorage.pop();
                continue;
            } else {
                isCorrect = false;
                return isCorrect;
            }
        } else {
            continue;
        }
    }

    if (bracketStorage.length > 0) {
        isCorrect = false;
        return isCorrect;
    } else {
        isCorrect = true;
        return isCorrect;
    }
}

expressionOne = '((a+b)/5-d)';
expressionTwo = ')(a+b))';
expressionTree = '(a+b)/(5-d))';

console.log(expressionOne);
console.log(checkBrackets(expressionOne));

console.log(expressionTwo);
console.log(checkBrackets(expressionTwo));

console.log(expressionTree);
console.log(checkBrackets(expressionTree));
var length = 30,
    numbers = [],
    maxSame = 1,
    currentSame = 1,
    startSequence = 0;

for (var i = 0; i < length; i++) {
    numbers[i] = (Math.random() * 3 + 1) | 0;
}

for (var i = 1; i < length; i++) {
    if (numbers[i - 1] === numbers[i]) {
        currentSame++;
    } else {
        currentSame = 1;
    }

    if (currentSame > maxSame) {
        maxSame = currentSame;
        startSequence = i - maxSame + 2;
    }
}

jsConsole.writeLine(numbers.join(', '));
jsConsole.writeLine('Maximal sequence of equal elements is ' + maxSame + ' starting at ' + startSequence + ' possition.');

var length = 30,
    numbers = [],
    maxIncreasing = 1,
    currentIncreasing = 1,
    startSequence = 0;

for (var i = 0; i < length; i++) {
    numbers[i] = (Math.random() * 10 + 1) | 0;
}

for (var i = 1; i < length; i++) {
    if (numbers[i - 1] < numbers[i]) {
        currentIncreasing++;
    } else {
        currentIncreasing = 1;
    }

    if (currentIncreasing > maxIncreasing) {
        maxIncreasing = currentIncreasing;
        startSequence = i - maxIncreasing + 2;
    }
}

jsConsole.writeLine(numbers.join(', '));
jsConsole.writeLine('Maximal increasing sequence of elements is ' + maxIncreasing + ' starting at ' + startSequence + ' possition.');

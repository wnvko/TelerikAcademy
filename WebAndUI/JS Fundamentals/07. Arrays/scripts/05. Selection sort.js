var length = 30,
    numbers = [],
    minIndex = 0,
    currentMin = Infinity;

for (var i = 0; i < length; i++) {
    numbers[i] = (Math.random() * 100 + 1) | 0;
}

jsConsole.writeLine('Initial arra:');
jsConsole.writeLine(numbers.join(', '));
jsConsole.writeLine('');

for (var i = 0; i < length; i++) {
    for (var j = i ; j < length; j++) {
        if (numbers[j] < currentMin) {
            currentMin = numbers[j];
            minIndex = j;
        }
    }

    numbers[minIndex] = numbers[i];
    numbers[i] = currentMin;
    minIndex = 0;
    currentMin = Infinity;
}

jsConsole.writeLine('Sorted array:');
jsConsole.writeLine(numbers.join(', '));
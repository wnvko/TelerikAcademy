var length = 30,
    numbers = [],
    mostFrequentlyCount = 0,
    mostFrequently = 0;
    dictionary = {};

for (var i = 0; i < length; i++) {
    numbers[i] = (Math.random() * 10 - 4) | 0;
}

jsConsole.writeLine('Initial arra:');
jsConsole.writeLine(numbers.join(', '));
jsConsole.writeLine('');

for (var i = 0; i < length; i++) {
    if (isNaN(dictionary[numbers[i]])) {
        dictionary[numbers[i]] = 1;
    } else {
        dictionary[numbers[i]]++;
    }
}

for (var prop in dictionary) {
    jsConsole.writeLine('Number ' + prop + ' - ' + dictionary[prop] + ' times');
    if (dictionary[prop] > mostFrequentlyCount) {
        mostFrequentlyCount = dictionary[prop];
        mostFrequently = prop;
    }
}

jsConsole.writeLine('Most frequently number is ' + mostFrequently + ' - ' + mostFrequentlyCount + ' times');

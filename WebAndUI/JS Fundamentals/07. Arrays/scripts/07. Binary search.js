var length = 30,
    currentMin = Infinity,
    minIndex = 0;
    numbers = [],
    lookUpNumber = 0,
    numberPossition = 0;
    currentMin = Infinity;

for (var i = 0; i < length; i++) {
    numbers[i] = (Math.random() * 30 + 1) | 0;
}

numbers = selectionSort(numbers);

lookUpNumber = (Math.random() * 30 + 1) | 0;

jsConsole.writeLine('Initial arra:');
jsConsole.writeLine(numbers.join(', '));
jsConsole.writeLine('');

numberPossition = binarySearch(numbers, lookUpNumber, 0, numbers.length);

jsConsole.writeLine(lookUpNumber + ' is on possition ' + numberPossition);

function binarySearch(sortedArray, lookUpValue, minValue, maxValue) {
    if (minValue > maxValue) {
        return -1;
    } else {
        var midValue = ((minValue + maxValue) / 2);

        if (sortedArray[midValue] > lookUpValue) {
            return binarySearch(sortedArray, lookUpValue, minValue, midValue - 1);
        } else if (sortedArray[midValue] < lookUpValue) {
            return binarySearch(sortedArray, lookUpValue, midValue + 1, maxValue);
        } else {
            return midValue;
        }
    }
}

function selectionSort(array) {
    for (var i = 0, length = array.length; i < length; i++) {
        for (var j = i ; j < length; j++) {
            if (array[j] < currentMin) {
                currentMin = array[j];
                minIndex = j;
            }
        }

        array[minIndex] = array[i];
        array[i] = currentMin;
        minIndex = 0;
        currentMin = Infinity;
    }

    return array;
}


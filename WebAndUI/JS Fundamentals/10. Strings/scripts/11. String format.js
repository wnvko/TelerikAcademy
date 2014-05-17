function stringFormat(input) {
    var placeHolders = [];
    for (var i = 1; i < arguments.length; i++) {
        placeHolders.push(arguments[i]);
    }

    var outputText = '';
    var possition = 0;
    var placeHolderEnd = 0;

    while (true) {
        possition = input.indexOf('{', possition);
        if (possition < 0) {
            break;
        }

        placeHolderEnd = input.indexOf('}', possition);
        var placeHolderIndex = input.substring(possition + 1, placeHolderEnd) | 0;

        outputText = input.substring(0, possition) + placeHolders[placeHolderIndex] + input.substring(placeHolderEnd + 1);
        input = outputText;

        possition++;
    }

    return outputText;
}

input = '{0}, {1}, {0} text {2}';
output = stringFormat(input, 1, 'Pesho', 'Gosho');

console.log(input);
console.log(output);
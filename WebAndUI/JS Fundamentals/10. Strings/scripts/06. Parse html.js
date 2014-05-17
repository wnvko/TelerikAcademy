function parseHTML(input) {
    var counter = 0;
    var parsed = [];
    var inTag = false;

    while (true) {
        var currentSymbol = input[counter++];

        if (counter === input.length) {
            break;
        }

        if (currentSymbol === '<') {
            inTag = true;
            continue;
        } else if (currentSymbol === '>') {
            inTag = false;
            continue;
        } else if (inTag) {
            continue;
        } else {
            parsed.push(currentSymbol);
        }
    }

    return parsed.join('');
}

var input = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';
var parsed = parseHTML(input);

console.log(input);
console.log(parsed);
function parseAnchorTag(input) {
    var counter = 0;
    var isTagOpen = false;
    parsedText = [];

    while (true) {
        if (counter < input.length) {
            var currentSymbol = input[counter++];

            if (currentSymbol === '<' && (input[counter] === 'a' || input[counter+1] === 'a')) {
                if (isTagOpen) {
                    parsedText.push('[/URL]');
                    counter += 3;
                    isTagOpen = false;
                    continue;
                } else {
                    parsedText.push('[URL=');
                    counter += 8;
                    isTagOpen = true;
                    continue;
                }
            } else if (isTagOpen && currentSymbol === '"') {
                parsedText.push(']');
                counter++;
                continue;
            } else {
                parsedText.push(currentSymbol);
            }
        } else {
            break;
        }
    }

    return parsedText.join('');
}

var input = '<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';var parsed = parseAnchorTag(input);console.log(input);console.log(parsed);
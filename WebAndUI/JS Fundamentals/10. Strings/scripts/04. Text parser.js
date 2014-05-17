function parseInput(input) {

    var parsed = [];
    var counter = 0;
    var len = input.length;
    var upCase = false;
    var lowCase = false;
    var mixCase = false;
    var textToChange = [];

    while (true) {
        var currentSymbol = input[counter++];

        if (currentSymbol === '<') {
            if (counter < len) {
                switch (input[counter]) {
                    case '/':
                        {
                            closeTag();
                            break;
                        }
                    case 'u':
                        {
                            turnOnUpcase();
                            break;
                        }
                    case 'l':
                        {
                            turnOnLowpcase();
                            break;
                        }
                    case 'm':
                        {
                            turnOnMixpcase();
                            break;
                        }
                    default:
                        {
                            console.log('I am afraid you have some bugs');
                            break;
                        }
                }
            }

            continue;
        } else if (upCase || lowCase || mixCase) {
            textToChange.push(currentSymbol);
        } else {
            parsed.push(currentSymbol);
        }

        if (counter === len) {
            break;
        }
    }

    function closeTag() {
        counter++;
        currentSymbol = input[counter];

        switch (currentSymbol) {

            // mixedcase ended
            case 'm': {
                for (var i = 0, length = textToChange.length; i < length; i++) {
                    var rnd = ~~(Math.random() * 2);
                    currentSymbol = textToChange[i];

                    if (rnd === 0) {
                        currentSymbol = currentSymbol.toLocaleLowerCase();
                    } else {
                        currentSymbol = currentSymbol.toUpperCase();
                    }

                    parsed.push(currentSymbol);
                }

                counter += 8;
                mixCase = false;
                break;
            }

                // upercase ended
            case 'u': {
                counter += 7;
                textToChange = textToChange.join('').toUpperCase();
                parsed.push(textToChange);
                upCase = false;
                break;
            }

                // lowercase ended
            case 'l': {
                counter += 8;
                textToChange = textToChange.join('').toLocaleLowerCase();
                parsed.push(textToChange);
                lowCase = false;
                break;
            }
            default: {
                console.log('I afraid you have some bugs');
                break;
            }
        }

        textToChange = [];
    }

    function turnOnUpcase() {
        upCase = true;
        counter += 7;
    }

    function turnOnLowpcase() {
        lowCase = true;
        counter += 8;
    }

    function turnOnMixpcase() {
        mixCase = true;
        counter += 8;
    }

    return parsed.join('');
}

var input = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";
console.log(input);

var parsed = parseInput(input);
console.log(parsed);
var specialConsole = (function () {

    function getArguments() {
        var arguments = arguments[0],
            message = arguments[0],
            formatsCount = arguments.length,
            formats = [];

        for (var i = 1; i < formatsCount; i++) {
            formats.push(arguments[i]);
        }

        return {
            message: message,
            formats: formats,
        }
    }

    function writeLine() {
        var messageArguments = getArguments(arguments),
            message = messageArguments.message,
            formats = messageArguments.formats,
            formatsCount = formats.length;

        for (var i = 0; i < formatsCount; i++) {
            var placeHolder = '{' + i + '}';
            while (true) {
                if (message.indexOf(placeHolder) > -1) {
                    message = message.replace(placeHolder, formats[i]);
                } else {
                    break;
                }
            }
        }

        console.log(message);
    }

    function writeError() {
        var messageArguments = getArguments(arguments),
            message = messageArguments.message,
            formats = messageArguments.formats,
            formatsCount = formats.length;

        for (var i = 0; i < formatsCount; i++) {
            var placeHolder = '{' + i + '}';
            while (true) {
                if (message.indexOf(placeHolder) > -1) {
                    message = message.replace(placeHolder, formats[i]);
                } else {
                    break;
                }
            }
        }

        console.log(message);
    }

    function writeWarning() {
        var messageArguments = getArguments(arguments),
            message = messageArguments.message,
            formats = messageArguments.formats,
            formatsCount = formats.length;

        for (var i = 0; i < formatsCount; i++) {
            var placeHolder = '{' + i + '}';
            while (true) {
                if (message.indexOf(placeHolder) > -1) {
                    message = message.replace(placeHolder, formats[i]);
                } else {
                    break;
                }
            }
        }

        console.log(message);
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning,
    }
}());

specialConsole.writeLine('Message', 'one', 'two', 'three');
specialConsole.writeLine('Message');
specialConsole.writeLine('{0}{1}{1}{2}{3}{0}', 'one', 'two', 'three');
specialConsole.writeError("Error: {0}", "Something happened");
specialConsole.writeWarning("Warning: {0}", "A warning");

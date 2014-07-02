function Solve(input) {
    var answer = [];
    var keyValuePairs = parseInt(input[0]);
    var dictionary = [];

    var inputRows = parseInt(input[keyValuePairs + 1]);
    var row = keyValuePairs + 2;
    var endRow = inputRows + keyValuePairs + 2;

    getDictionary();
    parseModels();

    //templates
    var templateRows = [];
    var htmlBodyStart = 0;
    var templates = [];

    while (true) {

        if (row >= endRow) {
            break;
        }

        var currentRow = input[row];
        if (currentRow.indexOf('template') !== -1) {
            templateRows.push(row);
        }

        if (currentRow.indexOf('DOCTYPE') !== -1) {
            htmlBodyStart = row;
            break;
        }

        row++;
    }

    for (var i = 0; i < templateRows.length; i++) {
        var startRow = input[templateRows[i]];
        var endName = startRow.indexOf('>') - 1;
        var startName = startRow.indexOf('"') + 1;
        var currentName = startRow.substring(startName, endName);
        var currentMenu = {
            name: undefined,
            content: undefined
        };
        var content = [];

        for (var j = templateRows[i] + 1; j < templateRows[i + 1]; j++) {
            content.push(input[j])
        }

        content = content.join('\n');
        currentMenu.name = currentName;
        currentMenu.content = content;
        templates.push(currentMenu);
        i++;
    }

    row = htmlBodyStart;

    while (true) {

        if (row >= endRow) {
            break;
        }

        var currentRow = input[row];

        if (currentRow.indexOf('template') !== -1) {
            var startRender = currentRow.indexOf('"') + 1;
            var endRender = currentRow.lastIndexOf('"');
            var templateName = currentRow.substring(startRender, endRender);

            for (var i in templates) {
                console.log(templates[i].name);

                if (templates[i].name === templateName) {
                    console.log(answer[row]);
                    answer[row] = templates[i].content;
                    console.log(answer[row]);
                    break;
                }
            }
        }

        row++;
    }

    //templates

    answer = answer.join('\n');
    return answer;

    function getDictionary() {
        for (var key = 1; key <= keyValuePairs; key++) {
            var currentPair = input[key].split('-');

            if (currentPair[1].indexOf(';') !== -1) {
                currentPair[1] = currentPair[1].split(';');
            }

            var pair = {
                key: currentPair[0],
                value: currentPair[1]
            };

            dictionary.push(pair);
        }
    }
    function parseModels() {

        for (row ; row < endRow; row++) {
            var currentRow = input[row];

            if (currentRow.indexOf('nk-model') !== -1) {
                var start = currentRow.indexOf('nk-model', 0);
                var end = currentRow.indexOf('nk-model', start + 1);
                var modelKey = currentRow.substring(start + 9, end - 2);
                var value = '';

                for (var key in dictionary) {
                    if (dictionary[key].key === modelKey) {
                        value = dictionary[key].value;
                        break;
                    }
                }

                currentRow = currentRow.replace(modelKey, value);
                currentRow = currentRow.replace('</nk-model>', '');
                currentRow = currentRow.replace('<nk-model>', '');
                input[row] = currentRow;

            }

            answer.push(input[row]);
        }
    }
}

input = [
'6',
'title-Telerik Academy',
'showSubtitle-true',
'subTitle-Free training',
'showMarks-false',
'marks-3;4;5;6',
'students-Ivan;Gosho;Pesho',
'42',
'<nk-template name="menu">',
'    <ul id="menu">',
'        <li>Home</li>',
'        <li>About us</li>',
'    </ul>',
'</nk-template>',
'<nk-template name="footer">',
'    <footer>',
'        Copyright Telerik Academy 2014',
'    </footer>',
'</nk-template>',
'<!DOCTYPE html>',
'<html>',
'<head>',
'    <title>Telerik Academy</title>',
'</head>',
'<body>',
'    <nk-template render="menu" />',
'',
'    <h1><nk-model>title</nk-model></h1>',
'    <nk-if condition="showSubtitle">',
'        <h2><nk-model>subTitle</nk-model></h2>',
'        <div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
'    </nk-if>',
'',
'    <ul>',
'        <nk-repeat for="student in students">',
'            <li>',
'                <nk-model>student</nk-model>',
'            </li>',
'            <li>Multiline <nk-model>title</nk-model></li>',
'        </nk-repeat>',
'    </ul>',
'    <nk-if condition="showMarks">',
'        <div>',
'            <nk-model>marks</nk-model> ',
'        </div>',
'    </nk-if>',
'',
'    <nk-template render="footer" />',
'</body>',
'</html>'
];

//console.log(Solve(input));
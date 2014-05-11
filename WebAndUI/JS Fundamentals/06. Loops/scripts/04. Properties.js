var documentFirst;
var documentLast;
var windowFirst;
var windowLast;
var navigatorFirst;
var navigatorLast;

var documentProperties;
var windowProperties;
var navigatorProperties;

documentProperties = Document;
documentFirst = findFirstAndLastInColection(documentProperties).first;
documentLast = findFirstAndLastInColection(documentProperties).last;

windowProperties = Window;
windowFirst = findFirstAndLastInColection(windowProperties).first;
windowLast = findFirstAndLastInColection(windowProperties).last;

navigatorProperties = Navigator;
navigatorFirst = findFirstAndLastInColection(navigatorProperties).first;
navigatorLast = findFirstAndLastInColection(navigatorProperties).last;

jsConsole.writeLine(documentFirst);
jsConsole.writeLine(documentLast);
jsConsole.writeLine(windowFirst);
jsConsole.writeLine(windowLast);
jsConsole.writeLine(navigatorFirst);
jsConsole.writeLine(navigatorLast);


function findFirstAndLastInColection(properties) {
    var borderEntities = {
        first: 'Z',
        last: 'A',
    };

    for (var property in properties) {
        if (borderEntities.first > property) {
            borderEntities.first = property;
        }

        if (borderEntities.last < property) {
            borderEntities.last = property;
        }
    }

    return borderEntities;
}
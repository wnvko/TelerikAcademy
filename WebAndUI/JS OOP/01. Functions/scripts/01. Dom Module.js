var domModule = (function () {
    var appendChild,
        removeChild,
        addHandler,
        appendToBuffer;

    appendChild = function (child, parentSelector) {
        var theParent = document.querySelector(parentSelector),
            theChildNodeType = child.nodeType;

        if (theChildNodeType === 1 && theParent) {
            theParent.appendChild(child);
        }
    };

    removeChild = function (parentSelector, childSelector) {
        var theParent = document.querySelector(parentSelector),
            theChild = document.querySelectorAll(childSelector),
            i,
            len;

        if (theParent && theChild) {
            i = 0,
            len = theChild.length;


            for (i; i < len; i++) {
                if (theChild[i].parentNode === theParent) {
                    theChild[i].parentNode.removeChild(theChild[i]);
                }
            }
        }
    };

    addHandler = function (elementSelector, event, functionName) {
        var theElement = document.querySelectorAll(elementSelector),
            isFunction = typeof (functionName) === 'function';

        if (theElement && isFunction) {
            var i = 0,
                len = theElement.length;

            for (i; i < len; i++) {
                theElement[i].addEventListener(event, functionName);
            }
        }
    };

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
    };
}());

var div = document.createElement('table');
domModule.appendChild(div, '#wrapper');

domModule.removeChild('ul', 'li:first-child');
domModule.addHandler('a.button', 'click', function () { alert('Clicked') });
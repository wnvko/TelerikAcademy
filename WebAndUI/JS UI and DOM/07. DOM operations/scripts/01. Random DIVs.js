var dFrag = document.createDocumentFragment();

function getRandomProperties() {
    var randomProperties = {
        width: parseInt(Math.random() * 80) + 20,
        height: parseInt(Math.random() * 80) + 20,
        fontColor: 'RGB(' + parseInt(Math.random() * 255) + ',' + parseInt(Math.random() * 255) + ',' + parseInt(Math.random() * 255) + ')',
        possition: {
            x: parseInt(Math.random() * 1200),
            y: parseInt(Math.random() * 400)
        },
        borderRaduis: parseInt(Math.random() * 20),
        borderColor: 'RGB(' + parseInt(Math.random() * 255) + ',' + parseInt(Math.random() * 255) + ',' + parseInt(Math.random() * 255) + ')',
        borderWidth: parseInt(Math.random() * 20)
    }

    return randomProperties;
}

for (var i = 0; i < 20; i++) {
    var currentDiv = document.createElement('div'),
        divProperties = getRandomProperties(),
        strongElement = document.createElement('strong');

    strongElement.textContent = 'div'

    currentDiv.setAttribute('id', 'Number: ' + i);
    currentDiv.setAttribute(
        'style', 'width:' + divProperties.width + 'px;' +
                 'height:' + divProperties.height + 'px;' +
                 'color:' + divProperties.fontColor + ';' +
                 'position: absolute;' +
                 'left:' + divProperties.possition.x + 'px;' +
                 'top:' + divProperties.possition.y + 'px;' +
                 'border-radius:' + divProperties.borderRaduis + 'px;' +
                 'border-width:' + divProperties.borderWidth + 'px;' +
                 'border-color:' + divProperties.borderColor + ';' +
                 'border-style: solid;');

    currentDiv.appendChild(strongElement);
    dFrag.appendChild(currentDiv);
}

document.body.appendChild(dFrag);
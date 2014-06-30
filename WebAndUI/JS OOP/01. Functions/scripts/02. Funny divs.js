var movingShapes = (function () {
    var recCounter = 0,
        ellipseCounter = 0,
        animation,
        mouseX,
        mouseY,
        step = 0,
        angle = 0,
        sizeX = 200,
        sizeY = 120;

    document.onmousemove = getMousePosition;

    function getMousePosition(e) {
        mouseX = e.pageX;
        mouseY = e.pageY;
    }

    function getRandomProperties() {
        var randomProperties = {
            width: 20,
            height: 20,
            fontColor: 'RGB(' + parseInt(Math.random() * 255) + ',' + parseInt(Math.random() * 255) + ',' + parseInt(Math.random() * 255) + ')',
            borderColor: 'RGB(' + parseInt(Math.random() * 255) + ',' + parseInt(Math.random() * 255) + ',' + parseInt(Math.random() * 255) + ')',
            backgroundColor: 'RGB(' + parseInt(Math.random() * 255) + ',' + parseInt(Math.random() * 255) + ',' + parseInt(Math.random() * 255) + ')',
        }

        return randomProperties;
    }

    function createRandomDiv() {
        var randomDiv = document.createElement('div'),
                divProperties = getRandomProperties(),
                strongElement = document.createElement('strong');

        strongElement.textContent = 'div'

        randomDiv.style.width = divProperties.width + 'px;';
        randomDiv.style.height = divProperties.height + 'px;';
        randomDiv.style.position = 'absolute';
        randomDiv.style.color = divProperties.fontColor;
        randomDiv.style.borderColor = divProperties.borderColor;
        randomDiv.style.borderWidth = '2px';
        randomDiv.style.borderStyle = 'solid';
        randomDiv.style.backgroundColor = divProperties.backgroundColor;

        randomDiv.appendChild(strongElement);

        return randomDiv;
    }

    function add(type) {
        if (type === 'rect') {
            var currentDiv = createRandomDiv();
            currentDiv.className = 'rect ';
            currentDiv.className += '#' + recCounter;
            document.body.appendChild(currentDiv);
            recCounter++;

            rectAnimation = setInterval(function () {
                var rectElements = document.querySelectorAll('.rect'),
                    rectCount = rectElements.length,
                    rectDiv;

                step += 5;

                for (var i = 0; i < rectCount; i++) {
                    var perimeter = (sizeX * 2 + sizeY * 2) * 2,
                        possition = step + perimeter * i / rectCount,
                        rounds = 0,
                        x,
                        y;

                    if (possition >= perimeter) {
                        step = 0;
                        possition = 0;
                    }

                    x = 0;
                    y = sizeY * 2 - (possition - sizeX * 4 - sizeY * 2);

                    if (possition <= (sizeX * 4 + sizeY * 2)) {
                        x = sizeX * 2 - (possition - sizeX * 2 - sizeY * 2);
                        y = sizeY * 2;
                    }

                    if (possition <= (sizeX * 2 + sizeY * 2)) {
                        x = sizeX * 2;
                        y = possition - sizeX * 2;
                    }

                    if (possition <= sizeX * 2) {
                        x = possition;
                        y = 0;
                    }

                    x += mouseX - sizeX;
                    y += mouseY - sizeY;

                    rectDiv = rectElements[i];
                    rectDiv.style.left = x + 'px';
                    rectDiv.style.top = y + 'px';
                }
            }, 100);

        }

        if (type === 'ellipse') {
            var currentDiv = createRandomDiv();
            currentDiv.className = 'ellipse ';
            currentDiv.className += '#' + ellipseCounter;
            document.body.appendChild(currentDiv);
            ellipseCounter++;

            ellipseAnimation = setInterval(function () {
                var ellipsElements = document.querySelectorAll('.ellipse'),
                    ellipseCount = ellipsElements.length,
                    ellipseDiv;

                angle += 0.1;

                for (var i = 0; i < ellipseCount; i++) {
                    var currentAngle = angle + i * 2 * Math.PI / ellipseCount,
                        x = mouseX + sizeX * Math.cos(currentAngle) / 2,
                        y = mouseY + sizeY * Math.sin(currentAngle) / 2;

                    ellipseDiv = ellipsElements[i];
                    ellipseDiv.style.left = x + 'px';
                    ellipseDiv.style.top = y + 'px';
                }
            }, 100);
        }
    }

    return {
        add: add,
    };
}());

var rectButton = document.getElementById('addRect'),
    ellipseButton = document.getElementById('addEllipse');

rectButton.addEventListener('click', function () { movingShapes.add('rect'); });
ellipseButton.addEventListener('click', function () { movingShapes.add('ellipse'); });

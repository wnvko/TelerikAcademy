var paper = Raphael(250, 10, 500, 500);

function drawSpyral() {
    paper.clear();

    var radius = 0,
        angle = 0,
        startX = 0,
        startY = 0,
        endX = paper.width / 2,
        endY = paper.height / 2,
        pathString = '',
        spyral,
        b;

    b = document.getElementById('b').value;

    if (b <= 0) {
        b = 5;
    }

    while (true) {
        startX = endX;
        startY = endY;

        radius = b * angle;
        angle += 0.1;

        endX = paper.width / 2 + radius * Math.cos(angle);
        endY = paper.height / 2 + radius * Math.sin(angle);

        pathString = 'M' + startX + ',' + startY + ' L' + endX + ',' + endY;
        spyral = paper.path(pathString);

        if (startX >= paper.width || startY >= paper.height) {
            break;
        }
    }
}
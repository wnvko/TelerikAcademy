var dFrag = document.createDocumentFragment(),
    width = '80px;',
    height = '50px;',
    border = '2px solid black;',
    mouseX = 0,
    mouseY = 0,
    radius = 150,
    angle = 0;


for (var i = 0; i < 5; i++) {
    var newDiv = document.createElement('div');

    newDiv.style.width = width;
    newDiv.style.height = height;
    newDiv.style.borderStyle = border;
    newDiv.style.position = 'absolute';
    newDiv.id = i;

    //newDiv.setAttribute(
    //'style', 'width:' + width +
    //         'height:' + height +
    //         'border:' + border +
    //         'position: absolute;');

    //newDiv.setAttribute('id', i);
    dFrag.appendChild(newDiv);
}

document.body.appendChild(dFrag);
animation;

var animation = setInterval(function () {
    angle += 0.1;

    for (var i = 0; i < 5; i++) {
        var currentAngle = angle + i * 2 * Math.PI / 5,
            x = mouseX - 40 + radius * Math.cos(currentAngle),
            y = mouseY - 25 + radius * Math.sin(currentAngle);

        currentDiv = document.getElementById(i);
        currentDiv.style.left = x + 'px';
        currentDiv.style.top = y + 'px';
    }
}, 100);

document.onmousemove = getMousePosition;

function getMousePosition(e) {
    mouseX = e.pageX;
    mouseY = e.pageY;
}
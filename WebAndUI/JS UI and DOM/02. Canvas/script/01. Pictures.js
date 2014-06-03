var canvas = document.getElementById("my-canvas");

var bicycleStartPoint = {
    x: 70,
    y: 350
};
drawBicycle(bicycleStartPoint);

var headStartPoint = {
    x: 200,
    y: 150
};
drawHead(headStartPoint);

function drawBicycle(startPoint) {
    var ctxBicycle = canvas.getContext('2d'),
        x = startPoint.x,
        y = startPoint.y;

    ctxBicycle.fillStyle = "rgb(142,200,213)";
    ctxBicycle.strokeStyle = "rgb(49,121,139)";
    ctxBicycle.lineWidth = 4;
    //left wheel
    drawCircle(ctxBicycle, x, y, 50, true);

    //right wheel
    drawCircle(ctxBicycle, x + 200, y, 50, true);

    //pedals wheel
    ctxBicycle.lineWidth = 2;
    drawCircle(ctxBicycle, x + 100, y, 15, false);

    //frame
    //left triangel
    drawLine(ctxBicycle, x, y, x + 100, y);
    drawLine(ctxBicycle, x + 100, y, x + 60, y - 80);
    drawLine(ctxBicycle, x + 60, y - 80, x, y);

    //right triangle
    drawLine(ctxBicycle, x + 60, y - 80, x + 180, y - 80);
    drawLine(ctxBicycle, x + 180, y - 80, x + 100, y);

    //front wheel holder
    drawLine(ctxBicycle, x + 180, y - 80, x + 200, y);

    //handle-bar
    drawLine(ctxBicycle, x + 180, y - 80, x + 173, y - 108);
    drawLine(ctxBicycle, x + 173, y - 108, x + 133, y - 98);
    drawLine(ctxBicycle, x + 173, y - 108, x + 183, y - 148);

    //seat
    drawLine(ctxBicycle, x + 60, y - 80, x + 45, y - 110);
    drawLine(ctxBicycle, x + 20, y - 110, x + 70, y - 110);
}

function drawHead(startPoint) {
    var ctxHead = canvas.getContext('2d'),
        x = startPoint.x,
        y = startPoint.y;

    ctxHead.fillStyle = "rgb(142,200,213)";
    ctxHead.strokeStyle = "rgb(32,81,92)";
    ctxHead.lineWidth = 4;

    //the head
    drawCircle(ctxHead, x, y, 40, true);

    //left eye
    drawElipse(ctxHead, x - 25, y - 10, 10, 5, true);
    drawElipse(ctxHead, x - 28, y - 10, 1, 2, true);

    //right eye
    drawElipse(ctxHead, x + 10, y - 10, 10, 5, true);
    drawElipse(ctxHead, x + 7, y - 10, 1, 2, true);

    //the nose
    ctxHead.beginPath();
    ctxHead.moveTo(x - 7, y - 10);
    ctxHead.lineTo(x - 15, y + 10);
    ctxHead.lineTo(x - 2, y + 10);
    ctxHead.stroke();

    //the mouth
    drawElipse(ctxHead, x - 5, y + 25, 13, 5, true);

    ctxHead.fillStyle = "rgb(57,102,147)";
    ctxHead.strokeStyle = "black";
    drawElipse(ctxHead, x, y - 35, 50, 10, true);
    drawElipse(ctxHead, x, y - 44, 30, 6, true, 0, Math.PI);
    ctxHead.beginPath();
    ctxHead.moveTo(x - 30, y - 44);
    ctxHead.lineTo(x - 30, y - 100);
    ctxHead.lineTo(x + 30, y - 100);
    ctxHead.lineTo(x + 30, y - 44);
    ctxHead.stroke();
    ctxHead.fill();
    drawElipse(ctxHead, x, y - 100, 30, 6, true);

}

function drawCircle(ctx, centerX, centerY, radius, hasFill, startAngle, endAngle) {
    startAngle = (startAngle || 0);
    endAngle = (endAngle || (2 * Math.PI));

    ctx.beginPath()
    ctx.arc(centerX, centerY, radius, startAngle, endAngle)
    ctx.stroke();
    if (hasFill) {
        ctx.fill();
    }
}

function drawElipse(ctx, centerX, centerY, radiusX, radiusY, hasFill, startAngle, endAngle) {
    var axisRatio = radiusY / radiusX;
    startAngle = (startAngle || 0);
    endAngle = (endAngle || (2 * Math.PI));

    ctx.save();
    ctx.scale(1, axisRatio);
    ctx.beginPath();
    ctx.arc(centerX, centerY / axisRatio, radiusX, startAngle, endAngle);
    ctx.stroke();
    if (hasFill) {
        ctx.fill();
    }
    ctx.restore();
}

function drawLine(ctx, startX, startY, endX, endY) {
    ctx.beginPath();
    ctx.moveTo(startX, startY);
    ctx.lineTo(endX, endY);
    ctx.stroke();
}

var canvas = document.getElementById('my-canvas'),
	ctx = canvas.getContext('2d'),
	currentPosition = {
		x: canvas.width / 2,
		y: canvas.height / 2
	},
	radius = 50,
	offsetX = 3,
	offsetY = 3,
	showPosition = document.getElementById('ball-position');

ctx.strokeStyle = 'white';
ctx.lineWidth = 3;


function movingBall() {
	ctx.clearRect(0, 0, canvas.width, canvas.height);
	ctx.strokeRect(0, 0, canvas.width, canvas.height);
	ctx.fillStyle = 'brown';
	ctx.fillRect(0, 0, canvas.width, canvas.height);
	showPosition.innerHTML = 'X: = ' + (currentPosition.x - radius) + ' Y: = ' + (currentPosition.y - radius);
	
	ctx.fillStyle = 'white';
	drawCircle(ctx, currentPosition.x, currentPosition.y, radius, true);

	if (currentPosition.x < radius) {
		offsetX *= (-1);
		currentPosition.x = radius;
	}

	if (currentPosition.x > (canvas.width - radius)) {
		offsetX *= (-1);
		currentPosition.x = (canvas.width - radius);
	}

	if (currentPosition.y < radius) {
		offsetY *= (-1);
		currentPosition.y = radius;
	}

	if (currentPosition.y > (canvas.height - radius)) {
		offsetY *= (-1);
		currentPosition.y = (canvas.height - radius);
	}

	currentPosition.x += offsetX;
	currentPosition.y += offsetY;

	setTimeout(movingBall, 10);
}

movingBall();


function drawCircle(ctx, centerX, centerY, radius, hasFill, startAngle, endAngle) {
	startAngle = (startAngle || 0);
	endAngle = (endAngle || (2 * Math.PI));

	ctx.beginPath()
	ctx.arc(centerX, centerY, radius, startAngle, endAngle)

	if (hasFill) {
		ctx.fill();
	}

	ctx.stroke();
}

function drawElipse(ctx, centerX, centerY, radiusX, radiusY, hasFill, startAngle, endAngle) {
	var axisRatio = radiusY / radiusX;
	startAngle = (startAngle || 0);
	endAngle = (endAngle || (2 * Math.PI));

	ctx.save();
	ctx.scale(1, axisRatio);
	ctx.beginPath();
	ctx.arc(centerX, centerY / axisRatio, radiusX, startAngle, endAngle);
	ctx.restore();

	if (hasFill) {
		ctx.fill();
	}

	ctx.stroke();
}
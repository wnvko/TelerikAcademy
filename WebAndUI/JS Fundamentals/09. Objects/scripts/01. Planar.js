var pointA = createPoint(10, 5);
var pointB = createPoint(5, 5);
var pointC = createPoint(6, 8);

console.log(pointA.toString());
console.log(pointB.toString());
console.log(pointC.toString());

var lineAB = createLine(pointA, pointB);
var lineBC = createLine(pointB, pointC);
var lineCA = createLine(pointC, pointA);

console.log(lineAB.toString());
console.log(lineBC.toString());
console.log(lineCA.toString());

console.log(lineAB.length());

var isABCtriangle = checkIfIsTriangle(pointA, pointB, pointC);
console.log(isABCtriangle);



function createPoint(x, y) {
    return {
        x: x,
        y: y,
        toString: function () {
            return 'Point [' + this.x + ', ' + this.y + ']';
        }
    }
}

function createLine(firstPoint, secondPoint) {
    return {
        x1: firstPoint.x,
        y1: firstPoint.y,
        x2: secondPoint.x,
        y2: secondPoint.y,
        toString: function () {
            return 'Line (' + firstPoint.toString() + ', ' + secondPoint.toString() + ')';
        },
        length: function () {
            return getDistance(firstPoint, secondPoint);
        }
    }
}

function getDistance(firstPoint, secondPoint) {
    var deltaX = firstPoint.x - secondPoint.x;
    var deltaY = firstPoint.y - secondPoint.y;
    var length = Math.sqrt(deltaX * deltaX + deltaY * deltaY);
    return length;
}

function checkIfIsTriangle(pointA, pointB, pointC) {
    var lengthAB = getDistance(pointA, pointB);
    var lengthBC = getDistance(pointB, pointC);
    var lengthCA = getDistance(pointC, pointA);

    isTriangle = true;
    if (lengthAB >= (lengthBC+lengthCA)) {
        isTriangle = false;
    }

    if (lengthBC >= (lengthAB + lengthCA)) {
        isTriangle = false;
    }

    if (lengthCA >= (lengthBC + lengthAB)) {
        isTriangle = false;
    }

    return isTriangle;
}
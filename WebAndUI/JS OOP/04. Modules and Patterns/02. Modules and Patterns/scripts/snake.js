/// <reference path="_reference.js" />

var snakes = (function () {
    var snakeelementSize = 10;

    var directions = [
        { dx: 0, dy: -1, }, //0 - up
        { dx: +1, dy: 0, }, //1 - right
        { dx: 0, dy: +1, }, //2 - down
        { dx: -1, dy: 0, }, //3 - left
    ];

    function GameObject(x, y, size) {
        this.x = x;
        this.y = y;
        this.size = size;
    }

    GameObject.prototype = {
        getPosition: function () {
            return {
                x: this.x,
                y: this.y,
            };
        },
        getSize: function () {
            return {
                size: this.size,
            }
        },
        setSize: function (newSize) {
            this.size = newSize;
        }
    };

    function SnakeElement(x, y, size) {
        GameObject.call(this, x, y, size);

    }
    SnakeElement.prototype = new GameObject();
    SnakeElement.prototype.constructor = SnakeElement;
    SnakeElement.prototype.changePosition = function (x, y) {
        this.x = x;
        this.y = y;
    }

    function HeadSnakeElement(x, y, size) {
        SnakeElement.call(this, x, y, size);
    }
    HeadSnakeElement.prototype = new SnakeElement();
    HeadSnakeElement.prototype.constructor = HeadSnakeElement;

    function Snake(x, y, size) {
        var element = null,
            elementX,
            elementY;
        this.elements = [];
        this.direction = 2;
        for (var i = 0; i < size; i++) {
            elementX = x - i * snakeelementSize;
            elementY = y;
            element = new SnakeElement(elementX, elementY, snakeelementSize);
            this.elements.push(element);
        }
    }
    Snake.prototype = new GameObject();
    Snake.prototype.constructor = Snake;

    Snake.prototype.head = function () {
        return this.elements[0];
    };

    Snake.prototype.move = function () {
        var x,
            y,
            dx,
            dy,
            size;

        for (var i = this.elements.length - 1; i >= 1; i--) {
            var position = this.elements[i - 1].getPosition();
            this.elements[i].changePosition(position.x, position.y);
        }

        var head = this.head();
        var dx = directions[this.direction].dx;
        var dy = directions[this.direction].dy;
        var headPosition = head.getPosition();
        var newHeadPosition = {
            x: headPosition.x + head.size * dx,
            y: headPosition.y + head.size * dy,
        };
        head.changePosition(newHeadPosition.x, newHeadPosition.y);
    };

    Snake.prototype.changeDirection = function (newDirection) {
        if (newDirection >= 0 && newDirection < directions.length && (this.direction + newDirection) % 2) {
            this.direction = newDirection;
        }
    };

    Snake.prototype.getPosition = function () {
        return this.head().getPosition();
    }

    Snake.prototype.changePosition = function (x, y) {
        this.head().changePosition(x, y);
    }

    Snake.prototype.setSize = function (newSize) {
        this.size = newSize;
    }

    Snake.prototype.getSize = function () {
        return this.size;
    }

    function Wall(x, y, size) {
        GameObject.call(this, x, y, size);

    }
    Wall.prototype = new GameObject();
    Wall.prototype.constructor = Wall;

    function Food(x, y, size) {
        GameObject.call(this, x, y, size);

    }
    Food.prototype = new GameObject();
    Food.prototype.constructor = Food;


    return {
        get: function (x, y, size) {
            return new Snake(x, y, size);
        },
        getFood: function (x, y, size) {
            return new Food(x, y, size);
        },
        getWall: function (x, y, size) {
            return new Wall(x, y, size);
        },
        SnakeType: Snake,
        SnakeElementType: SnakeElement,
        FoodType: Food,
        WallType: Wall,
    };
})();
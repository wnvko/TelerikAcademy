/// <reference path="_reference.js" />
var games = (function () {
    function Game(renderer) {
        this.renderer = renderer;
        this.snake = snakes.get(250, 250, 10);
        this.food = snakes.getFood(100, 100, 10);
        this.bindKeyEvents();
        this.state = 'stoped';
    }

    function animationFrame() {
        var snakePosition = theGame.snake.getPosition(),
            foodPosition = theGame.food.getPosition(),
            toChangePosition = false,
            newX = snakePosition.x,
            newY = snakePosition.y,
            elementSize = theGame.snake.elements[0].size,
            snakeSize = 10,
            newFoodX,
            newFoodY;

        if (snakePosition.x === foodPosition.x && snakePosition.y === foodPosition.y) {
            var newElement = theGame.snake.elements[theGame.snake.elements.length - 1];
            theGame.snake.elements.push(newElement);
            isFoodEaten = true;
        }

        if (snakePosition.x <= dimensions.minWidth) {
            theGame.state = 'over';
        }

        if (dimensions.maxWidth < snakePosition.x + elementSize) {
            theGame.state = 'over';
        }

        if (snakePosition.y <= dimensions.minHeight) {
            theGame.state = 'over';
        }

        if (dimensions.maxHeight < snakePosition.y + elementSize) {
            theGame.state = 'over';
        }

        if (toChangePosition) {
            theGame.snake.changePosition(newX, newY);
        }

        if (theGame.state === 'over') {
            alert('Game Over');
        }

        if (isFoodEaten) {
            newFoodX = getRandomPosition(dimensions.maxWidth, elementSize),
            newFoodY = getRandomPosition(dimensions.maxHeight, elementSize);
            theGame.food = snakes.getFood(newFoodX, newFoodY, elementSize);
            console.log(theGame);
            isFoodEaten = false;
        }

        theGame.renderer.clear();
        theGame.snake.move();
        theGame.renderer.draw(theGame.snake);
        theGame.renderer.draw(theGame.food);

        if (theGame.state === 'running') {
            setTimeout(function () {
                requestAnimationFrame(animationFrame);
            }, 100);
        }
    }

    function getRandomPosition(size, step) {
        var numberOfPositions = size / step;
        randomPosition = (Math.random() * numberOfPositions | 0) * step;
        return randomPosition;
    }

    var dimensions,
        isFoodEaten = false;

    Game.prototype = {
        start: function () {
            theGame = this;
            requestAnimationFrame(animationFrame);
            dimensions = this.renderer.getDimensions();
            this.state = 'running';
        },
        stop: function () {
            theGame.state = 'stoped';
        },
        bindKeyEvents: function () {
            var myGame = this;
            document.body.addEventListener('keydown', function (ev) {
                var keyCode = ev.keyCode;

                //left
                if (keyCode === 37) {
                    myGame.snake.changeDirection(3);
                }

                //up
                if (keyCode === 38) {
                    myGame.snake.changeDirection(0);
                }

                //right
                if (keyCode === 39) {
                    myGame.snake.changeDirection(1);
                }

                //down
                if (keyCode === 40) {
                    myGame.snake.changeDirection(2);
                }
            });
        },
        getState: function () {
            return this.state;
        },
    }

    return {
        get: function (renderer) {
            return new Game(renderer)
        }
    };

}());
/// <reference path="require.js" />
/// <reference path="jquery-2.1.1.min.js" />
'use strict';
define([], function () {
    var RandomNumber = (function () {
        function RandomNumber() {
            this.number = [];
            this.numbers = [];
        }

        RandomNumber.prototype.get = function () {
            var numberDigitsCount = 4,
                i;

            this.numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

            for (i = 0; i < numberDigitsCount; i++) {
                if (i === 0) {
                    this.number[i] = getRandomNumberFromNumbers(1, 9, this.numbers);
                }
                else {
                    this.number[i] = getRandomNumberFromNumbers(0, this.numbers.length, this.numbers);
                }
            }

            return this.number;
        };

        function getRandomNumberFromNumbers(min, max, numbers) {
            var randomNumber,
                result;

            randomNumber = (Math.random() * max + min) | 0;
            result = numbers[randomNumber];
            numbers.splice(randomNumber, 1);

            return result;
        };

        return RandomNumber;
    }());

    return RandomNumber;
});
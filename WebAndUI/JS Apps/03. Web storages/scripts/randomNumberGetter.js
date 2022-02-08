/// <reference path="require.js" />
/// <reference path="jquery-2.1.1.min.js" />
'use strict';
define([], function () {
    var RandomNumber = (function () {
        function RandomNumber() {
            this.number = [];
        }

        RandomNumber.prototype.get = function () {
            var numberDigitsCount = 4,
                i;

            for (i = 0; i < numberDigitsCount; i++) {
                this.number[i] = (Math.random() * 9 + 1) | 0;

                if (i === 0 && this.number[i] === 0) {
                    this.number[i]++;
                }
            }

            return this.number;
        };

        return RandomNumber;
    }());

    return RandomNumber;
});
/// <reference path="require.js" />
/// <reference path="jquery-2.1.1.min.js" />
'use strict';
define([], function () {
    var FindNumber = (function () {
        function FindNumber(numberToGuess) {
            this.numberToGuess = numberToGuess;
            this.rams;
            this.sheep;
        }

        var userGuesses = 0,
                userGuessesText,
                rams = 0,
                sheep = 0,
                ramPicSrc = '/pics/ram.png',
                sheepSrc = '/pics/sheep.png',
                errorPicSrc = '/pics/error.png';

        FindNumber.prototype.go = function () {
            var $userInputHtml = $('.user-number>input');
            var $buttonGetUserInput = $('.getUserInput').first();
            var $userGuesses = $('.userTrys').first();

            var userInput = parseInput($userInputHtml);

            userGuessesText = $userGuesses.text();
            userGuesses = userGuessesText.indexOf(':') + 1;
            userGuesses = parseInt(userGuessesText.substring(userGuesses));
            userGuesses++;
            $userGuesses.text('Guesses: ' + userGuesses);

            sheepAndRamCounter(userInput, this.numberToGuess);
            setPictures();

            return this.sheepAndRams = {
                sheep: sheep,
                rams: rams
            };
        }

        function sheepAndRamCounter(input, numberToGuess) {
            rams = 0;
            for (var i = 0; i < 4; i++) {
                if (input[i] === numberToGuess[i]) {
                    rams++;
                    input[i] = -1;
                }
            }

            sheep = 0
            for (var i = 0; i < 4; i++) {
                for (var j = 0; j < 4; j++) {
                    if (input[i] === numberToGuess[j]) {
                        sheep++;
                        input[i] = -1;
                    };
                };
            };
        };

        function parseInput($input) {
            var inputAsArray = [];

            for (var i = 0; i < 4; i++) {
                inputAsArray[i] = parseInt($input[i].value);
            }

            return inputAsArray;
        }

        function setPictures() {
            var currentPossition = 0,
                i,
                $result = $('.result>img');

            for (i = 0; i < rams; i++) {
                $($result[currentPossition]).attr('src', ramPicSrc);
                currentPossition++;
            }

            for (i = currentPossition; i < sheep + rams; i++) {
                $($result[currentPossition]).attr('src', sheepSrc);
                currentPossition++;
            }

            for (i = sheep + rams; i < 4; i++) {
                $($result[currentPossition]).attr('src', errorPicSrc);
                currentPossition++;
            }
        }

        return FindNumber;
    }());

    return FindNumber;
});
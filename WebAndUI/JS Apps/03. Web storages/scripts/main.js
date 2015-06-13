/// <reference path="randomNumberGetter.js" />
/// <reference path="lib/jquery-2.1.1.js" />
/// <reference path="findNumber.js" />

define(['jQuery', 'Random', 'FindNumber', 'NameChecker', 'Cookies', 'GetHighScores'],
    function ($, random, findNumber, nameChecker, cookies, getHighScores) {
        'use strict';
        var Main = function () {
            var randomGetter = new random(),
                numberToGuess = randomGetter.get(),
                sheepAndRams,
                playerName,
                bestScores,
                addNameAndScore,
                $buttonGetUserInput,
                oldScore,
                myCookies;

            myCookies = new cookies();
            $buttonGetUserInput = $('.getUserInput').first();
            $buttonGetUserInput.click(function () {
                var finder = new findNumber(numberToGuess);
                sheepAndRams = finder.go();

                if (sheepAndRams.rams === 4) {
                    playerName = prompt('You did it. Please enter your name!');
                    if (myCookies.readCookies('SandR:' + playerName)) {
                        oldScore = myCookies.readCookies('SandR:' + playerName).split('=')[1];
                        if (oldScore > sheepAndRams.tries) {
                            addNameAndScore = new nameChecker(playerName, sheepAndRams.tries);
                        }
                    }
                    else {
                        addNameAndScore = new nameChecker(playerName, sheepAndRams.tries);
                    }

                    finder.numberToGuess = randomGetter.get();
                    $('.userTries').first().text('Guesses: 0');
                    bestScores.displayScores();
                    console.log(numberToGuess);
                };
            });

            console.log(numberToGuess);

            bestScores = new getHighScores();
            bestScores.displayScores();
        };

        return Main
    });
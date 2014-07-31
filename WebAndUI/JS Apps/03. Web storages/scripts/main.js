/// <reference path="randomNumberGetter.js" />
/// <reference path="lib/jquery-2.1.1.js" />
define(['jQuery', 'Random', 'FindNumber', 'NameChecker', 'Cookies'],
    function ($, random, findNumber, nameChecker) {
        'use strict';
        var Main = function () {
            var randomGetter = new random(),
                numberToGuess = randomGetter.get(),
                sheepAndRams,
                playerName;

            console.log(numberToGuess);

            playerName = new nameChecker('wnvko');

            var $buttonGetUserInput = $('.getUserInput').first();
            $buttonGetUserInput.click(function () {
                var finder = new findNumber(numberToGuess);
                console.log(finder);
                sheepAndRams = finder.go();

                if (sheepAndRams.rams === 4) {
                    var playerName = prompt('You did it. Please enter your name!');
                    console.log(playerName);
                };
            });
        };

        return Main
    });
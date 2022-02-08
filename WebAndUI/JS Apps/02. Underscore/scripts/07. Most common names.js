/// <reference path="underscore.js" />
(function () {
    var Human = Object.create({
        init: function (firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
            return this;
        },
        toString: function () {
            return this.firstName + ' ' + this.lastName;
        }
    });

    var Humans = [
        Object.create(Human).init('Alexander', 'Petkov'),
        Object.create(Human).init('Tina', 'Palanska'),
        Object.create(Human).init('Gergana', 'Ilieva'),
        Object.create(Human).init('Tina', 'Nenova'),
        Object.create(Human).init('Sofia', 'Mitzova'),
        Object.create(Human).init('Stanislav', 'Grozdanov'),
        Object.create(Human).init('Pavlina', 'Sheytanska'),
        Object.create(Human).init('Tina', 'Satieva'),
        Object.create(Human).init('Yordan', 'Petkov'),
        Object.create(Human).init('Hristo', 'Andonov'),
        Object.create(Human).init('Biliana', 'Todorova'),
        Object.create(Human).init('Doncho', 'Petkov'),
    ];

    var mostCommonFirstName = _.chain(Humans)
                               .countBy(function (human) {
                                   return human.firstName;
                               })
                               .pairs()
                               .max(function (name) {
                                   return name[1];
                               })
                               .value();
    console.log('Most common first name:');
    console.log(mostCommonFirstName[0] + ' ' + mostCommonFirstName[1] + ' times');

    var mostCommonLastName = _.chain(Humans)
                               .countBy(function (human) {
                                   return human.lastName;
                               })
                               .pairs()
                               .max(function (name) {
                                   return name[1];
                               })
                               .value();
    console.log('Most common last name:');
    console.log(mostCommonLastName[0] + ' ' + mostCommonLastName[1] + ' times');
}());
/// <reference path="underscore.js" />
(function () {
    var Student = Object.create({
        init: function (firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
            return this;
        },
        toString: function () {
            return this.firstName + ' ' + this.lastName;
        }
    });

    var students = [
        Object.create(Student).init('Alexander', 'Petkov'),
        Object.create(Student).init('Miglena', 'Palanska'),
        Object.create(Student).init('Gergana', 'Ilieva'),
        Object.create(Student).init('Lyubka', 'Nenova'),
        Object.create(Student).init('Sofia', 'Mitzova'),
        Object.create(Student).init('Stanislav', 'Grozdanov'),
        Object.create(Student).init('Pavlina', 'Sheytanska'),
        Object.create(Student).init('Tina', 'Satieva'),
        Object.create(Student).init('Yordan', 'Markov'),
        Object.create(Student).init('Hristo', 'Andonov'),
        Object.create(Student).init('Biliana', 'Todorova'),
        Object.create(Student).init('Doncho', 'Georgiev'),
    ];

    var fnameBeforeLname = _.filter(students, function (student) {
        return student.firstName.localeCompare(student.lastName) < 0;
    })

    _.forEach(_.sortBy(fnameBeforeLname, function (student) {
        return student.toString();
    }), function (student) {
        console.log(student.toString());
    });
}());
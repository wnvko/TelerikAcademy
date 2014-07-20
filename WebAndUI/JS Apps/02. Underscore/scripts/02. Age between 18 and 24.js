/// <reference path="underscore.js" />
(function () {
    var Student = Object.create({
        init: function (firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            return this;
        },
        toString: function () {
            return this.firstName + ' ' + this.lastName + ' ' + this.age + ' years old.';
        }
    });

    var students = [
        Object.create(Student).init('Alexander', 'Petkov', 20),
        Object.create(Student).init('Miglena', 'Palanska', 17),
        Object.create(Student).init('Gergana', 'Ilieva', 26),
        Object.create(Student).init('Lyubka', 'Nenova', 22),
        Object.create(Student).init('Sofia', 'Mitzova', 18),
        Object.create(Student).init('Stanislav', 'Grozdanov', 28),
        Object.create(Student).init('Pavlina', 'Sheytanska', 38),
        Object.create(Student).init('Tina', 'Satieva', 22),
        Object.create(Student).init('Yordan', 'Markov', 26),
        Object.create(Student).init('Hristo', 'Andonov', 19),
        Object.create(Student).init('Biliana', 'Todorova', 21),
        Object.create(Student).init('Doncho', 'Georgiev', 18),
    ];

    var between18and24 = _.map(_.filter(students, function (student) {
        return (student.age > 18 && student.age < 24);
    }), function (student) {
        return student.firstName + ' ' + student.lastName;
    });

    _.forEach(between18and24, function (student) {
        console.log(student);
    });
}());
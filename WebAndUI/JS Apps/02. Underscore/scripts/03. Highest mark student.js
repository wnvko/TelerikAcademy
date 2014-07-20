/// <reference path="underscore.js" />
(function () {
    var Student = Object.create({
        init: function (firstName, lastName, mark) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.mark = mark;
            return this;
        },
        toString: function () {
            return this.firstName + ' ' + this.lastName + ' mark: ' + this.mark;
        }
    });

    var students = [
        Object.create(Student).init('Alexander', 'Petkov', (Math.random() * 10 + 1).toFixed(2)),
        Object.create(Student).init('Miglena', 'Palanska', (Math.random() * 10 + 1).toFixed(2)),
        Object.create(Student).init('Gergana', 'Ilieva', (Math.random() * 10 + 1).toFixed(2)),
        Object.create(Student).init('Lyubka', 'Nenova', (Math.random() * 10 + 1).toFixed(2)),
        Object.create(Student).init('Sofia', 'Mitzova', (Math.random() * 10 + 1).toFixed(2)),
        Object.create(Student).init('Stanislav', 'Grozdanov', (Math.random() * 10 + 1).toFixed(2)),
        Object.create(Student).init('Pavlina', 'Sheytanska', (Math.random() * 10 + 1).toFixed(2)),
        Object.create(Student).init('Tina', 'Satieva', (Math.random() * 10 + 1).toFixed(2)),
        Object.create(Student).init('Yordan', 'Markov', (Math.random() * 10 + 1).toFixed(2)),
        Object.create(Student).init('Hristo', 'Andonov', (Math.random() * 10 + 1).toFixed(2)),
        Object.create(Student).init('Biliana', 'Todorova', (Math.random() * 10 + 1).toFixed(2)),
        Object.create(Student).init('Doncho', 'Georgiev', (Math.random() * 10 + 1).toFixed(2)),
    ];

    console.log('All students with random marks');
    _.forEach(students, function (student) {
        console.log(student.toString());
    })

    console.log('The most clever one:');
    var theMostCleverOne = _.max(students, function (student) { return parseFloat(student.mark); });
    console.log(theMostCleverOne.toString());

}());
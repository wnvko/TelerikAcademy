/// <reference path="../libs/requirejs/require.js" />
define([], function () {
    var Course;
    Course = (function () {
        function Course(title, scoreFormula) {
            this.title = title;
            this.scoreFormula = scoreFormula;
            this.students = [];
        }

        Course.prototype.addStudent = function (student) {
            this.students.push(student);
        };

        Course.prototype.calculateResults = function () {
            var theCourse = this;
            this.students.forEach(function (student) {
                student.totalResult = theCourse.scoreFormula(student);
            });
        };

        Course.prototype.getTopStudentsByExam = function (count) {
            return sortStudents(this.students, count, 'exam');
        };

        Course.prototype.getTopStudentsByTotalScore = function (count) {
            this.calculateResults();
            return sortStudents(this.students, count, 'totalResult');
        };

        function sortStudents(students, count, sortBy) {
            students.sort(function (first, second) {
                return second[sortBy] - first[sortBy];
            })

            return students.slice(0, count);
        }

        return Course;
    }());

    return Course;
});
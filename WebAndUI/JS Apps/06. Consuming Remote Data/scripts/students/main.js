/// <reference path='../libs/require.js' />
/// <reference path='studentsAPI.js' />
/// <reference path='../jquery-2.1.4.js' />
define(['jquery', 'q', 'api'], function ($, q, studentsAPI) {
    'use strict';
    var main = (function () {
        function main() {
            this.api = new studentsAPI();
        };

        function postSuccess(data) {
            $('.added')
                .html(data.name + ' added')
                .show()
                .fadeOut(3000);
        };

        function postError(err) {
            var error = err.statusText || "ERROR";
            if (error === 'error') {
                error = error.toUpperCase();
            }

            $('.added')
                .html(error)
                .show()
                .fadeOut(3000);
        };

        function deleteSuccess(data) {
            $('.deleted')
                .html('Successfully deleted')
                .show()
                .fadeOut(3000);
        };

        function deleteError(err) {
            var error = err.statusText || "ERROR";
            if (error === 'error') {
                error = error.toUpperCase();
            }

            $('.deleted')
                .html(error)
                .show()
                .fadeOut(3000);
        };

        function getSuccess(data) {
            var student,
                name,
                grade,
                id,
                i,
                len,
                innerText;

            var $data = $('<ul>'),
                $contener = $('#load-student .students');

            for (i = 0, len = data.count; i < len; i += 1) {
                student = data.students[i];
                name = student.name;
                grade = student.grade;
                id = student.id;
                innerText = 'Name: ' + name + ', grade: ' + grade + ' and ID: ' + id;

                $data.append($('<li>').html(innerText));
            }

            $contener.html($data);
        }

        function getError() {
            var $contener = $('#load-student .students');
            $contener.html($('<strong>').html('No connection to the server!'))
        }

        function addStudent() {
            var studentName = $('#student-name').val(),
                studentGrade = $('#student-grade').val(),
                api = new studentsAPI();

            if (!studentName) {
                var emptyName = {
                    statusText: 'ERROR: Enter Name'
                };

                postError(emptyName);
                return;
            };

            if (!studentGrade) {
                var emptyGrade = {
                    statusText: 'ERROR: Enter Grade'
                };

                postError(emptyGrade);
                return;
            };

            if (isNaN(studentGrade)) {
                var notNumberGrade = {
                    statusText: 'ERROR: Enter Number'
                };

                postError(notNumberGrade);
                return;
            }


            $('#student-name').val(''),
            $('#student-grade').val('');

            var student = {
                name: studentName,
                grade: studentGrade
            };

            api.POST(student)
            .then(postSuccess, postError);
        };

        function deleteStudent() {
            var id = $('#student-id').val(),
                api = new studentsAPI();

            if (!id) {
                var emptyId = {
                    statusText: 'ERROR: Enter Id'
                };

                deleteError(emptyId);
                return;
            };

            if (isNaN(id)) {
                var notNumberId = {
                    statusText: 'ERROR: Enter Number'
                };

                deleteError(notNumberId);
                return;
            }

            if (!isExistingId(id)) {
                var notExistingId = {
                    statusText: 'ERROR: No Such Id'
                };

                deleteError(notExistingId);
                return;
            }

            $('#student-id').val('');
            api.DELETE(id)
            .then(deleteSuccess, deleteError);
        };

        function getData() {
            var api = new studentsAPI();
            api.GET()
            .then(getSuccess, getError);
        };

        function isExistingId(id) {
            var $allStidentsLiElement = $('.students li'),
                isExist = false;

            $allStidentsLiElement.each(function (index) {
                var studentInfo = $(this).text();
                if (studentInfo.indexOf('ID: ' + id) > -1) {
                    isExist = true;
                }
            });

            return isExist;
        };

        $('#load-student .button').click(function () {
            getData();
        });
        $('#add-student .button').click(function () {
            addStudent();
            getData();
        });
        $('#delete-student .button').click(function () {
            deleteStudent(),
            getData();
        });

        return main;
    }());

    return main;
});
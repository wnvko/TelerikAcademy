/// <reference path="studentsAPI.js" />
/// <reference path="jquery-2.1.1.js" />
(function () {
    var api = new studentsApi();
    var $deleted = $('.deleted').hide();
    var $added = $('.added').hide();

    $('#load-student .button').click(getData);
    $('#add-student .button').click(addStudent);
    $('#delete-student .button').click(deleteStudent);

    function addStudent() {
        var studentName = $('#student-name').val(),
            studentGrade = $('#student-grade').val();

        $('#student-name').val(''),
        $('#student-grade').val('');

        var student = {
            name: studentName,
            grade: studentGrade
        };

        api.POST(student, postSucces, postError);
    };

    function postSucces(data) {
        $added
            .html(data.name + ' added')
            .show()
            .fadeOut(3000);
    };

    function postError(error) {
        $added
            .html('ERROR!')
            .show()
            .fadeOut(3000);
    };

    function deleteStudent() {
        var id = $('#student-id').val();
        $('#student-id').val('');
        api.DELETE(id, deleteSucces, deleteError);
    };

    function deleteSucces(data) {
        $deleted
            .html(data.name + 'successfully deleted')
            .show()
            .fadeOut(3000);
    };

    function deleteError() {
        $deleted
            .html('ERROR!')
            .show()
            .fadeOut(3000);
    };

    function getData() {
        api.GET(getSuccess, getError);
    };

    function getSuccess(data) {
        var student,
            name,
            grade,
            id,
            i,
            innerText;

        console.log(data.students[0]);

        var $data = $('<ul>'),
            $contener = $('#load-student .students');

        for (i = 0; i < data.count; i++) {
            student = data.students[i];
            name = student.name;
            grade = student.grade;
            id = student.id;
            innerText = 'Name: ' + name + ', grade: ' + grade + ' and ID: ' + id;

            console.log(name + ' ' + grade + ' ' + id);
            $data.append($('<li>').html(innerText));
        }

        $contener.html($data);
    }

    function getError() {
        var $contener = $('#load-student .students');
        $contener.html($('<strong>').html('No connection to the server!'))
    }
}());
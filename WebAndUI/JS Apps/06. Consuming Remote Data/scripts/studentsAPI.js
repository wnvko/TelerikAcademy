/// <reference path="jquery-2.1.1.js" />
var studentsApi = (function () {
    function studentsApi() {
        this.endpointURL = 'http://localhost:3000/students'
    };

    studentsApi.prototype.GET = function (success, error) {
        $.ajax({
            url: this.endpointURL,
        })
        .done(success)
        .fail(error);
    };

    studentsApi.prototype.POST = function (student, succes, error) {
        $.ajax({
            url: this.endpointURL,
            type: 'POST',
            timeout: 5000,
            data: student,
        })
        .done(succes)
        .fail(error);
    };

    studentsApi.prototype.DELETE = function (id, succes, error) {
        $.ajax({
            url: this.endpointURL + '/' + id,
            type: 'POST',
            timeout: 5000,
            data: { _method: 'delete' }
        })
        .done(succes)
        .fail(error);

        console.log(succes);
    };

    return studentsApi;
}());
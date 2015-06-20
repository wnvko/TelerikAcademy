/// <reference path="../libs/require.js" />
/// <reference path="jquery-2.1.4.js" />
/// <reference path="../libs/q.js" />

define(['jquery', 'q'], function ($, q) {
    var studentsApi = (function () {
        function studentsApi() {
            this.endpointURL = 'http://localhost:3000/students';
        };

        studentsApi.prototype.GET = function () {
            var defered = q.defer();

            $.ajax({
                url: this.endpointURL,
                success: function (success) {
                    defered.resolve(success);
                },
                error: function (error) {
                    defered.reject(error);
                },
            });

            return defered.promise;
        };

        studentsApi.prototype.POST = function (student) {
            var defered = q.defer();

            $.ajax({
                url: this.endpointURL,
                type: 'POST',
                timeout: 5000,
                data: student,
                success: function (success) {
                    defered.resolve(success);
                },
                error: function (error) {
                    defered.reject(error);
                },
            });

            return defered.promise;
        };

        studentsApi.prototype.DELETE = function (id) {
            var defered = q.defer();

            $.ajax({
                url: this.endpointURL + '/' + id,
                type: 'POST',
                timeout: 5000,
                data: { _method: 'delete' },
                success: function (success) {
                    defered.resolve(success);
                },
                error: function (error) {
                    defered.reject(error);
                },
            });

            return defered.promise;
        };

        return studentsApi;
    }());

    return studentsApi;
});

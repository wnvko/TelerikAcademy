(function () {
    'use strict';

    function data($http, $q, baseUrl) {

        function get(url, params) {
            var defer = $q.defer();

            $http.get(baseUrl + url, {
                params: params
            }).then(function (response) {
                defer.resolve(response.data);
            }, function (err) {
                defer.reject(err);
            });

            return defer.promise;
        }

        function post(url, postData) {
            var defer = $q.defer;

            $http.post(baseUrl + url, postData)
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (err) {
                    defer.reject(err);
                });

            return defer.promise;
        }

        return {
            get: get,
            post: post,
        }
    };

    angular.module('catApp.services')
        .factory('data', ['$http', '$q', 'baseUrl', data]);
}());
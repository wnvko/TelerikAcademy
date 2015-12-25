(function () {
    'use strict';

    function LoginController($location, auth) {
        var vm = this;

        vm.login = function (user, loginForm) {
            if (loginForm.$valid) {
                console.log('... logging user...');
                auth.login(user)
                    .then(function () {
                        console.log('... user is logged ...');
                        $location.path('/');
                    });
            }
        }
    };

    angular.module('catApp.controllers')
        .controller('LoginController', ['$location', 'auth', LoginController]);
}());
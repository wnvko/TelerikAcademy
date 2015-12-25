(function () {
    'use strict';

    function RegisterController($location, auth) {
        var vm = this;

        console.log(auth);

        vm.register = function (user, registerForm) {
            if (registerForm.$valid) {
                console.log('... registering user...');
                auth.register(user)
                    .then(function () {
                        console.log('...use is registered...');
                        $location.path('/identity/login');
                    });
            }
        };
    };

    angular.module('catApp.controllers')
        .controller('RegisterController', ['$location', 'auth', RegisterController]);
}());
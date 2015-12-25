(function () {
    'use strict';

    function MainController($location, auth, identity) {
        var vm = this;

        waitForLogin();

        vm.logout = function () {
            vm.globallySetCurrentUser = undefined;
            auth.logout();
            waitForLogin();
            $location.path('/');
        };

        function waitForLogin() {
            identity.getUser()
                .then(function (user) {
                    vm.globallySetCurrentUser = user;
                });
        }
    }

    angular.module('catApp')
        .controller('MainController', ['$location', 'auth', 'identity', MainController]);
}());
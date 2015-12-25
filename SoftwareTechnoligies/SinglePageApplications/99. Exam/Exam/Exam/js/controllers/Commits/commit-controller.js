(function () {
    'use strict';

    function CommitsController($routeParams, $location, commits, identity) {
        var vm = this;

        vm.identity = identity;

        if (!identity.isAuthenticated()) {
            $location.path('/unauthorized');
        }

        var id = $routeParams.Id;

        commits.getPublicCommits(id)
            .then(function (publicCommits) {
                vm.commits = publicCommits;
            });
    }

    angular
        .module('myApp.controllers')
        .controller('CommitsController', ['$routeParams', '$location', 'commits', 'identity', CommitsController])
}());
(function () {
    'use strict';

    function ProjectsDetailsController($routeParams, $location, projects, identity) {
        var vm = this;
        vm.identity = identity;

        if (!identity.isAuthenticated()) {
            $location.path('/unauthorized');
        }

        var id = $routeParams.Id;
        projects.getPublicProjects(id)
            .then(function (publicProject) {
                vm.project = publicProject;
            });

    }

    angular.module('myApp.controllers')
        .controller('ProjectsDetailsController', ['$routeParams', '$location', 'projects', 'identity', ProjectsDetailsController]);
}());
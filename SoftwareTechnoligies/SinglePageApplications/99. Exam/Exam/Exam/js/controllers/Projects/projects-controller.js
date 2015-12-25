(function () {
    'use strict';

    function ProjectsController(projects, identity) {
        var vm = this;
        vm.identity = identity;

        vm.request = {
            Page: 1,
            PageSize: 10
        };

        projects.getPublicProjects()
            .then(function (publicProjects) {
                vm.projects = publicProjects;
            });

        vm.filterProjects = function () {
            projects.filterProjects(vm.request)
                .then(function (filteredProjects) {
                    vm.projects = filteredProjects
                });
        }

        vm.prevPage = function () {
            if (vm.request.Page == 1) {
                return;
            }

            vm.request.Page--;

            vm.filterProjects();
        }

        vm.nextPage = function () {
            if (!vm.projects || vm.projects.length == 0) {
                return;
            }

            vm.request.Page++;
            vm.filterProjects();
        }
    }

    angular
        .module('myApp.controllers')
        .controller('ProjectsController', ['projects', 'identity', ProjectsController])
}());
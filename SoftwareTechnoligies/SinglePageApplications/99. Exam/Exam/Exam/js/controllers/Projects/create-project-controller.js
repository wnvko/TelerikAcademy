(function () {
    'use strict';

    function CreateProjectController($location, projects) {
        var vm = this;

        vm.createProject = function (newProject) {
            projects.createProject(newProject)
                .then(function (createdProject) {
                    $location.path('/Projects/' + createdProject.id);
                });
        }
    }

    angular.module('myApp.controllers')
        .controller('CreateProjectController', ['$location','projects', CreateProjectController]);
}());
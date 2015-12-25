(function () {
    'use strict';

    function HomeController(statistics, projects, commits) {
        var vm = this;

        statistics.getStats()
            .then(function (stats) {
                vm.stats = stats;
            });

        projects.getPublicProjects()
            .then(function (publicprojects) {
                vm.projects = publicprojects;
            });

        commits.getPublicCommits()
            .then(function (publicCommits) {
                vm.commits = publicCommits;
            });
    }

    angular.module('myApp.controllers')
        .controller('HomeController', ['statistics', 'projects','commits', HomeController])
}());
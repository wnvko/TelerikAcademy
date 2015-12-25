(function () {
    'use strict';

    function projects(data) {
        var PROJECTS_URL = 'api/projects';

        function getPublicProjects(id) {
            PROJECTS_URL = 'api/projects';

            if (id) {
                PROJECTS_URL = PROJECTS_URL + '/' + id;
            }

            return data.get(PROJECTS_URL);
        }

        function filterProjects(filters) {
            return data.get(PROJECTS_URL, filters);
        }

        function createProject(project) {
            console.log(project);
            return data.post(PROJECTS_URL, project);
        }

        return {
            getPublicProjects: getPublicProjects,
            createProject: createProject,
            filterProjects: filterProjects
        }
    }

    angular.module('myApp.services')
        .factory('projects', ['data', projects])
}());
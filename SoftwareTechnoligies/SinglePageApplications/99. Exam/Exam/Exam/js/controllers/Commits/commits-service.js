(function(){
    'use strict';

    function commits(data) {
        var COMMITS_URL = 'api/commits';

        function getPublicCommits(id) {
            COMMITS_URL = 'api/commits';

            if (id) {
                COMMITS_URL = COMMITS_URL + '/' + id;
            }

            console.log("CommitsController.Get: " + COMMITS_URL);

            return data.get(COMMITS_URL);
        }

        function filterCommits(filters) {
            return data.get(COMMITS_URL, filters);
        }

        function createCommit(commit) {
            return data.post(COMMITS_URL, commit);
        }

        return {
            getPublicCommits: getPublicCommits,
            createCommit: createCommit,
            filterCommits: filterCommits
        }
    }

    angular.module('myApp.services')
        .factory('commits', ['data', commits])
}());
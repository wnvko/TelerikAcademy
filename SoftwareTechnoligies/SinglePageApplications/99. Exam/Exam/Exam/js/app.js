(function () {
    'use strict';

    function config($routeProvider, $locationProvider) {

        var CONTROLER_VIEW_MODEL_NAME = 'vm';
        var PARTIALS_VIEWS_MAIN_ROUTE = 'views/partials/'

        $routeProvider
            .when('/', {
                templateUrl: PARTIALS_VIEWS_MAIN_ROUTE + 'home/home.html',
                controller: 'HomeController',
                controllerAs: CONTROLER_VIEW_MODEL_NAME
            })
            .when('/unauthorized', {
                template: '<h1 class="text-center">YOU ARE NOT AUTHORIZED!</h1>'
            })
            .when('/register', {
                templateUrl: PARTIALS_VIEWS_MAIN_ROUTE + 'register.html',
                controller: 'SignUpController',
                controllerAs: CONTROLER_VIEW_MODEL_NAME
            })
           .when('/projects', {
               templateUrl: PARTIALS_VIEWS_MAIN_ROUTE + 'projects/all-projects.html',
               controller: 'ProjectsController',
               controllerAs: CONTROLER_VIEW_MODEL_NAME
           })
           .when('/projects/add', {
               templateUrl: PARTIALS_VIEWS_MAIN_ROUTE + 'projects/create-project.html',
               controller: 'CreateProjectController',
               controllerAs: CONTROLER_VIEW_MODEL_NAME
           })
           .when('/projects/:Id', {
               templateUrl: PARTIALS_VIEWS_MAIN_ROUTE + 'projects/project-details.html',
               controller: 'ProjectsDetailsController',
               controllerAs: CONTROLER_VIEW_MODEL_NAME
           })
           .when('/commits/:Id', {
               templateUrl: PARTIALS_VIEWS_MAIN_ROUTE + 'commits/commit-details.html',
               controller: 'CommitsController',
               controllerAs: CONTROLER_VIEW_MODEL_NAME
           })
          .otherwise({ redirectTo: '/' });
    }

    angular.module('myApp.directives', []);
    angular.module('myApp.services', []);
    angular.module('myApp.controllers', ['myApp.services']);

    angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies', 'myApp.controllers', 'myApp.services', 'myApp.directives'])
        .config(['$routeProvider', '$locationProvider', config])
        .value('toastr', toastr)
        //.constant('baseServiceUrl', 'http://spa.bgcoder.com');
        .constant('baseServiceUrl', 'localhost');
}());
define(['angular', 'sb-admin', pagejs],
function (angular) {
    'use strict';

    require(["css!../Content/Views/Shared/_Layout"]);
    require(['domReady!'], function (document) {
        angular.bootstrap(document, ['$safeprojectname$']);
    });
});
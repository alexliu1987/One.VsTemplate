var serviceUrl = 'http://192.168.2.105:8092/assets/';
requirejs.config({
    baseUrl: rootUrl + 'Scripts/',
    deps: ['Views/Shared/_Layout'],
    shim: {
        'angular': {
            exports: 'angular'
        },
        'angular-route': {
            deps: ['angular'],
            exports: 'angular-route'
        },
        'bootstrap': ['jquery'],
        'layer': {
            deps: ['jquery'],
            exports: 'layer'
        },
        'dev.servicebus': ['jquery', 'dev.config'],
        'dev.util': ['jquery', 'dev.config', 'dev.servicebus'],
        'dev.map': ['jquery', 'css!' + serviceUrl + 'dev/map/dev.map'],
        'metisMenu': ['jquery', 'css!' + serviceUrl + 'plugins/metisMenu/dist/metisMenu.min'],
        'sb-admin': ['jquery', 'bootstrap', 'metisMenu'],
        'datatables': ['jquery', 'css!' + serviceUrl + 'plugins/datatables/media/css/jquery.dataTables.min.css'],
        'angular-datatables': ['angular', 'datatables', 'css!' + serviceUrl + 'plugins/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.css'],
        'echarts': [serviceUrl + 'plugins/ECharts/build/dist/echarts-config.js']
    },
    paths: {
        'angular': serviceUrl + 'plugins/angular/angular.min',
        'angular-route': serviceUrl + 'plugins/angular/angular-route.min',
        'jquery': serviceUrl + 'plugins/jquery/jquery.min',
        'layer': serviceUrl + 'plugins/layer/layer.min',
        'respond': serviceUrl + 'plugins/respond',
        'html5shiv': serviceUrl + 'plugins/html5shiv',
        'placeholder-IE-fixes': serviceUrl + 'plugins/placeholder-IE-fixes',
        'jquery-migrate': serviceUrl + 'plugins/jquery/jquery-migrate.min',
        'bootstrap': serviceUrl + 'plugins/bootstrap/js/bootstrap.min',
        'datatables': serviceUrl + 'plugins/datatables/media/js/jquery.dataTables.min',
        'dev.config': serviceUrl + 'dev/dev.config',
        'dev.servicebus': serviceUrl + 'dev/dev.servicebus',
        'dev.util': serviceUrl + 'dev/dev.util',
        'dev.map': serviceUrl + 'dev/map/dev.map',
        'metisMenu': serviceUrl + 'plugins/metisMenu/dist/metisMenu.min',
        'sb-admin': serviceUrl + 'plugins/sb-admin/js/sb-admin-2',
        'angular-datatables': serviceUrl + 'plugins/angular-datatables/angular-datatables.min',
        'echarts': serviceUrl + 'plugins/ECharts/build/dist/echarts-all'
    },
    map: {
        '*': {
            'css': 'css.min'
        }
    },
    urlArgs: "v=0.1.0"
});
require(['jquery'], function ($) {
    // IE8 and below specific scripts
    if ($('html.lt-ie9').size()) {
        require(['respond', 'html5shiv', 'placeholder-IE-fixes'], function (ieScript) {
            // ... do stuff
        });
    }
});

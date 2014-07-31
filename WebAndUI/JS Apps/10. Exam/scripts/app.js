(function () {
    requirejs.config({
        paths: {
            jQuery: 'libs/jquery-2.1.1',
            Q: 'libs/q',
            Handlebars: 'libs/handlebars-v1.3.0',
            Underscore: 'libs/underscore',
            Main: 'main',
            rest: 'restOpearations',
            UI: 'UI',
        },
        shim: {
            'jQuery': {
                exports: '$'
            },
            'Q': {
                exports: 'q'
            },
            'Handlebars': {
                exports: 'handlebars'
            },
            'Underscore': {
                exports: '_'
            },
        }
    });

    require(['Main'], function (Main) {
        Main();
    });
}());
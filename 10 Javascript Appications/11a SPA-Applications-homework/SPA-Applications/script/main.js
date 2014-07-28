/// <reference path="libs/jquery-2.1.1.intellisense.js" />
/// <reference path="controller.js" />
(function () {
    'use strict';
    require.config({
        paths: {
            'jquery': '../libs/jquery-2.1.1.min',
            'Qlib': '../libs/q.min'
        }
    });

    require(['controller'], function (Controller) {
        var controller = new Controller('http://crowd-chat.herokuapp.com/posts', '#wrapper');
        controller.run();
    });
}());
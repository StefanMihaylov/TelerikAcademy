(function () {
    'use strict';
    require.config({
        paths: {
            'jquery': '../libs/jquery-2.0.2'
        }
    });

    require(['request'], function (request) {

        document.getElementById('add').addEventListener('click', function () {
            request.post();
        });

        document.getElementById('get').addEventListener('click', function () {
            request.get();
        });

        document.getElementById('delete').addEventListener('click', function () {
            request.del();
        });

    });
}());
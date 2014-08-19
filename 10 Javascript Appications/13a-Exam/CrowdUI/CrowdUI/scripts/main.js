/// <reference path="libs/jquery-2.1.1.intellisense.js" />
/// <reference path="ui.js" />
/// <reference path="controller.js" />

(function () {
    'use strict';
    require.config({
        paths: {
            'jquery': '../libs/jquery-2.1.1.min',
            'Qlib': '../libs/q.min',
            'Sha1': '../libs/sha1',
            'underscore': '../libs/underscore-min',
            'handlebars': '../libs/handlebars-v1.3.0',
        }
    });

    // нямам време за юнит тестове, за пейджиране на резултата, за добавяне на Sammy.js и за 100 други подобрения .... :(

    require(['controller', 'jquery', 'ui'], function (Controller, $, ui) {

        var controller = new Controller('http://localhost:3000');

        var wrapper = $('#wrapper');

        ui.login('#login');

        wrapper.on('click', '.user-register', function () {
            var user = ui.getUserData();
            if (user) {
                controller.userRegister(user.username, user.password)
                    .then(function (data) {
                        if (data) {
                            ui.status('User registered successfully', 'green');
                        }
                    }, function (err) {
                        var errorMessage = JSON.parse(err.responseText);
                        ui.status(errorMessage.message, 'red');
                    }).done();
            }
        });

        wrapper.on('click', '.user-login', function () {
            var user = ui.getUserData();
            if (user) {
                controller.userLogin(user.username, user.password);
            }
        });

        wrapper.on('click', '.user-logout', function () {
            controller.userLogout();
        });

        wrapper.on('click', '.send-post', function () {
            var post = ui.getPostData();
            controller.sendPost(post.title, post.content);
        })

        $('#get-post').on('click', function () {
            controller.getPosts();
        })
    });
}());
(function () {
    'use strict';
    require.config({
        paths: {
            'jquery': '../scripts/jquery-1.10.2.min',
            'Qlib': '../scripts/q.min',
        }
    });

    require(['controller', 'jquery', 'ui'], function (Controller, $, ui) {

        var controller = new Controller('http://localhost:33257');

        var wrapper = $('#wrapper');

        controller.run();

        wrapper.on('click', '.user-register', function () {
            var user = ui.getUserData();
            if (user) {
                controller.userRegister(user.username, user.password);
            }
        });

        wrapper.on('click', '.user-login', function () {
            var user = ui.getUserData();
            if (user) {
                controller.userLogin(user.username, user.password);
            }
        });

        wrapper.on('click', '.game-create', function () {

            controller.createGame();

        });

        wrapper.on('click', '.user-logout', function () {
            controller.userLogout();
        });

        wrapper.on('click', '.game-join', function () {
            controller.joinGame();
        });

        $('.game-box').on('click', function () {
            var $this = $(this);
            var classNames = $this.attr('class');
            var digit = classNames[classNames.length - 1];
            controller.enterSign(digit);
        });

        wrapper.on('click', '.game-getail', function () {
            controller.refresh();
        });

        wrapper.on('click', '.new-game', function () {
            controller.newGame();
            controller.run();
        })
    });
}());
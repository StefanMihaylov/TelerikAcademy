/// <reference path="D:\Exam\CrowdUI\CrowdUI\libs/jquery-2.1.1.js" />

define(['jquery'], function ($) {

    var ui = (function () {

        var container = $('<div/>');
        var label = $('<label/>');
        var input = $('<input/>');
        var button = $('<button/>');
        var textArea = $('<textarea/>');

        function clear(element) {
            while (element.firstChild) {
                element.removeChild(element.firstChild);
            }
        }

        function validateUserName(name) {
            return typeof name === 'string' && name.length >= 6 && name.length <= 40;
        }

        function status(text, color) {
            $('#status')
                .css("background-color", color)
                .text(text)
                .fadeIn(500)
                .delay(2000)
                .fadeOut(500);
        }

        function login(selector) {
            var wrapper = $(selector);
            clear(wrapper);

            var newContainer = container.clone(true);
            label.clone(true).text('Email:').appendTo(newContainer);
            input.clone(true).attr({ type: 'text' }).addClass('username').appendTo(newContainer);
            label.clone(true).text('Password:').appendTo(newContainer);
            input.clone(true).attr({ type: 'password' }).addClass('password').appendTo(newContainer);

            button.clone(true).text('Login').addClass('user-login').appendTo(newContainer);
            button.clone(true).text('Register').addClass('user-register').appendTo(newContainer);

            wrapper.append(newContainer);
        }

        function welcome(selector, userName, hasGame) {
            var result = $('#result');
            clear(result);

            result = $('#board');
            clear(result);

            var wrapper = $(selector);
            clear(wrapper);

            wrapper.text('Welcome, ' + userName + '!');
            button.clone(true).text('Logout').addClass('user-logout').appendTo(wrapper);

            var newContainer = container.clone(true);
           // button.clone(true).text('Refresh').addClass('game-getail').appendTo(newContainer);

            if (!hasGame) {

                button.clone(true).text('Create New Game').addClass('game-create').appendTo(newContainer);
                button.clone(true).text('Join Game').addClass('game-join').appendTo(newContainer);

            }
            else {
                ui.drawTable('#board', 3);
            }

            wrapper.append(newContainer);
        }

        function getUserData() {
            var userName = $('.username').val();
            var password = $('.password').val();

            $('.username').val('');
            $('.password').val('');

            if (validateUserName(userName)) {
                return {
                    username: userName,
                    password: password
                }
            }
            else {
                status('Username must be between 6 and 40 symbols', 'red');
            }
        }

        function gameOver(user, status) {
            var result = $('#result');
            var text = '';
            var color = '';

            if ((user && status === 3) || (!user && status === 4)) {
                text = 'You win';
                color = 'green'
            }
            else if ((user && status === 4) || (!user && status === 3)) {
                text = 'You lost';
                color = 'red'
            }
            else {
                text = 'Draw';
                color = 'yellow'
            }

            result.text(text).css("background-color", color);
            button.clone(true).text('Ok').addClass('new-game').appendTo(result);
        }

        function drawTable(selector, size) {
            var wrapper = $(selector);
            clear(wrapper);

            var newContainer = container.clone(true).addClass('turn1');
            newContainer.text('X : ');
            $('<span/>').addClass('x-player').appendTo(newContainer);
            wrapper.append(newContainer);
            var newContainer = container.clone(true).addClass('turn2');
            newContainer.text('O : ');
            $('<span/>').addClass('o-player').appendTo(newContainer);
            wrapper.append(newContainer);

            for (var i = 0; i < size; i++) {
                var newContainer = container.clone(true);
                for (var j = 0; j < size; j++) {
                    var box = container.clone(true);
                    box.addClass('game-box').html('&nbsp;').addClass('box' + (i * size + j)).appendTo(newContainer)
                }

                wrapper.append(newContainer);
            }
        }

        return {
            login: login,
            getUserData: getUserData,
            status: status,
            welcome: welcome,
            drawTable: drawTable,
            gameOver: gameOver
        }
    })();

    return ui;
});
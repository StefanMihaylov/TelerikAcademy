/// <reference path="D:\Exam\CrowdUI\CrowdUI\libs/jquery-2.1.1.js" />

define(['jquery', 'handlebars'], function ($, handlebars) {

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
            label.clone(true).text('Username:').appendTo(newContainer);
            input.clone(true).attr({ type: 'text' }).addClass('username').appendTo(newContainer);
            label.clone(true).text('Password:').appendTo(newContainer);
            input.clone(true).attr({ type: 'password' }).addClass('password').appendTo(newContainer);

            button.clone(true).text('Login').addClass('user-login').appendTo(newContainer);
            button.clone(true).text('Register').addClass('user-register').appendTo(newContainer);

            wrapper.append(newContainer);
        }

        function welcome(selector, userName) {
            var wrapper = $(selector);
            clear(wrapper);

            wrapper.text('Welcome, ' + userName + '!');
            button.clone(true).text('Logout').addClass('user-logout').appendTo(wrapper);

            var newContainer = container.clone(true);
            label.clone(true).text('Title:').appendTo(newContainer);
            input.clone(true).attr({ type: 'text' }).addClass('title').appendTo(newContainer);
            button.clone(true).text('Send').addClass('send-post').appendTo(newContainer);
            textArea.clone(true).addClass('content').appendTo(newContainer);

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

        function getPostData() {
            var title = $('.title').val();
            var content = $('.content').val();

            $('.title').val('');
            $('.content').val('');

            return {
                title: title,
                content: content
            }
        }

        function readSortOptions() {
            var sortByName = $('#by-column').val();
            var direction = $('#by-type').val();

            return {
                name: sortByName,
                dir: direction
            }
        }

        function drawTable(selector, data) {
            var tableTemplateHtml = document.getElementById('table-template').innerHTML;
            var tableTemplate = Handlebars.compile(tableTemplateHtml);
            $(selector).html(tableTemplate({ table: data }));

            function padString(number) {
                return (number < 10) ? "0" + number : "" + number;
            }
        }

        return {
            login: login,
            getUserData: getUserData,
            status: status,
            welcome: welcome,
            getPostData: getPostData,
            drawTable: drawTable,
            readSortOptions: readSortOptions
        }
    })();

    return ui;
});
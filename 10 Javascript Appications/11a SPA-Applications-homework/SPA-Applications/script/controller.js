/// <reference path="libs/jquery-2.1.1.js" />
/// <reference path="httpRequester.js" />

define(['httpRequester', 'jquery', 'ui'], function (httpRequest, $, ui) {
    var controller = (function () {

        var nickNameProperty = 'nickName';
        var storageKey = 'CrowedChat';
        var maxMessages = 100;
        var nickName;

        function isLoggedIn() {
            var userAsString = localStorage.getItem(storageKey);
            if (userAsString) {
                var user = JSON.parse(userAsString);

                if (user.hasOwnProperty(nickNameProperty)) {
                    nickName = user[nickNameProperty];
                    return true;
                }
            }

            return false;
        }

        function sendMessage(text) {
            var self = this;
            var currentMessage = {
                user: nickName,
                text: text
            };
            httpRequest.postJSON(self.serverUrl, currentMessage)
                .then(function (result) {
                    self.refreshMessages();
                })
                .done();
        }

        function logIn() {
            var user = {};
            nickName = $('#tb-login').val();
            user[nickNameProperty] = nickName.trim();
            localStorage.setItem(storageKey, JSON.stringify(user));
            ui.changeTemplates(this.wrapper, isLoggedIn(), nickName);
            this.refreshMessages();
        }

        function addEvents() {
            var self = this;
            $(self.wrapper).on('click', '#btn-login', function () {
                logIn.call(self);
            });

            $(self.wrapper).on('change', '#tb-login', function () {
                logIn.call(self);
            });

            $(self.wrapper).on('click', '#btn-logout', function () {
                localStorage.setItem(storageKey, '');
                ui.changeTemplates(self.wrapper, isLoggedIn(), nickName);
                self.refreshMessages();
            });

            $(self.wrapper).on('change', '#inputMessage', function () {
                var $inputBox = $(this);
                var message = $inputBox.val().trim();
                $inputBox.val(''); // clesr the input box

                if (message.length > 0) {
                    sendMessage.call(self, message);
                }
            });
        }

        function Controller(serverUrl, wrapper) {
            this.serverUrl = serverUrl;
            this.wrapper = wrapper;
        }

        Controller.prototype.refreshMessages = function () {
            httpRequest.getJSON(this.serverUrl)
                .then(function (data) {
                    var length = data.length;
                    var messages = data.slice(length - maxMessages);
                    ui.loadMessages('#messages', messages, nickName);
                }).done();
        }

        Controller.prototype.autoRefresh = function () {
            var self = this;
            self.refreshMessages();

            setInterval(function () {
                self.refreshMessages();
            }, 5000);
        }

        Controller.prototype.run = function () {
            addEvents.call(this);
            ui.changeTemplates(this.wrapper, isLoggedIn(), nickName);
            this.autoRefresh();
        }

        return Controller;
    })();

    return controller;
});
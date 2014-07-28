define(['jquery'], function ($) {
    var ui = (function () {
        'use strict';

        function loadMessages(selector, messages, nickName) {
            var $messagesWrapper = $('<ul/>'),
                $container = $('<li/>'),
                $span = $('<span/>'),
                $messageBox = $(selector);

            $messageBox.children().remove();

            for (var i = 0, len = messages.length; i < len; i++) {
                var currentMessage = messages[i];
                var $newSpan = $span.clone();
                var $newContainer = $container.clone();
                var userName = currentMessage.by;

                if (userName === nickName) {
                    $newSpan.addClass('myMessage');
                }
                $newContainer.append($newSpan.html(userName));

                $newContainer.append(' : ' + currentMessage.text);
                $messagesWrapper.append($newContainer);
            }
            $messageBox.append($messagesWrapper);
            $messageBox.scrollTop(10000);
        }

        function changeTemplates(selector, isLoggedIn, nickName) {
            if (isLoggedIn) {
                $(selector).load('templates/mainPage.html', function () {
                    $('#nickName').text(nickName);                    
                });
            }
            else {
                $(selector).load('templates/login.html');
            }
        }

        return {
            loadMessages: loadMessages,
            changeTemplates: changeTemplates
        }

    }());
    return ui;
})
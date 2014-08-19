/// <reference path="libs/jquery-2.1.1.js" />
/// <reference path="httpRequester.js" />

define(['httpRequester', 'jquery', 'ui','data'], function (httpRequest, $, ui, Data) {
    var controller = (function () {

        var _userName = '';

        function sha1Password(user, password) {
            return CryptoJS.SHA1(user + password).toString();
        }

        function getSessionKey() {
            return localStorage.getItem(_userName);
        }

        function Controller(rootUrl) {
            this.rootUrl = rootUrl;
            this.userUrl = this.rootUrl + '/user';
            this.authUrl = this.rootUrl + '/auth';
            this.postUrl = this.rootUrl + '/post'
        }

        Controller.prototype.getPosts = function () {
            httpRequest.getJSON(this.postUrl)
                .then(function (data) {
                    var options = ui.readSortOptions();
                    var convertedData = Data.convert(data, options);                   
                    ui.drawTable('#posts', convertedData);

                }, function (err) {
                    var errorMessage = JSON.parse(err.responseText);
                    ui.status(errorMessage.message, 'red');
                }).done();
        }

        Controller.prototype.sendPost = function (title, message) {
            var sessionKey = getSessionKey();
            var body = {
                "title": title,
                "body": message
            }
            httpRequest.postJSON(this.postUrl, body, sessionKey)
                .then(function (data) {
                    // console.log(data);
                }, function (err) {
                    var errorMessage = JSON.parse(err.responseText);
                    ui.status(errorMessage.message, 'red');
                }).done();
        }

        Controller.prototype.userRegister = function (userName, password) {
            var authCode = sha1Password(userName, password)
            var body = {
                "username": userName,
                "authCode": authCode
            }
            return httpRequest.postJSON(this.userUrl, body);
        }

        Controller.prototype.userLogin = function (userName, password) {
            var authCode = sha1Password(userName, password)
            var body = {
                "username": userName,
                "authCode": authCode
            }
            httpRequest.postJSON(this.authUrl, body)
                .then(function (data) {
                    if (data) {
                        localStorage.setItem(data.username, data.sessionKey);
                        _userName = data.username;
                        ui.welcome('#login', _userName);
                    }

                }, function (err) {
                    var errorMessage = JSON.parse(err.responseText);
                    ui.status(errorMessage.message, 'red');
                }).done();
        }

        Controller.prototype.userLogout = function () {
            var sessionKey = getSessionKey();

            httpRequest.putJSON(this.userUrl, true, sessionKey)
                .then(function (data) {
                    _userName = '';
                    ui.login();
                }, function (err) {
                    var errorMessage = JSON.parse(err.responseText);
                    ui.status(errorMessage.message, 'red');
                })
        }

        Controller.prototype.getUserName = function () {
            return _userName;
        }

        return Controller;
    }());

    return controller;
});
/// <reference path="libs/jquery-2.1.1.js" />
/// <reference path="httpRequester.js" />

define(['httpRequester', 'jquery', 'ui'], function (httpRequest, $, ui) {
    var controller = (function () {

        var _userName = 'userName';
        var _tokenName = 'token';
        var _gameIdName = 'gameId';

        var _board = '';

        function setUserName(name) {
            localStorage.setItem(_userName, name);
        }

        function getUserName() {
            return localStorage.getItem(_userName);
        }

        function setToken(token) {
            localStorage.setItem(_tokenName, token);
        }

        function getToken() {
            return localStorage.getItem(_tokenName);
        }

        function setGameId(game) {
            localStorage.setItem(_gameIdName, game);
        }

        function getGameId() {
            return localStorage.getItem(_gameIdName);
        }

        function fillBoard(data) {

            var player = getUserName();
            var isFirst = player === data.FirstPlayerName;

            $('.x-player').text(data.FirstPlayerName);
            if (data.SecondPlayerName) {
                $('.o-player').text(data.SecondPlayerName);
            }

            _board = data.Board;

            for (var i = 0; i < _board.length; i++) {
                if (_board[i] !== '-') {
                    $('.box' + i).text(_board[i]);
                }
            }

            var status = data.State;
            $('.turn1').css('color', 'black');
            $('.turn2').css('color', 'black');

            switch (status) {
                case 1:
                    $('.turn1').css('color', 'green');
                    break;
                case 2:
                    $('.turn2').css('color', 'green');
                    break;
                case 3:
                case 4:
                case 5:
                    ui.gameOver(isFirst, status);
                    break;
                default:
            }


        }

        function Controller(rootUrl) {
            this.rootUrl = rootUrl;

            this.registerUrl = this.rootUrl + '/api/Account/register';
            this.logoutUrl = this.rootUrl + '/api/Account/logout';
            this.authUrl = this.rootUrl + '/Token';

            this.gameUrl = this.rootUrl + '/api/games/';

            this.createUrl = this.rootUrl + '/api/games/create';
            this.joinUrl = this.rootUrl + '/api/games/join';
        }

        Controller.prototype.userRegister = function (userName, password) {
            var body = {
                "email": userName,
                "password": password,
                "confirmpassword": password
            }

            httpRequest.register(this.registerUrl, body)
                .then(function (data) {
                    ui.status('User registered successfully', 'green');
                }, function (err) {
                    var errorMessage = JSON.parse(err.responseText);
                    var message = errorMessage.Message;
                    ui.status(message, 'red');
                }).done();
        }

        Controller.prototype.userLogin = function (userName, password) {
            var body = {
                "username": userName,
                "password": password
            }

            httpRequest.login(this.authUrl, body)
                 .then(function (data) {
                     if (data) {
                         setUserName(data.userName);
                         setToken(data.access_token);

                         ui.welcome('#login', getUserName());
                     }

                 }, function (err) {
                     var errorMessage = JSON.parse(err.responseText);
                     ui.status(errorMessage.error_description, 'red');
                 }).done();
        }

        Controller.prototype.userLogout = function () {
            setUserName('');
            setToken('');
            setGameId('');
            ui.login();

            //var token = getToken();
            //httpRequest.postJSON(this.logoutUrl, '', token)
            //    .then(function (data) {
            //        setUserName('');
            //        setToken('');
            //        setGameId('');
            //        ui.login();
            //    }, function (err) {
            //        var errorMessage = JSON.parse(err.responseText);
            //        ui.status(errorMessage.Message, 'red');
            //    }).done();
        }

        Controller.prototype.createGame = function () {
            var self = this;
            var token = getToken();
            httpRequest.postJSON(this.createUrl, "", token)
                .then(function (data) {
                    ui.status('New game created', 'green');
                    setGameId(data);
                    self.refresh();
                }, function (err) {
                    var errorMessage = JSON.parse(err.responseText);
                    ui.status(errorMessage.Message, 'red');
                }).done();
        }

        Controller.prototype.joinGame = function () {
            var self = this;
            var token = getToken();
            httpRequest.postJSON(this.joinUrl, '', token)
                .then(function (data) {
                    fillBoard(data);
                    self.refresh();
                }, function (err) {
                    var errorMessage = JSON.parse(err.responseText);
                    ui.status(errorMessage.Message, 'red');
                });

        }

        Controller.prototype.getData = function getData() {
            var gameId = getGameId();
            var token = getToken();
            if (gameId) {
                httpRequest.getJSON(this.gameUrl + 'status?gameId=' + gameId, token)
                    .then(function (data) {
                        fillBoard(data);
                    }, function (err) {
                        var errorMessage = JSON.parse(err.responseText);
                        ui.status(errorMessage.Message, 'red');
                    });
            }
        }

        Controller.prototype.enterSign = function (digit) {
            if (_board[digit] === '-') {
                var row = Math.floor(digit / 3) + 1;
                var col = Math.floor(digit % 3) + 1;

                var inputData = { GameId: getGameId(), Row: row, Col: col };
                var token = getToken();
                httpRequest.postJSON(this.gameUrl + 'play', JSON.stringify(inputData), token)
                    .then(function (data) {

                    }, function (err) {
                        var errorMessage = JSON.parse(err.responseText);
                        ui.status(errorMessage.Message, 'red');
                    }).done();
            }
        }


        Controller.prototype.getUserName = function () {
            return getUserName();
        }

        Controller.prototype.newGame = function () {
            setGameId('');
        }

        Controller.prototype.hasToken = function () {
            var token = getToken();
            if (token) {
                return true;
            }
            else {
                return false;
            }
        }

        Controller.prototype.hasGame = function () {
            var game = getGameId();
            if (game) {
                return true;
            }
            else {
                return false;
            }
        }

        Controller.prototype.refresh = function () {
            var self = this;
            self.getData();

            setInterval(function () {
                self.getData();
            }, 1000);
        }

        Controller.prototype.run = function () {
            var token = this.hasToken();
            if (token) {
                ui.welcome('#login', this.getUserName(), this.hasGame());
                this.refresh();
            }
            else {
                ui.login('#login');
            }
        }

        return Controller;
    }());

    return controller;
});
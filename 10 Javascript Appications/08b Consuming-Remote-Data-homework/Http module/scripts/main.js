(function () {
    'use strict';
    require.config({
        paths: {
            'Qlib': '../libs/q.min1'
        }
    });

    require(['requestModule', 'ui'], function (request, ui) {

        var serverUrl = 'http://localhost:3000/students';
        var resultId = 'result';
        var errorMessage = 'Error! See the browser console for more information';

        var headerOptions = {
            contentType: 'application/json',
            accept: 'application/json',
        };

        var firstStudent = {
            name: "Ivan Ivanov",
            grade: 6
        };
        var secondStudent = {
            name: "Sylvia Petrova",
            grade: 4
        };
        var thirdStudent = {
            name: "Nikolay Dimitrov",
            grade: 5
        };

        document.getElementById('add').addEventListener('click', function () {
            request.postJSON(serverUrl, firstStudent, headerOptions)
           .then(request.postJSON(serverUrl, secondStudent, headerOptions))
           .then(request.postJSON(serverUrl, thirdStudent, headerOptions))
           .done(null, function (err) {
               ui.error(resultId, errorMessage);
           });
        });

        document.getElementById('get').addEventListener('click', function () {
            request.getJSON(serverUrl, headerOptions)
                .then(function (data) {
                    var result = JSON.parse(data);
                    ui.display(resultId, result.students);
                }, function (error) {
                    ui.error(resultId, errorMessage);
                })
                .done();
        });

    });
}());
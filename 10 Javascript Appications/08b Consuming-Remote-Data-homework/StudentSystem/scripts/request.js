define(['jquery', 'ui'], function ($, ui) {
    var request = (function () {

        var serverUrl = 'http://localhost:3000/students';
        var resultId = 'result';
        var statusId = 'status';
        var errorMessage = 'Error! See the browser console for more information';

        var add = function () {
            var data = ui.getName();
            $.post(serverUrl, data)
                .then(function (returnedData) {
                    ui.status(statusId, 'Student saved', 'green');
                }, function (error) {
                    ui.status(statusId, errorMessage, 'red');
                }).done();
        }

        var get = function () {
            $.get(serverUrl)
                .then(function (data) {
                    ui.display(resultId, data.students);
                    ui.status(statusId, 'Ready', 'green');
                }, function (error) {
                    ui.status(statusId, errorMessage, 'red');
                }).done();
        }

        var del = function () {
            var id = ui.getId();
            $.ajax({
                url: serverUrl + '/' + id,
                type: 'POST',
                timeout: 5000,
                data: { _method: 'delete' }
            }).then(function (data) {
                ui.status(statusId, 'Student deleted', 'green');
            }, function (error) {
                ui.status(statusId, errorMessage, 'red');
            }).done();
        }

        return {
            post: add,
            get: get,
            del: del
        }
    }());

    return request;
});
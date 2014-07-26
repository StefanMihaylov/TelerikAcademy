/// <reference path=libs/jquery-2.0.2.js" />
define(['jquery'], function ($) {
    var ui = (function () {

        var container = document.createDocumentFragment();
        var divElement = document.createElement('div');

        var nameId = 'student-name';
        var gradeId = 'student-grade';
        var idId = 'student-id';

        function clear(element) {
            while (element.firstChild) {
                element.removeChild(element.firstChild);
            }
        }

        var display = function (idSelector, data) {
            for (var i = 0, len = data.length; i < len; i++) {
                var currentElement = data[i];

                var currentDiv = divElement.cloneNode(true);
                currentDiv.innerHTML =
                    'id: ' + currentElement.id +
                    ', name: ' + currentElement.name +
                    ', grade: ' + currentElement.grade;
                container.appendChild(currentDiv);
            }

            var resultContainer = document.getElementById(idSelector);
            clear(resultContainer);
            resultContainer.appendChild(container);
        }

        var status = function (idSelector, text, color) {
            $('#' + idSelector)
                .css("background-color", color)
                .text(text)
                .fadeIn(500)
                .delay(2000)
                .fadeOut(500);
        }

        var getName = function () {
            var name = document.getElementById(nameId).value;
            var grade = document.getElementById(gradeId).value;
            return {
                name: name,
                grade: grade
            }
        }

        var getId = function () {
            var id = document.getElementById(idId).value;
            return id;
        }

        return {
            display: display,
            status: status,
            getName: getName,
            getId: getId
        }
    }());

    return ui;
});
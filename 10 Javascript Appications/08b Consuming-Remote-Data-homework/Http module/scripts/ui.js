define(function () {
    var ui = (function () {

        var container = document.createDocumentFragment();
        var divElement = document.createElement('div');        
        
        function clear(element){
            while (element.firstChild) {
                element.removeChild(element.firstChild);
            }
        }

        var display = function (idSelector, data) {
            for (var i = 0, len = data.length; i < len; i++) {
                var currentElement = data[i];
                var currentDiv = divElement.cloneNode(true);
                currentDiv.innerHTML = currentElement.name + ' : ' + currentElement.grade;
                container.appendChild(currentDiv);
            }

            var resultContainer = document.getElementById(idSelector);
            clear(resultContainer);
            resultContainer.appendChild(container);
        }

        var error = function (idSelector, text) {
            var resultContainer = document.getElementById(idSelector);
            resultContainer.innerHTML = text;
        }

        return {
            display: display,
            error: error
        }
    }());

    return ui;
});
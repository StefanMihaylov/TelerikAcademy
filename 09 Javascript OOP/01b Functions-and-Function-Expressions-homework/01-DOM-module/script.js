'use strict';
var domModule = (function () {
    var container = document.createDocumentFragment();
    var containerCounts = 0;
    var maxElementsInContainer = 10;

    function appendChild(element, selector) {
        var selected = document.querySelector(selector);
        selected.appendChild(element);
    }

    function removeChild(parent, selector) {
        var parent = document.querySelector(parent);
        var selected = parent.querySelector(selector);
        parent.removeChild(selected);
    }

    function addHandler(selector, eventType, eventFunction) {
        var selected = document.querySelector(selector);
        selected.addEventListener(eventType, eventFunction);
    }

    function appendToBuffer(parent, element) {
        container.appendChild(element);
        containerCounts++;
        if (containerCounts >= maxElementsInContainer) {
            var parent = document.querySelector(parent);
            parent.appendChild(container);
            containerCounts = 0;
            container = document.createDocumentFragment();
        }
    }

    function getElement(selector){
        return document.querySelector(selector);
    }

    return{
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
        getElement: getElement
    };
}());

//1: appends div to #wrapper
var div = document.createElement("div");
div.innerHTML = 'Added Div element';
domModule.appendChild(div, "#wrapper");

// 2: appends ul and 5 li to #wrapper, removes li:first-child from ul
var ul = document.createElement("ul");
var li = document.createElement("li");
for (var i = 0; i < 5; i++) {
    li.innerText = 'Item ' + (i + 1);
    ul.appendChild(li.cloneNode(true));
}
domModule.appendChild(ul, "#wrapper");
domModule.removeChild("ul", "li:first-child");

// 3: add handler to each a element with class button
domModule.addHandler("a.button", 'click', function () {
    alert("Clicked")
});

// 4: Add elements to buffer, which appends them to the DOM when their count for some selector becomes 100
//      The buffer contains elements for each selector it gets
// For testing: Add the 20 div as two batches of 10 elements)
for (var i = 0; i < 20; i += 1) {
    var newDiv = div.cloneNode(true);
    newDiv.innerText += ( ' ' + (i + 1));
    domModule.appendToBuffer("#container", newDiv);
}

// 5: Get elements by CSS selector - see the result on the console
console.log(domModule.getElement('ul > li:first-child'));


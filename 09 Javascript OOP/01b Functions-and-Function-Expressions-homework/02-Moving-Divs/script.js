'use strict';
window.onload = function () {

    var movingShapes = (function () {
        var rectContainer = document.querySelector('#rect-wrapper');
        var rectTop = 100;
        var rectLeft = 0;
        var rectBottom = 350;
        var rectRight = 400;
        var rectStep = 3;

        var ellipseContainer = document.querySelector('#ellipse-wrapper');
        var ellipseCenterX = 250;
        var ellipseCenterY = 250;
        var ellipseRadius = 200;
        var ellipseStep = 0.02;

        var div = document.createElement('div');
        div.style.width = '80px';
        div.style.height = '40px';
        div.style.border = '4px solid';
        div.style.borderRadius = '20px';
        div.style.position = 'absolute';

        function generateRandomElement() {
            var newElement = div.cloneNode(true);
            newElement.style.borderColor = getRandomColour();
            newElement.style.backgroundColor = getRandomColour();
            newElement.style.color = getRandomColour();
            return newElement;
        }

        function getRandomInt(minValue, maxValue) {
            return Math.floor(Math.random() * (maxValue - minValue + 1)) + minValue;
        }

        function getRandomColour() {
            var red = getRandomInt(0, 255).toString(16);
            var green = getRandomInt(0, 255).toString(16);
            var blue = getRandomInt(0, 255).toString(16);
            return '#' + red + green + blue;
        }

        function addRect() {
            var element = generateRandomElement();
            element.style.top = rectTop + 'px';
            element.style.left = rectLeft + 'px';
            element.setAttribute('direction', 'down');
            rectContainer.appendChild(element);
        }

        function addEllipse() {
            var element = generateRandomElement();
            element.style.top = ellipseCenterY + 'px';
            element.style.left = ellipseCenterX + ellipseRadius + 'px';
            element.setAttribute('angle', '0');
            ellipseContainer.appendChild(element);
        }

        function add(type) {
            if (type === 'rect') {
                addRect();
            }
            else if (type === 'ellipse') {
                addEllipse();
            }
            else {
                throw new Error('Error movement type');
            }
        }

        function moveEllipse() {
            var ellipseChildren = ellipseContainer.childNodes;
            var len = ellipseChildren.length;
            for (var i = 0; i < len; i += 1) {
                var child = ellipseChildren[i];
                if (child.nodeName === 'DIV') {
                    var angle = parseFloat(child.getAttribute('angle'));
                    angle += ellipseStep;
                    var newX = ellipseCenterX + ellipseRadius * Math.cos(angle);
                    var newY = ellipseCenterY + 2 * ellipseRadius / 3 * Math.sin(angle);
                    child.setAttribute('angle', angle.toString());
                    child.style.top = newY + 'px';
                    child.style.left = newX + 'px';
                }
            }
        }

        function moveRect() {
            var rectChildren = rectContainer.childNodes;
            var len = rectChildren.length;
            for (var i = 0; i < len; i += 1) {
                var child = rectChildren[i];
                if (child.nodeName === 'DIV') {
                    var direction = child.getAttribute('direction');
                    var topAsString = child.style.top;
                    var leftAsString = child.style.left;
                    var y = parseFloat(topAsString.substr(0, topAsString.length - 2));
                    var x = parseFloat(leftAsString.substr(0, leftAsString.length - 2));
                    switch (direction) {
                        case 'down':
                            y += rectStep;
                            if (y >= rectBottom) {
                                y = rectBottom;
                                direction = 'right';
                            }
                            break;
                        case 'up':
                            y -= rectStep;
                            if (y <= rectTop) {
                                y = rectTop;
                                direction = 'left';
                            }
                            break;
                        case 'left':
                            x -= rectStep;
                            if (x <= rectLeft) {
                                x = rectLeft;
                                direction = 'down';
                            }
                            break;
                        case 'right':
                            x += rectStep;
                            if (x >= rectRight) {
                                x = rectRight;
                                direction = 'up';
                            }
                            break;
                    }
                    child.setAttribute('direction', direction.toString());
                    child.style.top = y + 'px';
                    child.style.left = x + 'px';
                }
            }
        }

        (function move() {
            moveEllipse();
            moveRect();
            requestAnimationFrame(move, 100);
        })();

        return{
            add: add
        };
    }());


    //add element with rectangular movement
    document.getElementById('add-rectangle-btn').addEventListener('click', function () {
        movingShapes.add('rect');
    });

    //add element with ellipse movement
    document.getElementById('add-ellipse-btn').addEventListener('click', function () {
        movingShapes.add('ellipse');
    });
};
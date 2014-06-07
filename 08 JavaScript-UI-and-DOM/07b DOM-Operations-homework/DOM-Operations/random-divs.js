window.onload = function () {

    function getRandomInt(minValue, maxValue) {
        return Math.floor(Math.random() * (maxValue - minValue + 1)) + minValue;
    }

    function getRandomColour() {
        var red = getRandomInt(0, 255).toString(16);
        var green = getRandomInt(0, 255).toString(16);
        var blue = getRandomInt(0, 255).toString(16);
        return '#' + red + green + blue;
    }

    function parsePixels(pixels) {
        var numberAsString = pixels.substr(0, pixels.length - 2);
        return parseInt(numberAsString, 10);
    }

    var divCount = 20;
    var fragment = document.createDocumentFragment();
    var wrapper = document.querySelector('#wrapper');

    var wrapperWidth = parsePixels(wrapper.style.width);
    var wrapperHeight = parsePixels(wrapper.style.height);

    for (var i = 0; i < divCount; i++) {

        // A strong element with text "div" inside the div
        var strongElement = document.createElement('strong');
        strongElement.innerHTML = 'Div';

        var divElement = document.createElement('div');
        divElement.appendChild(strongElement);

        // Random width and height between 20px and 100px
        divElement.style.width = getRandomInt(20, 100) + 'px';
        divElement.style.height = getRandomInt(20, 100) + 'px';

        // Random background color
        divElement.style.backgroundColor = getRandomColour();

        // Random font color
        divElement.style.color = getRandomColour();

        // Random border width between 1px and 20px
        divElement.style.borderWidth = getRandomInt(1, 20) + 'px';

        // Random border radius
        divElement.style.borderRadius = getRandomInt(0, 30) + 'px';

        // Random border color
        divElement.style.borderColor = getRandomColour();
        divElement.style.borderStyle = 'solid';

        // Random position on the screen (position:absolute)
        divElement.style.position = 'absolute';
        var borderWidth = parsePixels(divElement.style.borderWidth);
        var maxWidth = wrapperWidth - parsePixels(divElement.style.width) - 2 * borderWidth;
        var maxHeight = wrapperHeight - parsePixels(divElement.style.height) - 2 * borderWidth;

        divElement.style.left = getRandomInt(0, maxWidth) + 'px';
        divElement.style.top = getRandomInt(0, maxHeight) + 'px';

        fragment.appendChild(divElement);
    }

    wrapper.appendChild(fragment);
}
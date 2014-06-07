window.onload = function () {

    var tagsTextArea = document.querySelector('#tags');
    var wrapper = document.querySelector('#wrapper');
    
    document.querySelector('#generate').addEventListener('click', function () {
        var tags = tagsTextArea.value.split(',');
        var tagCloud = generateTagCloud(tags, 17, 42);
        clearNodeContent(wrapper);
        wrapper.appendChild(tagCloud);
    });

    function clearNodeContent(node) {
        while (node.firstChild) {
            node.removeChild(node.firstChild);
        }
    }

    function generateTagCloud(tags, minFontSize, maxFontSize) {
        var tagsDictionary = [];
        for (var i = 0; i < tags.length; i++) {
            var currentTag = tags[i].toLowerCase().trim();
            if (tagsDictionary[currentTag] === undefined) {
                tagsDictionary[currentTag] = 1;
            } else {
                tagsDictionary[currentTag]++
            }
        }

        var minCount = 0,
            maxCount = 0;
        for (var tagIndex in tagsDictionary) {
            var currentCount = tagsDictionary[tagIndex];
            if (minCount === 0 || minCount > currentCount) {
                minCount = currentCount;
            }

            if (maxCount < currentCount) {
                maxCount = currentCount;
            }
        }

        var lineSlope = (maxFontSize - minFontSize) / (maxCount - minCount);

        var fragment = document.createDocumentFragment();

        for (var tagIndex in tagsDictionary) {
            currentCount = tagsDictionary[tagIndex];
            var currentFontSize = (lineSlope * (currentCount - minCount)) + minFontSize;

            var spanElement = document.createElement('span');
            spanElement.innerHTML = tagIndex + ' ';
            spanElement.style.fontSize = currentFontSize + 'px';
            fragment.appendChild(spanElement);
        }

        return fragment;
    }
};
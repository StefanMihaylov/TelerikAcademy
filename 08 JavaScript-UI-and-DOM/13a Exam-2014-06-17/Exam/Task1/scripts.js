function createImagesPreviewer(selector, items) {
    var mainContainer = document.createElement('div'),
        container = document.createElement('div'),
        title = document.createElement('h3'),
        leftTitle = document.createElement('h1'),
        image = document.createElement('img');

    mainContainer.style.display = 'inline-block';
    mainContainer.style.padding = 0;
    mainContainer.style.margin = 0;
    mainContainer.style.textAlign = 'center';
    mainContainer.style.verticalAlign = 'top';

    container.style.display = 'block';

    title.style.margin = 0;
    title.style.padding = 0;
    title.className = 'image-title';

    image.setAttribute('width', '250px');
    image.setAttribute('height', 'auto');
    image.style.borderRadius = '10px';

    leftTitle.style.margin = '5px';
    leftTitle.style.padding = 0;

    container.appendChild(title);
    container.appendChild(image);

    var filter = document.createElement('div');
    var filterTitle = title.cloneNode(true);
    filterTitle.innerHTML = 'Filter';

    var filterInput = document.createElement('input');
    filterInput.setAttribute('type', 'text');

    filter.appendChild(filterTitle);
    filter.appendChild(filterInput);

    var imageList = [];
    var listContainer = document.createElement('div');
    for (var i = 0; i < items.length; i++) {
        var currentItem = items[i];
        title.innerHTML = currentItem.title;
        image.setAttribute('src', currentItem.url);
        image.setAttribute('alt', currentItem.title);
        var currentContainer = container.cloneNode(true);
        imageList.push(currentContainer);
        listContainer.appendChild(currentContainer);
    }

    var leftDiv = mainContainer.cloneNode(true);

    leftTitle.innerHTML = items[0].title;
    var leftImage = image.cloneNode(true);
    leftImage.setAttribute('src', items[0].url);
    leftImage.setAttribute('alt', items[0].title);
    leftImage.setAttribute('width', '600px');
    leftDiv.appendChild(leftTitle);
    leftDiv.appendChild(leftImage);

    leftDiv.style.width = '700px';

    var rightDiv = mainContainer.cloneNode(true);
    rightDiv.appendChild(filter);
    rightDiv.appendChild(listContainer);
    rightDiv.style.width = '290px';
    rightDiv.style.height = '650px';
    rightDiv.style.overflowY = 'scroll';

    var fragment = document.createDocumentFragment();
    fragment.appendChild(leftDiv);
    fragment.appendChild(rightDiv);

    var selectedElement = document.querySelector(selector);
    selectedElement.appendChild(fragment);

    rightDiv.addEventListener('mouseover', function (ev) {
        var selected = ev.target;
        if (selected.nodeName === 'IMG') {
            selected.parentNode.style.backgroundColor = '#bbb';
        }
    });

    rightDiv.addEventListener('mouseout', function (ev) {
        var selected = ev.target;
        if (selected.nodeName === 'IMG') {
            selected.parentNode.style.backgroundColor = '';
        }
    });

    rightDiv.addEventListener('click', function (ev) {
        var current = ev.target;
        if (current.nodeName === 'IMG') {
            var newSource = current.getAttribute('src');
            var newTitle = current.parentNode.querySelector('.image-title');
            leftImage.setAttribute('src', newSource);
            leftImage.setAttribute('alt', newTitle.innerHTML);
            leftTitle.innerHTML = newTitle.innerHTML;
        }
    });

    filterInput.addEventListener('input', function () {
        filterImages(imageList, this);
    });

    filterInput.addEventListener('change', function () {
        filterImages(imageList, this);
    });

    function filterImages(list, element) {
        var value = element.value.trim();
        if (value.length) {
            filterAll(list, value);
        }
        else {

            for (var i = 0; i < list.length; i++) {
                list[i].style.display = '';
            }
        }
    }

    function filterAll(list, value) {
        for (var i = 0; i < list.length; i++) {
            var currentTitle = list[i].querySelector('.image-title').innerHTML;
            var currentTitleLowerCase = currentTitle.toLowerCase();
            var valueLowerCase = value.toLowerCase();
            if (currentTitleLowerCase.indexOf(valueLowerCase) === -1) {
                list[i].style.display = 'none';
            }
            else {
                list[i].style.display = '';
            }
        }
    }
}
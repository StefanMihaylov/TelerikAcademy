window.onload = function () {
    var list = document.querySelector('#list');
    var input = document.querySelector('#new-item');

    document.querySelector('#add-button').addEventListener('click', function () {
        if (input.value.length > 0) {
            var spanElement = document.createElement('span');
            var liElement = document.createElement('li');
            spanElement.innerHTML = input.value;
            input.value = '';
            liElement.appendChild(spanElement);
            list.appendChild(liElement);
        }
    });

    document.querySelector('#hide-button').addEventListener('click', function () {
        list.style.display = 'none';
    });

    document.querySelector('#show-button').addEventListener('click', function () {
        list.style.display = '';
    });

    list.addEventListener('click', function (ev) {
        if (ev.target.nodeName === 'SPAN') {
            if (ev.target.className === 'selected') {
                ev.target.className = '';
            }
            else {
                ev.target.className = 'selected';
            }
        }
        else if (ev.target.nodeName === 'LI') {
            if (ev.target.querySelector('span').className === 'selected') {
                ev.target.querySelector('span').className = '';
            }
            else {
                ev.target.querySelector('span').className = 'selected';
            }
        }

    });

    document.querySelector('#delete-button').addEventListener('click', function () {
        var liItems = list.getElementsByTagName('li');
        for (var i = 0; i < liItems.length; i++) {
            if (liItems[i].querySelector('span').className === 'selected') {
                list.removeChild(liItems[i]);
                i--;
            }
        }
    });
}
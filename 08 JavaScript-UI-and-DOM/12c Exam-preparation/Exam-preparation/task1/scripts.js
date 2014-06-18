function createCalendar(selector, events) {

    var daysOfWeek = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
    var divElement = document.createElement('div');
    var title = document.createElement('span');
    title.className = 'date-title';
    var content = document.createElement('div');
    content.className = 'date-content';
    content.innerHTML = '&nbsp;';


    divElement.appendChild(title);
    divElement.appendChild(content);

    divElement.style.width = parseInt(window.innerWidth / 7.5) + 'px';
    divElement.style.height = divElement.style.width;
    divElement.style.display = 'inline-block';
    divElement.style.textAlign = 'center';
    divElement.style.border = '1px solid black';

    title.style.borderBottom = '1px solid black';
    title.style.display = 'block';
    title.style.padding = '5px 0';
    title.style.backgroundColor = '#ccc';

    var divArray = [];
    for (var i = 0; i < 30; i++) {
        title.innerHTML = daysOfWeek[i % 7] + ' ' + (i + 1) + ' Jun 2014';
        divArray.push(divElement.cloneNode(true));
    }

    for (i = 0; i < events.length; i++) {
        var currentEvent = events[i];
        var date = currentEvent.date;
        divArray[date - 1].querySelector('.date-content').innerHTML = currentEvent.hour + ' ' + currentEvent.title;
    }

    var selectedBox = null;
    var container = document.createDocumentFragment();
    for (i = 0; i < divArray.length; i++) {
        divArray[i].addEventListener('mouseover', function () {
            this.querySelector('.date-title').style.backgroundColor = 'skyblue';
        });
        divArray[i].addEventListener('mouseout', function () {
            this.querySelector('.date-title').style.backgroundColor = '#ccc';
        });
        divArray[i].addEventListener('click', function () {
            if (selectedBox) {
                selectedBox.style.backgroundColor = '';
            }
            if (selectedBox === this) {
                selectedBox = null;
            }
            else {
                selectedBox = this;
                this.style.backgroundColor = 'lightgreen';
            }            
        });
        container.appendChild(divArray[i]);
    }

    var wrapper = document.querySelector(selector);
    wrapper.appendChild(container);
}
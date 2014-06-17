function createCalendar(selector, events) {
    var container = document.querySelector(selector),
        dayElement = document.createElement('div'),
        dayTitle = document.createElement('div'),
        dayContent = document.createElement('div'),
        daysInJune = 30;

    //Styling elements
    container.style.width = '1100px';

    dayElement.className = 'day';
    dayElement.style.width = '150px';
    dayElement.style.height = '120px';
    dayElement.style.border = '1px solid black';
    dayElement.style.cssFloat = 'left'

    dayTitle.style.height += '25px';
    dayTitle.className += ' title';
    dayTitle.style.backgroundColor = '#999';
    dayTitle.style.borderBottom = '1px solid black';
    dayTitle.style.textAlign = 'center';

    dayContent.className += ' content';

    // add days to DOM
    var fragment = document.createDocumentFragment();
    for (var i = 1; i <= daysInJune; i++) {
        var currentDay = dayElement.cloneNode(true),
            currentTitle = dayTitle.cloneNode(true),
            currentContent = dayContent.cloneNode(true),
            dayAsString = getWeekDay(i);

        currentTitle.innerText = dayAsString + ' ' + i + ' June 2014';

        currentContent.className += ' day' + i;

        currentDay.appendChild(currentTitle);
        currentDay.appendChild(currentContent);
        fragment.appendChild(currentDay);
    }

    container.appendChild(fragment);

    // add events to calendar
    for (var i = 0, length = events.length; i < length; i++) {
        var eventDaySelector = '.day' + events[i].date,
            eventDay = document.querySelector(eventDaySelector)

        eventDay.innerText = events[i].hour + ' ' + events[i].title;
    }

    // mouse interaction
    var selectedDay = document.querySelectorAll('.day');
    for (var i = 0; i < daysInJune; i++) {
        selectedDay[i].addEventListener('mouseover', trackMouseOver);
        selectedDay[i].addEventListener('mouseout', trackMouseOut);
        selectedDay[i].addEventListener('click', trackMouseClick);
    }

}

function trackMouseOver() {
    var title = this.firstChild;
    title.style.backgroundColor = '#666';
}

function trackMouseOut() {
    var title = this.firstChild;
    title.style.backgroundColor = '#999';
}

function trackMouseClick() {
    var title = this.firstChild,
        content = this.lastChild,
        oldSelected = document.querySelectorAll('.selected'),
        newSelected;

    if (oldSelected[0]) {
        var oldClassName = oldSelected[0].className;
        oldClassName = oldClassName.replace(' selected', '');
        oldSelected[0].className = oldClassName;
        oldSelected[0].style.backgroundColor = '';
    }

    this.className += ' selected';
    this.style.background = '#777';
}

function getWeekDay(date) {
    var dayAsNumber = date % 7,
        dayAsString;
    switch (dayAsNumber) {
        case 0: return dayAsString = 'Sat'; break;
        case 1: return dayAsString = 'Sun'; break;
        case 2: return dayAsString = 'Mon'; break;
        case 3: return dayAsString = 'Tue'; break;
        case 4: return dayAsString = 'Wed'; break;
        case 5: return dayAsString = 'Thu'; break;
        case 6: return dayAsString = 'Fri'; break;
    }

}
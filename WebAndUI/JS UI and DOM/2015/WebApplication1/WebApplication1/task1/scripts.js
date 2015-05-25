var createCalendar = function (selector, events) {
    var table = addDays(selector);
    addStyles(table);
    addEvents(events);
};

function addDays(selector) {
    var parent,
        fragment,
        table,
        tableRow,
        currentWeek,
        week,
        daysInWeek = 7,
        tableCell,
        dayHeader,
        dayFooter,
        date;

    parent = document.querySelector(selector);
    fragment = document.createDocumentFragment();
    table = document.createElement("div");

    for (var days = 0; days < 31; days++) {
        week = (days / daysInWeek) | 0;
        if (week !== currentWeek) {
            currentWeek = week;
            tableRow = document.createElement("div");
            tableRow.className = "week";
            table.appendChild(tableRow);
        }

        tableCell = document.createElement("div");
        tableCell.className = "day";
        tableCell.id = (days + 1);
        tableRow.appendChild(tableCell);

        dayHeader = document.createElement("div");
        dayHeader.className = "header";
        date = new Date(14, 5, (days + 1));
        dayHeader.innerText = date.toDateString();
        tableCell.appendChild(dayHeader);

        dayFooter = document.createElement("div");
        dayFooter.className = "footer";
        tableCell.appendChild(dayFooter);
    }

    parent.appendChild(table);

    return table;
};

function addStyles(table) {
    var days;

    days = document.querySelectorAll(".day");
    for (var index = 0, length = days.length; index < length; index++) {
        days[index].style.display = "inline-block";
        days[index].style.width = "150px";
        days[index].style.height = "100px";
        days[index].style.textAlign = "center";
        days[index].style.margin = 0;
        days[index].style.padding = 0;
        days[index].addEventListener("mouseover", dayEnter);
        days[index].addEventListener("mouseout", dayLeave);
        days[index].addEventListener("click", dayClick);
    }

    headers = document.querySelectorAll(".header");
    for (var index = 0, length = headers.length; index < length; index++) {
        headers[index].style.border = "1px solid black";
        headers[index].style.height = "20px";
        headers[index].style.backgroundColor = "#ccc";
        headers[index].style.margin = 0;
        headers[index].style.padding = 0;
    }

    footers = document.querySelectorAll(".footer");
    for (var index = 0, length = footers.length; index < length; index++) {
        footers[index].style.border = "1px solid black";
        footers[index].style.height = "76px";
        footers[index].style.margin = 0;
        footers[index].style.padding = 0;
    }
}

function addEvents(events) {
    for (var index = 0, length = events.length; index < length; index++) {
        var day = events[index].date,
            time = events[index].hour,
            title = events[index].title,
            dayElement,
            childs;

        dayElement = document.getElementById(day);
        childs = dayElement.childNodes;
        for (var day = 0, length = childs.length; day < length; day++) {
            if (childs[day].className.indexOf("footer") > -1) {
                childs[day].inerText = time + " " + title;
                childs[day].textContent = time + " " + title;
            }
        }
    }
};

function dayEnter(ev) {
    var childs = ev.target.parentElement.childNodes;
    for (var index = 0, length = childs.length; index < length; index++) {
        if (childs[index].className.indexOf("header") > -1 && childs[index].id !== "clicked") {
            childs[index].style.backgroundColor = "#999";
        }
    }
};

function dayLeave(ev) {
    var childs = ev.target.parentElement.childNodes;
    for (var index = 0, length = childs.length; index < length; index++) {
        if (childs[index].className.indexOf("header") > -1 && childs[index].id !== "clicked") {
            childs[index].style.backgroundColor = "#ccc";
        }
    }
};

function dayClick(ev) {
    var oldElement = document.getElementById("clicked");
    if (oldElement !== null) {
        oldElement.style.backgroundColor = "#ccc";
        oldElement.id = "";
    }

    var childs = ev.target.parentElement.childNodes;
    for (var index = 0, length = childs.length; index < length; index++) {
        if (childs[index].className.indexOf("header") > -1) {
            childs[index].style.backgroundColor = "#fff";
            childs[index].id = "clicked";
        }
    }
}
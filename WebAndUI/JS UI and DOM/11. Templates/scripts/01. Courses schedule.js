/// <reference path="handlebars-v1.3.0.js" />

var lectures = [
    {
        title: 'Course itroduction',
        date: {
            evening: 'Wed 18:00, 28-May-2014',
            morning: 'Thu 14:00, 29-May-2014'
        }
    },
    {
        title: 'Document Object Model',
        date: {
            evening: 'Wed 18:00, 28-May-2014',
            morning: 'Thu 14:00, 29-May-2014'
        }
    },
    {
        title: 'HTML5 Canvas',
        date: {
            evening: 'Thu 18:00, 29-May-2014',
            morning: 'Fri 14:00, 30-May-2014'
        }
    },
    {
        title: 'Kinect JS Overview',
        date: {
            evening: 'Thu 18:00, 29-May-2014',
            morning: 'Fri 14:00, 30-May-2014'
        }
    },
    {
        title: 'SVG and RaphaelJS',
        date: {
            evening: 'Wed 18:00, 04-Jun-2014',
            morning: 'Thu 14:00, 05-Jun-2014'
        }
    },
    {
        title: 'Animations with Canvas and SVG',
        date: {
            evening: 'Wed 18:00, 04-Jun-2014',
            morning: 'Thu 14:00, 05-Jun-2014'
        }
    },
    {
        title: 'DOM operations',
        date: {
            evening: 'Thu 18:00, 05-Jun-2014',
            morning: 'Fri 14:00, 06-Jun-2014'
        }
    },
    {
        title: 'Event model',
        date: {
            evening: 'Thu 18:00, 05-Jun-2014',
            morning: 'Fri 14:00, 06-Jun-2014'
        }
    },
    {
        title: 'jQuery overview',
        date: {
            evening: 'Wed 18:00, 11-Jun-2014',
            morning: 'Thu 14:00, 12-Jun-2014'
        }
    },
    {
        title: 'HTML templates',
        date: {
            evening: 'Wed 18:00, 11-Jun-2014',
            morning: 'Thu 14:00, 12-Jun-2014'
        }
    },
    {
        title: 'Exam preparation',
        date: {
            evening: 'Thu 18:00, 12-Jun-2014',
            morning: 'Fri 14:00, 13-Jun-2014'
        }
    },
    {
        title: 'Exam',
        date: {
            evening: 'Tue 16:30, 17-Jun-2014',
            morning: 'Thu 10:00, 17-Jun-2014'
        }
    },
    {
        title: 'Teamwork Defense',
        date: {
            evening: 'Thu 10:00, 19-Jun-2014',
            morning: 'Thu 10:00, 19-Jun-2014'
        }
    },
];

var courseTemplate = Handlebars.compile(document.getElementById('JS-UI-DOM-schedule').innerHTML);
document.getElementById('root').innerHTML = courseTemplate({
    lectures: lectures
});
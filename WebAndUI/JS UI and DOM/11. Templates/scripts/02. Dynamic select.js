/// <reference path="handlebars-v1.3.0.js" />

var values = [
    {
        value: '1',
        description: 'One'
    },

    {
        value: '2',
        description: 'Two'
    },
    {
        value: '3',
        description: 'Three'
    },
    {
        value: '4',
        description: 'Four'
    },
];

var selectHTML = selectTemplate(values);
document.getElementById('root').innerHTML = selectHTML;

function selectTemplate(values) {
    var selectTemplate = Handlebars.compile(document.getElementById('dynamic-select').innerHTML);

    return selectTemplate({ values: values });
}
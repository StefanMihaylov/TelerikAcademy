window.onload = function () {
    var list = [{
        value: 1,
        text: 'One'
    }, {
        value: 2,
        text: 'Two'
    }, {
        value: 3,
        text: 'Three'
    }, {
        value: 4,
        text: 'Four'
    }, {
        value: 5,
        text: 'Five'
    }, {
        value: 6,
        text: 'Six'
    }, {
        value: 7,
        text: 'Seven'
    }, {
        value: 8,
        text: 'Eight'
    }, {
        value: 9,
        text: 'Nine'
    }];

    var dropdownTemplatehtml = document.getElementById('dropdown-template').innerHTML;
    var dropdownTemplate = Handlebars.compile(dropdownTemplatehtml);
    document.getElementById('wrapper').innerHTML = dropdownTemplate({
        list: list
    });
}
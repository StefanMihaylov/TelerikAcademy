window.onload = function () {
    var table = [{
        title: "Course introduction",
        firstDate: DateToString(new Date(2014, 05, 28, 18, 00)),
        secondDate: DateToString(new Date(2014, 05, 29, 14, 00))
    }, {
        title: "Document Object Model",
        firstDate: DateToString(new Date(2014, 05, 28, 18, 00)),
        secondDate: DateToString(new Date(2014, 05, 29, 14, 00))
    }, {
        title: "HTML Canvas",
        firstDate: DateToString(new Date(2014, 05, 29, 18, 00)),
        secondDate: DateToString(new Date(2014, 05, 30, 14, 00))
    }, {
        title: "Kinetic JS Overview",
        firstDate: DateToString(new Date(2014, 05, 29, 18, 00)),
        secondDate: DateToString(new Date(2014, 05, 30, 14, 00))
    }, {
        title: "SVG and RafaelJS",
        firstDate: DateToString(new Date(2014, 05, 04, 18, 00)),
        secondDate: DateToString(new Date(2014, 05, 05, 14, 00))
    }, {
        title: "Animations with Canvas and SVG",
        firstDate: DateToString(new Date(2014, 05, 04, 18, 00)),
        secondDate: DateToString(new Date(2014, 05, 05, 14, 00))
    }, {
        title: "DOM operations",
        firstDate: DateToString(new Date(2014, 05, 05, 18, 00)),
        secondDate: DateToString(new Date(2014, 05, 06, 14, 00))
    }, {
        title: "Event model",
        firstDate: DateToString(new Date(2014, 05, 05, 18, 00)),
        secondDate: DateToString(new Date(2014, 05, 06, 14, 00))
    }, {
        title: "jQuery overview",
        firstDate: DateToString(new Date(2014, 05, 11, 18, 00)),
        secondDate: DateToString(new Date(2014, 05, 12, 14, 00))
    }, {
        title: "HTML Templates",
        firstDate: DateToString(new Date(2014, 05, 11, 18, 00)),
        secondDate: DateToString(new Date(2014, 05, 12, 14, 00))
    }, {
        title: "Exam preparation",
        firstDate: DateToString(new Date(2014, 05, 12, 18, 00)),
        secondDate: DateToString(new Date(2014, 05, 13, 14, 00))
    }, {
        title: "Exam",
        firstDate: DateToString(new Date(2014, 05, 17, 10, 00)),
        secondDate: DateToString(new Date(2014, 05, 17, 16, 30))
    }, {
        title: "Teamwork Defense",
        firstDate: DateToString(new Date(2014, 05, 19, 10, 00)),
        secondDate: DateToString(new Date(2014, 05, 19, 10, 00))
    }];

    var tableTemplateHtml = document.getElementById('table-template').innerHTML;
    var tableTemplate = Handlebars.compile(tableTemplateHtml);
    document.getElementById('wrapper').innerHTML = tableTemplate({
        table: table
    });

    function DateToString(date) {
        var daysOfWeek = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
        var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

        return daysOfWeek[date.getDay()] + ' ' + padString(date.getHours()) + ':' + padString(date.getMinutes()) + ', ' +
           padString(date.getDate()) + '-' + months[date.getMonth()] + '-' + date.getFullYear();
    }

    function padString(number) {
        return (number < 10) ? "0" + number : "" + number;
    }
}
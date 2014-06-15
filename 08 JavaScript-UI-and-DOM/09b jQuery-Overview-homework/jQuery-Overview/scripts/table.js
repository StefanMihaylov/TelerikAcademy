$(document).ready(function () {
    var students = [{
        firstName: 'Peter',
        lastName: 'Ivanov',
        grade: 3
    }, {
        firstName: 'Milena',
        lastName: 'Grigorova',
        grade: 6
    }, {
        firstName: 'Gergana',
        lastName: 'Borisova',
        grade: 12
    }, {
        firstName: 'Boyko',
        lastName: 'Petrov',
        grade: 7
    }];

    var $tableHeader = $('<thead>').append($('<tr>')
            .append($('<th>').text('First name'))
            .append($('<th>').text('Last name'))
            .append($('<th>').text('Grade name')));

    var $tablebody = $('<tbody>');
    for (var i = 0; i < students.length; i++) {
        $('<tr>').append($('<td>').text(students[i].firstName))
            .append($('<td>').text(students[i].lastName))
            .append($('<td>').text(students[i].grade))
            .appendTo($tablebody);
    }

    $('<table>').append($tableHeader).append($tablebody).appendTo($('#wrapper'));

});
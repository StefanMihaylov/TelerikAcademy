/// <reference path="Libs/underscore-min.js" />
var Person = (function () {
    function Person(fname, lname, marks) {
        this.fname = fname;
        this.lname = lname;
        this.marks = marks;
    }

    Person.prototype.getFullName = function () {
        return this.fname + ' ' + this.lname;
    };

    return Person;
}());

var students = [
    new Person('Doncho', 'Minkov', [4, 5, 6, 6]),
    new Person('Nikolay', 'Kostov', [6, 6, 5, 6]),
    new Person('Aneliya', 'Stoyanova', [4, 3, 4, 5]),
    new Person('Ivaylo', 'Kenov', [5, 5, 6, 6]),
    new Person('Todor', 'Stoyanov', [4, 5, 5, 6])
];

function selectStudents(students) {
    return _.chain(students)
            .sortBy(function (student) {
                var sum = 0;
                var marks = student.marks;
                var len = marks.length;
                for (var i = 0; i < len; i++) {
                    sum += marks[i]
                }
                return sum/len;
            })
            .last()
            .value();
}

var selectedStudents = selectStudents(students);
console.log(selectedStudents);
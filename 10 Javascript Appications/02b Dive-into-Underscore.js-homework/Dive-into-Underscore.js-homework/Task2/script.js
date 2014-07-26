/// <reference path="Libs/underscore-min.js" />
var Person = (function () {
    function Person(fname, lname, age) {
        this.fname = fname;
        this.lname = lname;
        this.age = age;
    }

    Person.prototype.getFullName = function () {
        return this.fname + ' ' + this.lname;
    };

    return Person;
}());

var students = [
    new Person('Doncho', 'Minkov', 25),
    new Person('Nikolay', 'Kostov', 26),
    new Person('Aneliya', 'Stoyanova', 18),
    new Person('Ivaylo', 'Kenov', 25),
    new Person('Todor', 'Stoyanov', 20)
];

function selectStudents(students) {
    return _.filter(students, function (student) {
        return 18 <= student.age && student.age <= 24
    });
}

function print(students) {
    _.each(students, function (person) {
        console.log(person.getFullName() + ' - ' + person.age);
    });
}

var selectedStudents = selectStudents(students);
print(selectedStudents);
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
    return  _.chain(students)
             .filter(function (person) {
                 return person.fname.localeCompare(person.lname) === -1;
             })
             .sortBy(function (person) {
                 return person.getFullName();
             })
            .value()
            .reverse();
}

function print (students) {
    _.each(students, function (person) {
        console.log(person.getFullName());
    });
}

var selectedStudents = selectStudents(students);
print(selectedStudents);

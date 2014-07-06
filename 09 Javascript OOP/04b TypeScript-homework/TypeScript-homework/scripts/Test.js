// Малки експерименти със Typescript. Не са изпълнени всички условия на задачата, защото тя е със звездичка.
(function () {
    var doncho = new Academy.Person('Doncho', 'Minkov', 1989);
    var jsoop = new Academy.Course('JS OOP', doncho);

    var student = new Academy.Student('Peter', 'Petrov', 1990, 12345);
    console.log(student.walk());
    student.addCourse(jsoop);

    student.getCourses().forEach(function (item) {
        console.log(item);
    });
}());
//# sourceMappingURL=Test.js.map

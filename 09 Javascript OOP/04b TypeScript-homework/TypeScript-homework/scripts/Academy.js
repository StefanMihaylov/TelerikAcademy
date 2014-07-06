var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Academy;
(function (Academy) {
    var Person = (function () {
        function Person(firstName, lastName, birthDate) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }
        Object.defineProperty(Person.prototype, "firstName", {
            get: function () {
                return this._firstName;
            },
            set: function (name) {
                if (name === null) {
                    throw { message: 'Invalid first name' };
                }

                this._firstName = name;
            },
            enumerable: true,
            configurable: true
        });


        Object.defineProperty(Person.prototype, "lastName", {
            get: function () {
                return this._lastName;
            },
            set: function (name) {
                if (name === null) {
                    throw { message: 'Invalid last name' };
                }

                this._lastName = name;
            },
            enumerable: true,
            configurable: true
        });


        Object.defineProperty(Person.prototype, "birthDate", {
            get: function () {
                return this._birthDate;
            },
            set: function (date) {
                if (date < 1900 && date > 2014) {
                    throw { message: 'Enter your birth date year only' };
                }

                this._birthDate = date;
            },
            enumerable: true,
            configurable: true
        });


        Person.prototype.walk = function () {
            return this.firstName + ' ' + this.lastName + ' is walking...';
        };
        return Person;
    })();
    Academy.Person = Person;

    var Course = (function () {
        function Course(name, Teacher) {
            this.name = name;
            this.Teacher = Teacher;
        }
        return Course;
    })();
    Academy.Course = Course;

    var Student = (function (_super) {
        __extends(Student, _super);
        function Student(firstName, lastName, birthDate, ID) {
            _super.call(this, firstName, lastName, birthDate);
            this._id = ID;
            this._courses = [];
        }
        Object.defineProperty(Student.prototype, "ID", {
            get: function () {
                return this._id;
            },
            enumerable: true,
            configurable: true
        });

        Student.prototype.addCourse = function (course) {
            if (course === null) {
                throw { message: 'Course cannot be null' };
            }

            this._courses.push(course);
        };

        Student.prototype.getCourses = function () {
            return this._courses.slice(0);
        };
        return Student;
    })(Person);
    Academy.Student = Student;
})(Academy || (Academy = {}));
//# sourceMappingURL=Academy.js.map

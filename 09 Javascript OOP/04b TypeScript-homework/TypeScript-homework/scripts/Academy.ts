module Academy {
    export class Person implements IMove {

        private _firstName: string;
        private _lastName: string;
        private _birthDate: number;

        constructor(firstName: string, lastName: string, birthDate: number) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }

        get firstName() {
            return this._firstName;
        }

        set firstName(name: string) {
            if (name === null) {
            throw { message: 'Invalid first name' }
        }

            this._firstName = name;
        }

        get lastName() {
            return this._lastName;
        }

        set lastName(name: string) {
            if (name === null) {
            throw { message: 'Invalid last name' }
        }

            this._lastName = name;
        }

        get birthDate() {
            return this._birthDate;
        }

        set birthDate(date: number) {
            if (date < 1900 && date > 2014) {
            throw { message: 'Enter your birth date year only' }
        }

            this._birthDate = date;
        }

        public walk(): string {
            return this.firstName + ' ' + this.lastName + ' is walking...';
        }
    }

    export class Course {

        constructor(public name: string, public Teacher: Person) {
        }
    }

    export class Student extends Person {
        private _id: number;
        private _courses: Course[];

        constructor(firstName: string, lastName: string, birthDate: number, ID: number) {
            super(firstName, lastName, birthDate);
            this._id = ID;
            this._courses = [];
        }

        get ID() {
            return this._id;
        }

        addCourse(course: Course): void {
            if (course === null) {
            throw { message: 'Course cannot be null' }
        }

            this._courses.push(course);
        }

        getCourses(): Course[] {
            return this._courses.slice(0);
        }
    }
} 
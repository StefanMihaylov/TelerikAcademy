var people = [
    { fname: 'Ivan', lname: 'Petrov' },
    { fname: 'Ivan', lname: 'Vasilev' },
    { fname: 'Vasil', lname: 'Mihaylov' },
    { fname: 'Peter', lname: 'Ivanov' },
    { fname: 'Stanislav', lname: 'Kostov' },
    { fname: 'Borislav', lname: 'Vasilev' },
];

function popularName(array, type) {
    var names = _.chain(array).countBy(type).value();
    var count = _.max(names);
    var invertedArray = _.invert(names);
    return invertedArray[count];
}

console.log('The most popular first name is ' + popularName(people, 'fname'));
console.log('The most popular family name is ' + popularName(people, 'lname'));
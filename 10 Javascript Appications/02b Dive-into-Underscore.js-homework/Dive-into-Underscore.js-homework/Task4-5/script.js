var animals = [
  { name: 'dog', species: 'mamal', legs: 4 },
  { name: 'mouse', species: 'mamal', legs: 4 },
    { name: 'centipede', species: 'insect', legs: 100 },
  { name: 'mosquito', species: 'insect', legs: 6 },
  { name: 'spider', species: 'insect', legs: 8 },
  { name: 'chicken', species: 'bird', legs: 2 },
  { name: 'stork', species: 'bird', legs: 2 }
];

function groupAnimals(animals) {
    return _.chain(animals)
            .sortBy('legs')
            .groupBy('species')
            .value();
}

function totalNumberOfLegs(array) {
    return _.reduce(array, function (memo, animal) { return memo + animal.legs; }, 0);
}

console.log(groupAnimals(animals));
console.log('Total number of legs ' + totalNumberOfLegs(animals));
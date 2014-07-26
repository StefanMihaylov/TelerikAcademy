var autors = [
    { autor: 'J. R. R. Tolkien', title: 'The Hobbit' },
    { autor: 'J. R. R. Tolkien', title: 'The Lord of the Rings' },
    { autor: 'I. Vazov', title: 'Под игото' },
    { autor: 'I. Vazov', title: 'Немили-недраги' },
    { autor: 'D. Talev', title: 'Железният светилник' },
    { autor: 'D. Talev', title: 'Преспанските камбани' },
    { autor: 'D. Talev', title: 'Гласовете ви чувам' },
    { autor: 'D. Talev', title: 'Илинден' }
];

function popularAutor(array) {
    var autors = _.chain(array).countBy('autor').value();
    var maxBooks = _.max(autors);
    var invertedAutors = _.invert(autors);
    return invertedAutors[maxBooks];
}

console.log('The most popular author: ' + popularAutor(autors)); 
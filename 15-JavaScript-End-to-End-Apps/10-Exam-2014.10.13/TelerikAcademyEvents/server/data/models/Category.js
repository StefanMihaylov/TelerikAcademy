'use strict';
var mongoose = require('mongoose');

var categorySchema = mongoose.Schema({
    name: { type: String, require: '{PATH} is required', unique: true}
});

var Category = mongoose.model('Category', categorySchema);

module.exports.seedInitialData = function () {

    Category.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find categories: ' + err);
            return;
        }

        if (collection.length === 0) {
            Category.create({name: 'Academy initiative'});
            Category.create({name: 'Free time'});
            Category.create({name: 'Sport'});
            Category.create({name: 'Lunch'});
            Category.create({name: 'Dinner'});
            Category.create({name: 'Bar'});
            Category.create({name: 'Hut'});

            console.log('Categories added to database...');
        }
    });
};

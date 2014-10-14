'use strict';
var memoize = require('memoizee'),
    Category = require('mongoose').model('Category'),
    Initiative = require('mongoose').model('Initiative'),
    Season = require('mongoose').model('Season');

var categories;
var initiatives;
var seasons;

module.exports = {
    categories: function(){
        if (categories) {
            return categories;
        }
        else {
            Category.find({})
                .exec(function (err, collection) {
                    if (err) {
                        console.log('Categories could not be loaded: ' + err);
                    }
                    else {
                        categories = collection;
                    }
                });
        }
    },
    initiative: function(){
        if (initiatives) {
            return initiatives;
        }
        else {
            Initiative.find({})
                .exec(function (err, collection) {
                    if (err) {
                        console.log('initiatives could not be loaded: ' + err);
                    }
                    else {
                        initiatives = collection;
                    }
                });
        }
    },
    seasons: function(){
        if (seasons) {
            return seasons;
        }
        else {
            Season.find({})
                .exec(function (err, collection) {
                    if (err) {
                        console.log('Seasons could not be loaded: ' + err);
                    }
                    else {
                        seasons = collection;
                    }
                });
        }
    }
};
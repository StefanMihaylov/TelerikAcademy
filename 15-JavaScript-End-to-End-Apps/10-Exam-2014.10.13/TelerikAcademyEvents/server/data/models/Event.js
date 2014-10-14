'use strict';
var mongoose = require('mongoose');

var eventSchema = mongoose.Schema({
    title: { type: String, require: '{PATH} is required'},
    description: { type: String, require: '{PATH} is required' },
    category: {type: String, require: '{PATH} is required' },
    typeInitiative: {type: String, require: '{PATH} is required' },
    typeSeason : {type: String},
    creatorName: {type: String},
    creatorPhone: {type: String},
    locationLatitude: {type: Number},
    locationLongitude: {type: Number},
    date: {type: Date},
    organizationPoints: { type: Number, default: 0},
    venuePoints: { type: Number, default: 0},
    comments: [{type: String}],
    users: [{type: String}]
});

var Event = mongoose.model('Event', eventSchema);

module.exports.seedInitialData = function () {

    Event.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find events: ' + err);
            return;
        }

        if (collection.length === 0) {
            var today = new Date();
            var year = today.getFullYear();
            var month = today.getMonth();
            var day = today.getDate();
            var hour = today.getHours();
            var minutes = today.getMinutes();


            var eventDate = new Date(year, month, day + 3, hour, minutes, 0);

            Event.create({title: 'Football match', description: 'Football', locationLatitude: 42.678154, locationLongitude: 23.390036, category: 'Sport', creatorName: 'Administrator', creatorPhone: '0888999777666', date: eventDate });
            Event.create({title: 'Drinking', description: 'Drinking beer, vodka and rakia', locationLatitude: 42.678154, locationLongitude: 23.390036, category: 'Bar', creatorName: 'VasilVasilev', date: eventDate});
            Event.create({title: 'Trekking', description: 'Walking in Vitosha', locationLatitude: 42.678154, locationLongitude: 23.390036, category: 'Hut', creatorName: 'StefanStefanov', date: eventDate});

            for (var i = 0; i < 15; i += 1) {
                var newHour = hour + i;
                if (newHour > 23) {
                    newHour -= 23;
                }
                eventDate = new Date(year, month, day + 3, newHour, minutes, 0);
                var passedDate = new Date(year, month, day - 3, newHour, minutes, 0);

                Event.create({title: 'Passed #' + i, description: 'Passed Desc #' + i, locationLatitude: 42.678154, locationLongitude: 23.390036, category: 'Bar', creatorName: 'VasilVasilev', date: passedDate});
                Event.create({title: 'Event #' + i, description: 'Event Desc #' + i, locationLatitude: 42.678154, locationLongitude: 23.390036, category: 'Hut', creatorName: 'StefanStefanov', date: eventDate});
            }

            console.log('Events added to database...');
        }
    });
};

'use strict';
var events = require('../data/eventsData'),
    common = require('../data/commonData');

var controller_Name = 'events';
var create_Route = '/create';
var active_Route = '/active';
var past_Route = '/past';
var details_Route = '/details';

var createView = controller_Name + create_Route;
var activeView = controller_Name + active_Route;
var pastView = controller_Name + past_Route;
var detailsView = controller_Name + details_Route;

var DEFAULT_PAGE_SIZE = 10;
var page = 1;

var allEvents;

module.exports = {
    getCreate: function (req, res) {
        var categories = common.categories();
        var initiatives = common.initiative();
        var seasons = common.seasons();
        res.render(createView, {categories: categories, seasons: seasons, initiatives: initiatives});
    },
    postCreate: function (req, res) {
        var user = req.user;
        if (!user.phoneNumber) {
            req.session.error = 'You have to fill your phone number to create a event';
            res.redirect('/profile');
        }
        else {
            var newEvent = req.body;
            newEvent.creatorName = user.username;
            newEvent.creatorPhone = user.phoneNumber;

            events.add(newEvent, function (err, data) {
                if (err) {
                    console.log('Can not add new Event: ' + err);
                }
                else {
                    res.redirect(active_Route);
                }
            });
        }
    },
    getActive: function (req, res) {
        var currentDate = new Date();
        var query = events.getAll({ "date": { $gt: currentDate}})
            .sort('date')
            .skip((page - 1) * DEFAULT_PAGE_SIZE)
            .limit(DEFAULT_PAGE_SIZE)
            .exec(function (err, collection) {
                if (err) {
                    req.session.error = 'Photos could not be loaded: ' + err;
                }
                else {
                    allEvents = collection;
                    res.render(activeView, { allEvents: allEvents});
                }
            });
    },
    getPast: function (req, res) {
        var currentDate = new Date();
        var query = events.getAll({ "date": { $lt: currentDate}})
            .sort('-date')
            .skip((page - 1) * DEFAULT_PAGE_SIZE)
            .limit(DEFAULT_PAGE_SIZE)
            .exec(function (err, collection) {
                if (err) {
                    req.session.error = 'Photos could not be loaded: ' + err;
                }
                else {
                    allEvents = collection;
                    res.render(pastView, { allEvents: allEvents});
                }
            });
    },
    changePage: function (req, res) {
        page = req.body.page;
        res.redirect(active_Route);
    },
    getById: function (req, res) {
        events.getAll({_id: req.params.id})
            .exec(function (err, currentEvent) {
                if (err) {
                    req.session.error = 'Event by ID could not be loaded: ' + err;
                }
                else {
                    res.render(detailsView, { event: currentEvent[0]});
                }
            });
    },
    postById: function (req, res) {
        var data = req.body;
        if ((data.hasOwnProperty('join') && data.join) && (data.hasOwnProperty('leave') && data.leave)) {
            req.session.error = 'You cannot join and leave the event at the same time';
            res.redirect(details_Route);
        }
        else {
            events.findOne({_id: req.params.id})
                .exec(function (err, currentEvent) {
                    if (err) {
                        req.session.error = 'Event by ID could not be loaded: ' + err;
                    }
                    else {
                        var user = req.user;
                        var index;
                        var currentDate = new Date();
                        var pastEvent = currentEvent.date < currentDate;

                        if(!pastEvent){
                            //join
                            if (data.hasOwnProperty('join') && data.join) {
                                index = currentEvent.users.indexOf(user.username);
                                if (index < 0 && isAllowedToJoin(user, currentEvent)) {
                                    currentEvent.users.push(user.username);
                                }
                            }

                            //leave
                            if (data.hasOwnProperty('leave') && data.leave) {
                                index = currentEvent.users.indexOf(user.username);
                                if (index >= 0) {
                                    currentEvent.users.splice(index, 1);

                                    console.log(currentEvent.users)
                                }
                            }
                            // comments
                            index = currentEvent.users.indexOf(user.username);
                            if (index >= 0 && data.comment) {
                                currentEvent.comments.push(data.comment);
                            }
                        }
                        else{
                            index = currentEvent.users.indexOf(user.username);
                            if(index >=0){
                                if(data.organizationPoints){
                                    var orgPoints = parseInt(data.organizationPoints);
                                    currentEvent.organizationPoints += orgPoints;
                                }

                                if(data.venuePoints){
                                    var venPoints = parseInt(data.venuePoints);
                                    currentEvent.venuePoints += venPoints;
                                }
                            }
                        }

                        currentEvent.save();

                        res.redirect(details_Route + '/' + req.params.id);
                    }
                });
        }
    }
};

function isAllowedToJoin(user, event) {
    var index;
    var userInitiatives = user.initiatives;
    var userSeasons = user.seasons;
    var eventInitiative = event.typeInitiative;
    var eventSeason = event.typeSeason;

    if (!eventInitiative && !eventSeason) {
        return true;
    }
    else if (eventInitiative && !eventSeason) {
        index = userInitiatives.indexOf(eventInitiative);
        return index >= 0
    }
    else if (!eventInitiative && eventSeason) {
        index = userSeasons.indexOf(eventSeason);
        return index >= 0
    }
    else {
        var indexInitiative = userInitiatives.indexOf(eventInitiative);
        var indexSeasons = userSeasons.indexOf(eventSeason);
        return ((indexInitiative >= 0) && (indexSeasons >= 0))
    }

}

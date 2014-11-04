'use strict';

app.factory('identity', ['$cookieStore', 'cookieStorageUserKey',
    function($cookieStore, cookieStorageUserKey) {

    var currentUser;

    return {
        getCurrentUser: function() {
            var savedUser = $cookieStore.get(cookieStorageUserKey);
            if (savedUser) {
                return savedUser;
            }

            return currentUser;
        },

        setCurrentUser: function(user) {
            if (user) {
                $cookieStore.put(cookieStorageUserKey, user);
            }
            else {
                $cookieStore.remove(cookieStorageUserKey);
            }

            currentUser = user;
        },

        isAuthenticated: function() {
            return !!this.getCurrentUser();
        }
    }
}]);
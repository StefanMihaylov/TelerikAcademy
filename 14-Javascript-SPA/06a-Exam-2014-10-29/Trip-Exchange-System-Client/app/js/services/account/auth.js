'use strict';

app.factory('auth', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl', 'registerUrl', 'loginUrl', 'logoutUrl',
    function ($http, $q, identity, authorization, baseServiceUrl, registerUrl, loginUrl, logoutUrl) {

        return {
            register: function (user) {
                var deferred = $q.defer();

                $http.post(baseServiceUrl + registerUrl, user)
                    .success(function () {
                        deferred.resolve();
                    })
                    .error(function (response) {
                        deferred.reject(response);
                    });

                return deferred.promise;
            },

            login: function (user) {
                var deferred = $q.defer();
                user['grant_type'] = 'password';
                $http.post(baseServiceUrl + loginUrl,
                        'username=' + user.username + '&password=' + user.password + '&grant_type=password',
                    { headers: {'Content-Type': 'application/x-www-form-urlencoded'} })
                    .success(function (response) {
                        if (response["access_token"]) {
                            identity.setCurrentUser(response);
                                   deferred.resolve(true);
                        }
                        else {
                            deferred.resolve(false);
                        }
                    })
                    .error(function (response) {
                        deferred.reject(response);
                    });

                return deferred.promise;
            },

            logout: function () {
                var deferred = $q.defer();

                var headers = authorization.getAuthorizationHeader();
                $http.post(baseServiceUrl + logoutUrl, {}, { headers: headers })
                    .success(function () {
                        identity.setCurrentUser(undefined);
                        deferred.resolve();
                    });

                return deferred.promise;
            },

            isAuthenticated: function () {
                if (identity.isAuthenticated()) {
                    return true;
                }
                else {
                    return $q.reject('not authorized');
                }
            }
        }
    }]);
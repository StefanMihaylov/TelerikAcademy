'use strict';

app.factory('tripData', ['$http', '$q', 'baseServiceUrl', 'authorization',
    function ($http, $q, baseServiceUrl, authorization) {

        var servicePath = 'api/trips';

        function getRequest(path) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.get(baseServiceUrl + servicePath + path, { headers: headers })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }

        function putRequest(path) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.put(baseServiceUrl + servicePath + path,{} ,{ headers: headers })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }

        function postRequest(path, inputData) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.post(baseServiceUrl + servicePath + path, inputData ,{ headers: headers })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }

        return{
            get: function () {
                return getRequest('');
            },

            getById: function (id) {
                return getRequest('/' + id);
            },

            getByParams: function (page, isFinished, isMine, sortBy, orderBy, from, to) {
                var query = [];
                if (page) {
                    query.push('page=' + page);
                }

                if (isFinished) {
                    query.push('finished=true');
                }

                if (isMine) {
                    query.push('onlyMine=true');
                }

                if (sortBy) {
                    query.push('orderBy=' + sortBy + '&orderType=' + orderBy);
                }

                if (from) {
                    query.push('from=' + from);
                }

                if (to) {
                    query.push('to=' + to);
                }

                return getRequest('?' + query.join('&'));
            },

            join: function (id) {
                return putRequest('/' + id);
            },

            create: function (data) {
                return postRequest('', data);
            }
        }

    }]);
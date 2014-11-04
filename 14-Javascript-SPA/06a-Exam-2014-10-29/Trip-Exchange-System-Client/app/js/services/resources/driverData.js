'use strict';

app.factory('driverData', ['$http', '$q', 'baseServiceUrl', 'authorization',
    function ($http, $q, baseServiceUrl, authorization) {

        var servicePath = 'api/drivers';

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

        return{

            get: function (page, name) {

                if (!page && !name) {
                    return getRequest('');
                }
                else if (page && !name) {
                    return getRequest('?page=' + page);
                }
                else if (!page && name) {
                    return getRequest('?username=' + name);
                }
                else if (page && name) {
                    return getRequest('?page=' + page + '&username=' + name);
                }
            },

            getByTd: function(id){
                return getRequest('/' + id);
            }
        }

    }]);

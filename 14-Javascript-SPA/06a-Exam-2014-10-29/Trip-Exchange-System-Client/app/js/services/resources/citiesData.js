'use strict';

app.factory('citiesData', ['$http', '$q', 'baseServiceUrl',
    function ($http, $q, baseServiceUrl) {

        function getRequest(path) {
            var deferred = $q.defer();

            $http.get(baseServiceUrl + path)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }

        return{
            get: function(){
                return getRequest('/api/cities');
            }
        }

    }]);

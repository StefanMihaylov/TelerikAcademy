define(['jquery', 'Qlib'], function ($, Q) {
    var HttpRequester = (function () {
        var makeHttpRequest = function (url, type, data, sessionKey) {
            var deferred = Q.defer();

            var dataJSON = data ? JSON.stringify(data) : "";
            var header = { "X-SessionKey": (sessionKey || "") };
           
            $.ajax({
                url: url,
                type: type,
                data: dataJSON,
                contentType: "application/json",
                timeout: 5000,
                headers: header,
                success: function (resultData) {
                    deferred.resolve(resultData);
                },
                error: function (errorData) {
                    deferred.reject(errorData);
                }
            });

            return deferred.promise;
        };

        var getJSON = function (url) {
            return makeHttpRequest(url, "GET");
        };

        var postJSON = function (url, data, sessionKey) {
            return makeHttpRequest(url, "POST", data, sessionKey);
        };

        var putJSON = function (url, data, sessionKey) {
            return makeHttpRequest(url, "PUT", data, sessionKey);
        };

        return {
            getJSON: getJSON,
            postJSON: postJSON,
            putJSON: putJSON
        }
    }());

    return HttpRequester;
});
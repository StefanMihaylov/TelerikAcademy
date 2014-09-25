define(['jquery', 'Qlib'], function ($, Q) {
    var HttpRequester = (function () {
        function makeHttpRequest(url, type, data, token, content) {
            var deferred = Q.defer();

            var requestOptions = {
                url: url,
                type: type,
                //dataType: "application/x-www-form-urlencoded",
                data: data,
                beforeSend: function (xhr) {
                    if (token !== null) {
                        //xhr.withCredentials = true;
                        xhr.setRequestHeader("Authorization", "Bearer " + token);
                    }
                },
                success: function resolveDeferred(requestData) {
                    deferred.resolve(requestData);
                },
                error: function rejectDeferred(errorData) {
                    // deferred.reject(JSON.parse(errorData.responseText));
                    deferred.reject(errorData.responseText);
                }
            }

            if (content == null) {
                requestOptions.contentType = "application/json; charset=utf-8";
            }
            else {
                requestOptions.contentType = content;
            }

            $.ajax(requestOptions);

            return deferred.promise;
        }

        var getJSON = function (url, token) {
            return makeHttpRequest(url, "GET", '', token);
        };

        var postJSON = function (url, data, token, content) {
            return makeHttpRequest(url, "POST", data, token, content);
        };

        var register = function (url, data) {
            var deferred = Q.defer();

            var dataJSON = data ? JSON.stringify(data) : "";
            var dataString = 'Email=' + data.email + '&Password=' + data.password + '&ConfirmPassword=' + data.confirmpassword;
            //  var header = { "X-SessionKey": (sessionKey || "") };

            $.ajax({
                url: url,
                type: 'POST',
                data: dataString,
                cache: false,
                //dataType: "json",
                // contentType: "application/json",
                contentType: "application/x-www-form-urlencoded",
                timeout: 5000,
                //   headers: header,
                success: function (resultData) {
                    deferred.resolve(resultData);
                },
                error: function (errorData) {
                    deferred.reject(errorData);
                },
            });

            return deferred.promise;
        };

        var login = function (url, data) {
            var deferred = Q.defer();

            var dataJSON = data ? JSON.stringify(data) : "";
            var dataString = 'username=' + data.username + '&Password=' + data.password + '&grant_type=password';
            //  var header = { "X-SessionKey": (sessionKey || "") };

            $.ajax({
                url: url,
                type: 'POST',
                data: dataString,
                cache: false,
                //dataType: "json",
                // contentType: "application/json",
                contentType: "application/x-www-form-urlencoded",
                timeout: 5000,
                //   headers: header,
                success: function (resultData) {
                    deferred.resolve(resultData);
                },
                error: function (errorData) {
                    deferred.reject(errorData);
                },
            });

            return deferred.promise;
        };

        var putJSON = function (url, data, sessionKey) {
            return makeHttpRequest(url, "PUT", data, sessionKey);
        };

        return {
            getJSON: getJSON,
            postJSON: postJSON,
            putJSON: putJSON,
            register: register,
            login: login
        }
    }());

    return HttpRequester;
});

/*
$.ajax({
    url: rootUrl + 'api/Endpoint',
    type: "POST",
    beforeSend: function (xhr) { xhr.setRequestHeader('Authorization', 'bearer ' + auth.token()) },
    data: data,
    contentType: "application/x-www-form-urlencoded",
    success: function (data) {
        deferred.resolve(data);
    }
}); */
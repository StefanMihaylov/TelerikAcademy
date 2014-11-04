app.factory('notifier', ['toastr', function(toastr) {
    return {
        success: function(msg) {
            toastr.success(msg);
        },
        error: function(msg) {
            toastr.error(msg);
        },
        warning: function(msg) {
            toastr.warning(msg);
        },

        responseError: function(response){
            var errorMessage = parseError(response);
            this.error(errorMessage);
        }
    };

    function parseError(response) {
        var errors = [];
        if(response.hasOwnProperty('ModelState'))
        for (var key in response.ModelState) {
            for (var i = 0; i < response.ModelState[key].length; i++) {
                errors.push(response.ModelState[key][i]);
            }
        }
        else if(response.hasOwnProperty('error_description')){
            errors.push(response.error_description);
        }
        else if(response.hasOwnProperty('message')){
            errors.push(response.message);
        }
        return errors.join('; ');
    }
}]);
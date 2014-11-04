'use strict';

app.filter('dateFilter',function(){
    return function(input){
        var myDate = new Date(input); // Set this to your date in whichever timezone.
        var utcDate = myDate.toUTCString();
        return utcDate;
    };
});

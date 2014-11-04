'use strict';

app.filter('isMineState',function(){
    return function(input){
        if(input){
            return 'Yes';
        }
        else{
            return 'No';
        }
    };
});

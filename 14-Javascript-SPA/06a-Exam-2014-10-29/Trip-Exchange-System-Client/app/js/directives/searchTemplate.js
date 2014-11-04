'use strict';

app.directive('searchTemplate', function () {
    return{
        restrict: 'A',
        templateUrl: 'views/directives/search.html',
        scope: {
            search: '='
        },
        link: function ($scope, element, attrs) {
            attrs.$observe('searchTemplate', function (value) {
                element.find('input').attr('placeholder', value);
            });
        }
    }
});

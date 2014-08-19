/// <reference path="D:\Exam\CrowdUI\CrowdUI\libs/underscore-min.js" />
define(['underscore'], function (_) {

    var data = (function () {


        function parse(originalData) {
            var newData = _.map(originalData, function (element) {
                var date = new Date(element.postDate);
                var dateString = date.toUTCString();
                return {
                    date: dateString,
                    autor: element.user.username,
                    title: element.title,
                    content: element.body
                }
            });

            return newData;
        }

        function sortBy(collection, type) {
            var typeName = type.name;

            var sorterArray = _.sortBy(collection, function (element) {
                return element[typeName];
            });
            //console.log(type);
            // console.log(sorterArray);
            if (type.dir === '1') {
                return sorterArray.reverse();
            }
            else {
                return sorterArray
            }
        }

        function string_comparator(param_name, compare_depth) {
            if (param_name[0] == '-') {
                param_name = param_name.slice(1),
                compare_depth = compare_depth || 10;
                return function (item) {
                    return String.fromCharCode.apply(String,
                       _.map(item[param_name].slice(0, compare_depth).split(""), function (c) {
                           return 0xffff - c.charCodeAt();
                       })
                   );
                };
            } else {
                return function (item) {
                    return item[param_name];
                };
            }
        };


        function convert(originalData, sortOptions) {
            var newData = parse(originalData);
            newData = sortBy(newData, sortOptions);
            return newData;
        }

        return {
            convert: convert
        }

    }());

    return data;
});
(function () {
    require.config({
        paths: {
            'jquery': 'libs/jquery-2.0.3.min',
            'handlebars': 'libs/handlebars-v1.3.0',
        }
    });

    require(['combobox', 'data'], function (Combobox, data) {
        var combobox = Combobox('#combo-box-container');
        combobox.render('#combobox-template', data);        
    });
}());

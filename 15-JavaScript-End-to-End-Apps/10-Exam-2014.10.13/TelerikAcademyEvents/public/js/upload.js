$(document).ready(function () {
    $('#add-input-file').on('click', function () {
        var form = $('#form-upload').children('fieldset');
        var count = form.children('.form-group').length;

        var title = $('<label/>').addClass('col-md-2').addClass('control-label').text('File ' + (count + 1));

        var fileInput = $('<div/>').addClass('col-md-8');
        var inputTypeFile = $('<input />');
        inputTypeFile.attr('type', 'file');
        inputTypeFile.attr('name', 'file_' + count);
        inputTypeFile.addClass('form-control');
        fileInput.append(inputTypeFile);

        var privateBox = $('<div/>').addClass('col-md-2').addClass('checkbox');
        var label = $('<label/>').text('Private');
        var inputTypeCheckbox = $('<input />');
        inputTypeCheckbox.attr('type', 'checkbox');
        inputTypeCheckbox.attr('name', 'private_' + count);
        label.prepend(inputTypeCheckbox);
        privateBox.append(label);

        var newForm = $('<div/>').addClass('form-group');
        newForm.append(title);
        newForm.append(fileInput);
        newForm.append(privateBox);
        form.children('.form-group').last().after(newForm);
    });
});

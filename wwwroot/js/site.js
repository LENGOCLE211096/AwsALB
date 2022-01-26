// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function jQueryAjaxSubmit(form) {
    $.validator.unobtrusive.parse(form);
    var ajaxConfig = {
        type: 'POST',
        url: form.action,
        cache: false,
        async: true,
        data: new FormData(form),
        success: function (response) {
            alert(response);
        }
    }
    if ($(form).attr('enctype') == "multipart/form-data") {
        ajaxConfig["contentType"] = false;
        ajaxConfig["processData"] = false;
    }
    $.ajax(ajaxConfig);
    return false;
}
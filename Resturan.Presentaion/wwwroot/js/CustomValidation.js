// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
jQuery.validator.addMethod("MaxSizeFile",function(value, element, params) {
    if (element.files[0].size >= (3 * 1024 * 1024)) {
        return false;
    } else {
        return true;
    }
});
jQuery.validator.unobtrusive.adapters.addBool("MaxSizeFile");
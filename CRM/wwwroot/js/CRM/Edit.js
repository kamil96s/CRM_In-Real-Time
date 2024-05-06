$(document).ready(function () {

    LoadCRMServices()

    $('#createCRMServiceModal form').submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Created new condition")
                LoadCRMServices()
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        });
    });
});
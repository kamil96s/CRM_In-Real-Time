$(document).ready(function () {

    LoadLeadCalls()

    $('#createLeadCallModal form').submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("New note created")
                LoadLeadCalls()
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        });
    });
});
$(document).ready(function () {

    LoadLeadCalls()

    $('#deleteLeadCallModal form').submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["info"]("All notes deleted")
                LoadLeadCalls()
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        });
    });
});
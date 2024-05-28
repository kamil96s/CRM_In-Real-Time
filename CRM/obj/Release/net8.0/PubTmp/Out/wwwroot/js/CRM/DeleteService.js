$(document).ready(function () {

    LoadCRMServices()


    $('#deleteCRMServiceModal form').submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["info"]("All contact information deleted")
                LoadCRMServices()
            },

            error: function () {
                toastr["error"]("Something went wrong")
            }
        });
    });
});
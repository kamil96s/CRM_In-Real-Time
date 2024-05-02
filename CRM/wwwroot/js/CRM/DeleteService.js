$(document).ready(function () {

    LoadCRMServices()

    $('#deleteCRMServiceModal form').delete(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Usunieto")
                LoadCRMServices()
            },
            error: function () {
                toastr["error"]("Cos poszlo nie tak")
            }
        });
    });
});
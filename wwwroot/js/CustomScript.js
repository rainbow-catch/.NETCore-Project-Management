$('#termCheck').change(function () {
    if ($(this).prop('checked')) {
        $("#btnRegister").removeAttr('disabled');
    } else {
        $("#btnRegister").attr('disabled', 'disabled');
    }
});


$('#termModal').on('hide.bs.modal', function () {
    $('#termCheck').prop('checked', true);
    $('#termCheck').trigger('change');
})

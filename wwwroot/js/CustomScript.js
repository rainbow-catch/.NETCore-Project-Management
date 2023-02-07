function confirmDelete(uniqueId, isDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}

setTimeout(function () {
    $("#msg").fadeTo(2000, 500).slideUp(500, function () {
        $("#msg").remove();
    });
}, 2000);//5000=5 seconds


$('#Agree').click(function () {
    if ($("#btnRegister").is(':disabled')) {
        $("#btnRegister").removeAttr('disabled');
    } else {
        $("#btnRegister").attr('disabled', 'disabled');
    }
});

$('#toolTipId').popover({
    trigger: 'click'
});


function showToolTip() {
    var tt = document.getElementById("tooltipdemo");
    tt.classList.toggle("show");
}
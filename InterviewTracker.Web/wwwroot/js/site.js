var baseUrl = '/WebApi/';

function sendRequestGet(data, successMethod, handleResponse, url) {
    $.ajax({
        url: baseUrl + url,
        type: "GET",
        dataType: 'json',
        data: data,
        success: successMethod,
        error: function (xhr, textStatus, errorThrown) {
            alertMessage(false, xhr.responseText, true);
        }
    });
}


function sendRequestPost(data, successMethod, handleResponse, url) {
    $.ajax({
        url: baseUrl + url,
        type: "POST",
        dataType: 'json',
        data: data,
        success: successMethod,
        error: function (xhr, textStatus, errorThrown) {
            alertMessage(false, xhr.responseText, true);
        }
    });
}

function confirmationMessage(title, message, yesMethod) {
    $('#divConfirmationModal .modal-title').text(title);
    $('#divConfirmationModal .modal-text').text(message);
    $('#divConfirmationModal_yes').on('click', function () {
        eval(yesMethod);
        $('#divConfirmationModal').modal('hide');
    });
    $('#divConfirmationModal').modal('show');
}

$('#divConfirmationModal .confirmation-no').on('click', function () {
    $('#divConfirmationModal').modal('hide');
});

function alertMessage(isSuccess, message, dismiss) {
    if (isSuccess) {
        $('#divSuccessAlert').removeClass('d-none');
        $('#divSuccessAlert').text(message);
        if (dismiss) {
            setTimeout(function () {
                $('#divSuccessAlert').addClass('d-none');
            }, 3000);
        }
    } else {
        $('#divDangerAlert').removeClass('d-none');
        $('#divDangerAlert').text(message);
        if (dismiss) {
            setTimeout(function () {
                $('#divDangerAlert').addClass('d-none');
            }, 3000);
        }
    }
}

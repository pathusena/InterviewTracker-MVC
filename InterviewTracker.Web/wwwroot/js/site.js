var baseUrl = '/WebApi/';

function sendRequestGet(data, successMethod, handleResponse, url) {
    $.ajax({
        url: baseUrl + url,
        type: "GET",
        dataType: 'json',
        data: data,
        success: successMethod,
        error: function (request, status, error) {
            //alert(request.responseText);
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
        error: function (request, status, error) {
            //alert(request.responseText);
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
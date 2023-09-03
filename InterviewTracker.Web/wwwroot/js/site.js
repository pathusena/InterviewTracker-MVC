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
var baseUrl = '/WebApi/';

function SentRequestGet(data, successMethod, handleResponse, url) {
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
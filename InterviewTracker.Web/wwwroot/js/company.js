var companyList = [];
function getAllCompanies() {
    do_getAllCompanies();
}

function do_getAllCompanies() {
    sendRequestGet(null, do_getAllCompanies_success, null, 'GetAllCompanies');
}

function do_getAllCompanies_success(result) {
    if (result.result != null) {
        companyList = result.result;
        drawCompanyTable(companyList);
    }
}

function drawCompanyTable(list) {
    $('#tblCompanyBody').html('');
    list.forEach(function (company, index) {
        drawCompanyTableRow(company, index);
    });
}

function drawCompanyTableRow(obj, index) {
    let line = `<tr>
                    <td> ${index + 1}</td>
                    <td> ${obj.name}</td>
                    <td>${obj.country}</td>
                    <td>${obj.date.split('T')[0]}</td>
                    <td>${obj.phone}</td>
                    <td>${obj.description}</td>
                    <td>${obj.remarks}</td>
                    <td><a class="btn btn-success" onclick="editCompany(${obj.id})">Edit</a><a class="btn btn-info mx-2">View Interviews</a></td>
                </tr>`;
    $('#tblCompanyBody').append(line);
}

function editCompany(id) {
    clearCompanyEditModal();
    if (companyList.length > 0) {
        var index = companyList.findIndex(x => x.id == id);
        if (index > -1) {
            showCompanyValues(companyList[index]);
            $('#divEditCompany').modal('show');
        } else {

        }
    } else {

    }
}

function showCompanyValues(obj) {
    $('#hdnId').val(obj.id);
    $('#txtName').val(obj.name);
    $('#txtCountry').val(obj.country);
    $('#txtDate').val(obj.date.split('T')[0]);
    $('#txtPhone').val(obj.phone);
    $('#txtDescription').val(obj.description);
    $('#txtRemark').val(obj.remarks);
}

$('.btnEditCompanyClose').on('click', function () {
    clearCompanyEditModal();
    $('#divEditCompany').modal('hide');
});

$('#btnEditCompanySave').on('click', function () {
    saveCompany();
});

function saveCompany() {
    do_saveCompany(createCompanySaveObject());
}

function createCompanySaveObject() {
    var obj = {};
    obj.id = Number($('#hdnId').val());
    obj.name = $('#txtName').val();
    obj.date = $('#txtDate').val();
    obj.country = $('#txtCountry').val();
    obj.phone = $('#txtPhone').val();
    obj.description = $('#txtDescription').val();
    obj.remarks = $('#txtRemark').val();

    return obj;
}

function do_saveCompany(obj) {
    sendRequestPost(obj , do_saveCompany_sucess, null, 'SaveCompany');
}

function do_saveCompany_sucess(result) {
    if (result.result != null) {
        clearCompanyEditModal();
        $('#divEditCompany').modal('hide');
    }
}

function clearCompanyEditModal() {
    $('#hdnId').val('');
    $('#txtName').val('');
    $('#txtDate').val('');
    $('#txtCountry').val('');
    $('#txtPhone').val('');
    $('#txtDescription').val('');
    $('#txtRemark').val('');
}

$(document).ready(function () {
    getAllCompanies();
});


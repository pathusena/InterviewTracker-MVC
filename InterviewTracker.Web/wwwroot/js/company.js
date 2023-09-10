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
    let line = `<tr id="tr_${obj.id}">
                    <td> ${index + 1}</td>
                    <td> ${obj.name}</td>
                    <td>${obj.country}</td>
                    <td>${obj.date.split('T')[0]}</td>
                    <td>${obj.phone}</td>
                    <td>${obj.description}</td>
                    <td>${obj.remarks}</td>
                    <td><a class="btn btn-success" onclick="editCompany(${obj.id});">Edit</a><a class="btn btn-info mx-2">View Interviews</a><a class="btn btn-danger" onclick="deleteCompany(${obj.id});">Delete</a></td>
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
        }
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
        var index = companyList.findIndex(x => x.id == result.result.id);
        if (index > -1) {
            companyList[index] = result.result;
        } else {
            companyList.push(result.result);
        }
        drawCompanyTable(companyList);
    }
}

function clearCompanyEditModal() {
    $('#hdnId').val('-1');
    $('#txtName').val('');
    $('#txtDate').val('');
    $('#txtCountry').val('');
    $('#txtPhone').val('');
    $('#txtDescription').val('');
    $('#txtRemark').val('');
}

$('#btnAddCompany').on('click', function () {
    addCompany();
});

function addCompany() {
    clearCompanyEditModal();
    $('#divEditCompany').modal('show');
}

function deleteCompany(id) {
    do_deleteCompany(id);
}

function do_deleteCompany(id) {
    sendRequestGet({id: id}, do_deleteCompany_sucess, null, 'DeleteCompany');
}

function do_deleteCompany_sucess(result) {
    if (result.result != null) {
        var index = companyList.findIndex(x => x.id == result.result);
        if (index > -1) {
            companyList.splice(index, 1);
            drawCompanyTable(companyList);
        }
    }
}

$(document).ready(function () {
    getAllCompanies();
});


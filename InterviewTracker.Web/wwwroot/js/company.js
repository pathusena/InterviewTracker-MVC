var companyList = [];
function getAllCustomers() {
    do_getAllCustomers();
}

function do_getAllCustomers() {
    SentRequestGet(null, do_getAllCustomers_success, null, 'GetAllCompanies');
}

function do_getAllCustomers_success(result) {
    if (result.result != null) {
        companyList = result.result;
        drawCompanyTable(companyList);
    }
}

function drawCompanyTable(list) {
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
    $('#txtName').val(obj.name);
    $('#txtCountry').val(obj.country);
    $('#txtDate').val(obj.date.split('T')[0]);
    $('#txtPhone').val(obj.phone);
    $('#txtDescription').val(obj.description);
    $('#txtRemark').val(obj.remarks);
}

$('.btnEditCompanyClose').on('click', function () {
    $('#divEditCompany').modal('hide');
});

$(document).ready(function () {
    getAllCustomers();
});


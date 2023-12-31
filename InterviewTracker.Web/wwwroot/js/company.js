﻿var companyList = [];
var selectedCompanyId = -1;
var selectedCompanyInterviewList = [];

var InterviewStatus = {
    0: 'Upcoming',
    1: 'Pending',
    2: 'Passed',
    3: 'Failed'
}

function getAllCompanies() {
    do_getAllCompanies();
}

function do_getAllCompanies() {
    sendRequestGet(null, do_getAllCompanies_success, null, 'GetAllCompanies');
}

function do_getAllCompanies_success(result, textstatus, xhr) {
    if (xhr.status === 204) {
        alertMessage(true, 'No companies found!', true);
    } else {
        if (result != null) {
            companyList = result;
            drawCompanyTable(companyList);
        }
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
                    <td>${obj.phone == null ? '' : obj.phone}</td>
                    <td>${obj.description == null ? '' : obj.description}</td>
                    <td>${obj.remarks == null ? '' : obj.remarks}</td>
                    <td class="action-button-width ">
                        <button class="btn btn-success" onclick="editCompany(${obj.id});">Edit</button>
                        <button class="btn btn-danger" onclick="deleteCompany(${obj.id});">Delete</button>
                        <button class="btn btn-info" onclick="viewInterviews(${obj.id});">View Interviews</button>
                        <button class="btn btn-success" onclick="addInterview(${obj.id});">Add Interview</button>
                    </td>
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
    if (validateCompanyData()) {
        do_saveCompany(createCompanySaveObject());
    }
}

function validateCompanyData() {
    $('.error-message').addClass('d-none');
    var result = true;
    if ($('#txtName').val().length == 0) {
        $('#nameError').removeClass('d-none');
        result = false;
    } else if ($('#txtCountry').val().length == 0) {
        $('#countryError').removeClass('d-none');
        result = false;
    } else if ($('#txtDate').val().length == 0) {
        $('#dateError').removeClass('d-none');
        result = false;
    }
    return result;
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
    if (result != null) {
        clearCompanyEditModal();
        $('#divEditCompany').modal('hide');
        var index = companyList.findIndex(x => x.id == result.id);
        if (index > -1) {
            companyList[index] = result;
        } else {
            companyList.push(result);
        }
        drawCompanyTable(companyList);
        alertMessage(true, 'Company successfully Saved!', true);
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
    confirmationMessage('Are you sure!', 'Are you sure you want to delete this company?', `do_deleteCompany(${id})`);
}

function do_deleteCompany(id) {
    sendRequestGet({id: id}, do_deleteCompany_sucess, null, 'DeleteCompany');
}

function do_deleteCompany_sucess(result) {
    if (result != null) {
        var index = companyList.findIndex(x => x.id == result);
        if (index > -1) {
            companyList.splice(index, 1);
            drawCompanyTable(companyList);
        }
        alertMessage(true, 'Company successfully deleted!', true);
    }
}

function addInterview(id) {
    clearInterviewEditModal();
    selectedCompanyId = id;
    $('#divAddInterview').modal('show');
}

$('.btnInterviewClose').on('click', function () {
    clearInterviewEditModal();
    $('#divAddInterview').modal('hide');
});

function clearInterviewEditModal() {
    selectedCompanyId = -1;
    $('#hdnInterviewId').val('-1');
    $('#txtInteviewName').val('');
    $('#txtInterviewDate').val('');
    $('#txtInterviewStatus').val(0);
    $('#txtInterviewRemark').val('');
}


$('#btnInterviewSave').on('click', function () {
    saveInterview();
});

function saveInterview() {
    if (validateInterviewData()) {
        do_saveInterview(createInterviewSaveObject());
    }
}

function validateInterviewData() {
    $('.error-message').addClass('d-none');
    var result = true;
    if (selectedCompanyId == -1) {
        $('#interviewNameError').text('Please select a company first!');
        $('#interviewNameError').removeClass('d-none');
        result = false;
    }
    else if ($('#txtInteviewName').val().length == 0) {
        $('#interviewNameError').text('Please enter an interview name');
        $('#interviewNameError').removeClass('d-none');
        result = false;
    } else if ($('#txtInterviewDate').val().length == 0) {
        $('#interviewDateError').removeClass('d-none');
        result = false;
    }
    return result;
}

function createInterviewSaveObject() {
    var obj = {};
    obj.id = Number($('#hdnInterviewId').val());
    obj.companyId = selectedCompanyId;
    obj.name = $('#txtInteviewName').val();
    obj.date = $('#txtInterviewDate').val();
    obj.status = Number($('#txtInterviewStatus').val());
    obj.remark = $('#txtInterviewRemark').val();

    return obj;
}

function do_saveInterview(obj) {
    sendRequestPost(obj, do_saveInterview_sucess, null, 'SaveInterview');
}

function do_saveInterview_sucess(result) {
    if (result != null) {
        clearInterviewEditModal();
        $('#divAddInterview').modal('hide');
        alertMessage(true, 'Interview successfully Saved!', true);
    }
}


function viewInterviews(id) {
    clearViewInterviewModal();
    getInterviews(id);
}

function clearViewInterviewModal() {
    selectedCompanyInterviewList = [];
}

function getInterviews(companyId) {
    sendRequestGet({ companyId: companyId }, getInterviews_sucess, null, 'GetInterviews');
}

function getInterviews_sucess(result) {
    if (result != null) {
        selectedCompanyInterviewList = result;
        drawInterviewTable(selectedCompanyInterviewList);
        $('#divViewInterview').modal('show');
    }
}

function drawInterviewTable(list) {
    $('#tblInterviewBody').html('');
    list.forEach(function (interview, index) {
        drawInterviewTableRow(interview, index);
    });
}

function drawInterviewTableRow(obj, index) {
    let line = `<tr id="interviewTr_${obj.id}">
                    <td> ${index + 1}</td>
                    <td> ${obj.name}</td>
                    <td>${obj.date.split('T')[0]}</td>
                    <td>${InterviewStatus[obj.status]}</td>
                    <td>${obj.remark == null ? '' : obj.remark}</td>
                    <td class="view-interview-action-button-width">
                        <a class="btn btn-success" onclick="editInterview(${obj.companyId},${obj.id})">Edit</a>
                        <a class="btn btn-danger" onclick="deleteInterview(${obj.id})">Delete</a>
                    </td>
                </tr>`;
    $('#tblInterviewBody').append(line);
}

function editInterview(companyId, id) {
    clearInterviewEditModal();
    selectedCompanyId = companyId;
    if (selectedCompanyInterviewList.length > 0) {
        var index = selectedCompanyInterviewList.findIndex(x => x.id == id);
        if (index > -1) {
            showInterviewValues(selectedCompanyInterviewList[index]);
            $('#divViewInterview').modal('hide');
            $('#divAddInterview').modal('show');
        }
    }
}

function showInterviewValues(obj) {
    $('#hdnInterviewId').val(obj.id);
    $('#txtInteviewName').val(obj.name);
    $('#txtInterviewStatus').val(obj.status);
    $('#txtInterviewDate').val(obj.date.split('T')[0]);
    $('#txtInterviewRemark').val(obj.remark);
}

$('.btnViewInterviewClose').on('click', function () {
    clearViewInterviewModal();
    $('#divViewInterview').modal('hide');
});

function deleteInterview(id) {
    confirmationMessage('Are you sure!', 'Are you sure you want to delete this interview?', `do_deleteInterview(${id})`);
}

function do_deleteInterview(id) {
    sendRequestGet({ id: id }, do_deleteInterview_sucess, null, 'DeleteInterview');
}

function do_deleteInterview_sucess(result) {
    if (result != null) {
        var index = selectedCompanyInterviewList.findIndex(x => x.id == result);
        if (index > -1) {
            selectedCompanyInterviewList.splice(index, 1);
            drawInterviewTable(selectedCompanyInterviewList);
        }
        alertMessage(true, 'Interview successfully deleted!', true);
    }
}

$(document).ready(function () {
    getAllCompanies();
});


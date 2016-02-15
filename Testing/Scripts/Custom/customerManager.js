function addNewCustomer() {
    var customerToAdd = {
        DateOfBirth: $("#newCustomerDOB").val(),
        FirstName: $("#newCustomerFirstName").val(),
        LastName: $("#newCustomerLastName").val()
    }

    $.ajax({
        url: "Home/AddNewCustomer",
        async: true,
        type: "POST",
        data: JSON.stringify(customerToAdd),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var json = JSON.parse(response);
            addRowToTable(json);
            $("#newCustomerDOB").val("");
            $("#newCustomerFirstName").val("");
            $("#newCustomerLastName").val("");
        },
        error: function (response) {
            //Typically do something here
        }
    });
}
function setUpdateFields(customerId, firstName, lastName, dateOfBirth){
    $("#updateCustomerId").val(customerId);
    $("#updateCustomerFirstName").val(firstName);
    $("#updateCustomerLastName").val(lastName);
    $("#updateCustomerDOB").val(dateOfBirth);
}

function updateCustomer() {
    var customerToUpdate = {
        CustomerId: $("#updateCustomerId").val(),
        DateOfBirth: $("#updateCustomerDOB").val(),
        FirstName: $("#updateCustomerFirstName").val(),
        LastName: $("#updateCustomerLastName").val()
    }

    $.ajax({
        url: "Home/UpdateCustomer",
        async: true,
        type: "POST",
        data: JSON.stringify(customerToUpdate),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            //Need to figure out why the below isn't being recognized by jQuery in the DOM...
            //var json = JSON.parse(response);
            //$("#custFullName_" + json.CustomerId).val(json.FullName);
            //$("#custDOB_" + json.CustomerId).val(json.DateOfBirth);

            $("#updateCustomerId").val(""),
            $("#updateCustomerDOB").val("");
            $("#updateCustomerFirstName").val("");
            $("#updateCustomerLastName").val("");
        },
        error: function (response) {
            //Typically do something here
        }
    });

}

function addRowToTable(json) {
    var table = $("#customerDisplayTable")[0];
    var rowCount = table.rows.length;
    var row = table.insertRow(rowCount);

    var cell1 = row.insertCell(0);
    var element1 = document.createElement("span");
    element1.innerHTML = json.FullName;
    cell1.appendChild(element1);

    var cell2 = row.insertCell(1);
    cell2.style.paddingLeft = "10px";
    var element2 = document.createElement("span");
    element2.innerHTML = json.DateOfBirth;
    cell2.appendChild(element2);
}
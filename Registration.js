$(document).ready(function () {
    ListRegistration();
    GetDetails();
});

var SaveRegistration = function () {
    debugger;
    var Registration_ID = $("#hdnRegistration_ID").val();
    var Registration_FullName = $("#txtRegistration_FullName").val();
    var Registration_Email = $("#txtRegistration_Email").val();
    var Registration_Mobile = $("#txtRegistration_Mobile").val();
    var Registration_Address = $("#txtRegistration_Address").val();
    var Registration_Country = $("#txtRegistration_Country").val();

    var model = {
        Registration_ID: Registration_ID,
        Registration_FullName: Registration_FullName,
        Registration_Email: Registration_Email,
        Registration_Mobile: Registration_Mobile,
        Registration_Address: Registration_Address,
        Registration_Country: Registration_Country,
    }

    $.ajax({
        url: "/Registration/SaveRegistration",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.message);
            ListRegistration();
        }
    });
}

var ListRegistration = function () {
    debugger;
    $.ajax({
        url: "/Registration/ListRegistration",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("tblRegistration tbody").empty();
            $.each(response.model, function (Index, elementValue) {
                html += "<tr><td>" + elementValue.Registration_ID +
                    "</td><td>" + elementValue.Registration_FullName +
                    "</td><td>" + elementValue.Registration_Email +
                    "</td><td>" + elementValue.Registration_Mobile +
                    "</td><td>" + elementValue.Registration_Address +
                    "</td><td>" + elementValue.Registration_Country +
                    "</td><td><input type='submit' value='Delete' class='btn btn-danger' onclick='DeleteRegistration(" + elementValue.Registration_ID +
                    ")'/></td><td><input type='submit' value='Edit' class='btn btn-warning' onclick='EditRegistration(" + elementValue.Registration_ID +
                    ")'/></td><td><input type='submit' value='Details' class='btn btn-primary' onclick='Details(" + elementValue.Registration_ID + ")'/></td></tr>";
            });
            $("#tblRegistration tbody").append(html);
        }
    });
}

var EditRegistration = function (Registration_ID) {
    var model = { Registration_ID: Registration_ID };
    debugger;
    $.ajax({
        url: "/Registration/EditRegistration", 
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#hdnRegistration_ID").val(response.model.Registration_ID);
            $("#txtRegistration_FullName").val(response.model.Registration_FullName);
            $("#txtRegistration_Email").val(response.model.Registration_Email);
            $("#txtRegistration_Mobile").val(response.model.Registration_Mobile);
            $("#txtRegistration_Address").val(response.model.Registration_Address);
            $("#txtRegistration_Country").val(response.model.Registration_Country);

        }
    });
}

var DeleteRegistration = function (Registration_ID) {
    var model = { Registration_ID: Registration_ID };
    debugger;
    $.ajax({
        url: "/Registration/DeleteRegistration", 
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert("Record Deleted Successfully");
            ListCRUD();
        }
    });
}

var Details = function (Registration_ID) {
    debugger;
    window.location.href = "/Registration/Details?Registration_ID=" + Registration_ID;
}

var GetDetails = function () {
    debugger;
    var Registration_ID = $("#hdnRegistration_ID").val();
    var model = { Registration_ID: Registration_ID }
    $.ajax({
        url: "/Registration/GetDetails", 
        method: "post",
        type: "GET",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            html += "<label>Name:<span>" + response.model.Registration_ID + "</span></label>";
            html += "<label>MobileNo:<span>" + response.model.Registration_FullName + "</span></label>";
            html += "<label>email:<span>" + response.model.Registration_Email + "</span></label>";
            html += "<label>Address:<span>" + response.model.Registration_Mobile + "</span></label>";
            html += "<label>Cityid:<span>" + response.model.Registration_Address + "</span></label>";
            html += "<label>Stateid:<span>" + response.model.Registration_Country + "</span></label>";
            $("#tblRegistration").append(html);
        }
    });
};


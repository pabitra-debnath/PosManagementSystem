$(document).ready(function () {

    //--------------Tab operation--------------
    $('#PersonalInfo').hide();
    $('#officialTab').css({
        "background": "#fff",
        "color": "#000",
        "border-radius": "50px 50px 0 0",
        "font-weigh": "bold",
        "font-size": "20px"
    });

    $('#officialTab').click(function() {
        $('#PersonalInfo').hide();
        $('#OfficialInfo').show();

        $('#personalTab').css({
            "background":"darkgreen",
            "color": "#fff",
            "font-weigh": "normal",
            "font-size": "15px"
        });
        $('#officialTab').css({
            "background": "#fff",
            "color": "#000",
            "border-radius": "50px 50px 0 0",
            "font-weigh": "bold",
            "font-size":"20px"
        });
    });

    $('#personalTab').click(function () {
        $('#OfficialInfo').hide();
        $('#PersonalInfo').show();
        $('#personalTab').css({
            "background": "#fff",
            "color": "#000",
            "border-radius": "50px 50px 0 0",
            "font-weigh": "bold",
            "font-size": "20px"
        });
        $('#officialTab').css({
            "background":"darkgreen",
            "color": "#fff",
            "font-weigh": "normal",
            "font-size": "15px"
        });
    });
    //----------------------------------------------

    //Generate Code
    $('#Name').keyup(function() {
        var name = $(this).val();
        $.ajax({
            url: "/Employee/GetCode",
            data: { nameValue: name },
            type: "POST",
            success: function(response) {
                $('#Code').val(response);
            },
            error: function(response) {
                alert("Can't generate code for" + response);
            }
        });
    });
    //------------------------------------------------------

    //Organization Dropdown load
    $.ajax({
        url: "/Organization/GetAll",
        type: "POST",
        success: function(response) {
            var organizations = response;
            options = "<option value='0'>---Select Organization---</option>";
            $('#OrganizationId').empty();
            $.each(organizations,
                function(key, org) {
                    options += "<option value=" + org.Id + ">" + org.Name + "</option>";
                });
            $('#OrganizationId').append(options);
        },
        error: function (response) {
            alert("Can't load Organization for " + response);
        }
    });
    //---------------------------------------------------------------
    //Branch Dropdown load
    //$.ajax({
    //    url: "/Branch/GetAll",
    //    type: "POST",
    //    success: function (response) {
    //        var organizations = response;
    //        options = "<option value>---Select Branch---</option>";
    //        $('#BranchId').empty();
    //        $.each(organizations,
    //            function (key, branch) {
    //                options += "<option value=" + branch.Id + ">" + branch.Address + "</option>";
    //            });
    //        $('#BranchId').append(options);
    //    },
    //    error: function (response) {
    //        alert("Can't load Organization for " + response);
    //    }
    //});
    //----------------------------------------------------------------

    //Branch Dropdown load by Organization Id
    $('#OrganizationId').change(function() {
        var id = $(this).val();
        $.ajax({
            url: "/Branch/GetByOrganization",
            type: "POST",
            data: {organizationId: id },
            success: function (response) {
                var organizations = response;
                options = "<option value>---Select Branch---</option>";
                $('#BranchId').empty();
                $.each(organizations,
                    function (key, branch) {
                        options += "<option value=" + branch.Id + ">" + branch.Address + "</option>";
                    });
                $('#BranchId').append(options);
                $('.branchdd').show();
            },
            error: function (response) {
                alert("Can't load Organization for " + response);
            }
        });
    });
    //---------------------------------------------------------------------

    //Reference Dropdown Load
    $.ajax({
        url: "/Employee/GetAll",
        type: 'POST',
        success: function(response) {
            var employees = response;
            var options = "<option value='0'>---Select Reference---</option>";
            $('#ReferenceId').empty();
            $.each(employees,
                function(key, emp) {
                    options += "<option value=" + emp.Id + ">" + emp.Name + "</option>";
                });
            $('#ReferenceId').append(options);
        },
        error: function(response) {
            $('#ReferenceId').append("<option value='0'>---Select Reference---</option>");
            alert("Can't load Reference member for " + response);
        }
    });


    //Delete Employee
    $('.deleteBtn').click(function () {
        if (confirm("Are you sure want to delete?") == true) {
            var id = $(this).val();
            $.ajax({
                url: "/Employee/Delete",
                data: { employeeId: id },
                type: "POST",
                success: function(response) {
                    location.reload();
                },
                error: function(response) {
                    alert("Can't delete for" + response);
                }
            });
        }
    });
    //----------------------------------------------------------

    //Edit employee
    //$('.editBtn').click(function() {
    //    var id = $(this).val();
    //    $.ajax({
    //        url: "/Employee/Edit",
    //        data: { employeeId: id },
    //        type: "POST",
    //        success: function(response) {
    //            var emp = response;
    //            $('#Name').val(emp.Name);
    //            $('#Code').val(emp.Code);
    //            $('#JoiningDate').val(emp.JoiningDate);
    //            $('#ContactNo').val(emp.ContactNo);
    //            $('#Email').val(emp.Email);
    //            $('#EmergencyContact').val(emp.EmergencyContact);
    //            $('#NID').val(emp.NID);
    //            $('#FathersName').val(emp.FathersName);
    //            $('#MothersName').val(emp.MothersName);
    //            $('#PresentAddress').val(emp.PresentAddress);
    //            $('#PermanentAddress').val(emp.PermanentAddress);
    //        },
    //        error: function(response) {
    //            alert("Can't edit for" + response);
    //        }
    //    });
    //});

})
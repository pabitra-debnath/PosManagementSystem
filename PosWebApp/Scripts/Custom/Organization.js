$(document).ready(function () {

    //Generate code
    $('#Name').keyup(function() {
        var name = $('#Name').val();
        $.ajax({
            url: "/Organization/GetCode",
            data: { nameValue: name },
            type: "POST",
            success: function(response) {
                var code = response;
                $('#Code').val(code);
            },
            error: function(response) {

            }
        });
    });

    //Delete organization
    $('.deleteBtn').click(function() {
        var id = $(this).val();
        if (confirm("Confirm to Delete?") == true) {
            $.ajax({
                url: "/Organization/Delete",
                data: { categoryId: id },
                type: "POST",
                success: function (response) {
                    location.reload();
                },
                error: function (response) {
                    alert("Can't Delete for" + response);
                }
            });
        }
    });

    //Edit Organization
    $('.editBtn').click(function() {
        var id = $(this).val();
        $('.addBtn').val("Update");
        $('#OrganizationForm').attr({
            action: "/Organization/Update"
        });
        $.ajax({
            url: "/Organization/Edit",
            data: { categoryId: id },
            type: "POST",
            success: function(response) {
                var org = response;
                $('#Id').val(org.Id);
                $('#Name').val(org.Name);
                $('#PrevName').val(org.Name);
                $('#Code').val(org.Code);
                $('#PrevCode').val(org.Code);
                $('#ContactNo').val(org.ContactNo);
                $('#PrevContactNo').val(org.ContactNo);
                $('#Address').val(org.Address);
                $('#ImagePath').val(org.ImagePath);
            },
            error: function(response) {
                alert("can't edit for" + response);
            }
        });
    });
})
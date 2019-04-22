$(document).ready(function () {

    //Parent category dropdown
    $('#ParentCat').hide(250);

    $('#rootRadio').click(function () {
        $('#ParentCat').hide(250);
    });

    $('#childRadio').click(function () {
        $('#ParentCat').show(250);
        $.ajax({
            url: "/ExpenseCategory/GetAll",
            type: "POST",
            success: function(response) {
                var categories = response;
                var options = "<option value='0'>---Select One---</option>";
                $('#ParentId').empty();
                $.each(categories,
                    function(key, category) {
                        options += "<option value=" + category.Id + ">" + category.Name + "</option>";
                    });
                $('#ParentId').append(options);
            },
            error: function(response) {
                alert("Failed to load category dropdown");
            }
        });
    });

    //Generate code
    $('#Name').keyup(function() {
        var name = $('#Name').val();
        $.ajax({
            url: "/ExpenseCategory/GetCode",
            data: { nameValue: name },
            Type: "POST",
            success: function(response) {
                $('#Code').val(response);
            },
            errror: function(response) {

            }
        });
    });

    //Delete category
    $('.deleteBtn').click(function() {
        var id = $(this).val();
        if (confirm("Confirm to Delete?") == true) {
            $.ajax({
                url: "/ExpenseCategory/Delete",
                data: { categoryId: id },
                type: "POST",
                success: function (response) {
                    location.reload();
                },
                error: function(response) {
                    alert("Can't Delete for" + response);
                }
            });
        }
    });

    //Edit category
    $('.editBtn').click(function() {
        $('#addBtn').val("Update");
        var id = $(this).val();
        $('#ExpenseCategoryForm').attr({
            action: "/ExpenseCategory/Update"
        });
        $.ajax({
            url: "/ExpenseCategory/Edit",
            data: { categoryId: id },
            type: "POST",
            success: function(response) {
                var category = response;
                $('#Id').val(category.Id);
                $('#Name').val(category.Name);
                $('#PrevName').val(category.Name);
                $('#Code').val(category.Code);
                $('#PrevCode').val(category.Code);
                $('#Description').val(category.Description);
            },
            error: function(response) {
                alert("Can,t Edit for" + response);
            }
        });
    });
    //$('#addBtn').click(function () {
    //    $('#addBtn').val("Save");
    //    $('#ExpenseCategoryForm').attr({
    //        action: "/ExpenseCategory/Add"
    //    });
    //});
})
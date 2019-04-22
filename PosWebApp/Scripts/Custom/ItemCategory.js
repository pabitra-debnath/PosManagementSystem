$(document).ready(function () {
    $('#ParentCat').hide();

    $('#addBtn').click(function() {
        $('#addBtn').val("Save");
        $('#itemCategoryForm').attr({
            action: "/ItemCategory/Add"
        });
    });

    //Generate Parent Category Dropdown
    $('#childRadio').click(function() {
        $('#ParentCat').show(100);
        $.ajax({
            url: "/ItemCategory/GetAll",
            type: "POST",
            success:function(response) {
                var categories = response;
                var options = "<option value='0'>---Select One---</option>";
                $('#ParentId').empty();
                $.each(categories,
                    function(key, category) {
                        options += "<option value=" + category.Id + ">" + category.Name + "</option>";
                    });
                $('#ParentId').append(options);
            },
            error:function(response) {
                
            }
        });
    });
    $('#rootRadio').click(function() {
        $('#ParentCat').hide(100);
    });

    //Generate Code
    $('#Name').keyup(function () {
        var name = $('#Name').val();
        $.ajax({
            url: "/ItemCategory/GetCode",
            data: { nameValue: name },
            type: "POST",
            success: function(response) {
                var code = response;
                $('#Code').val(code);
            },
            error: function(response) {
                $('#Code').val(response);
            }
        });
    });

    //Delete category
    $('.deleteBtn').click(function () {
        var id = $(this).val();
        
        if (confirm("Confirm to Delete?") == true) {
            $.ajax({
                url: "/ItemCategory/Delete",
                data: { categoryId: id },
                type: "POST",
                success: function (response) {
                    location.reload();
                },
                error: function (response) {
                }
            });
        }
    });

    //Edit Category
    $('.editBtn').click(function () {
        var id = $(this).val();
       
        $.ajax({
            url: "/ItemCategory/Edit",
            data: { categoryId: id },
            type: "POST",
            success: function (response) {
                var categories = response;
                $.each(categories,
                    function (key, category) {
                        $('#Id').val(id);
                        $('#Name').val(category.Name);
                        $('#PrevName').val(category.Name);
                        $('#Code').val(category.Code);
                        $('#PrevCode').val(category.Code);
                        $('#Description').val(category.Description);
                        $('#ImagePath').val(category.ImagePath);
                    });
            },
            error: function(response) {
                alert(response);
            }
        });
        $('#addBtn').val("Update");
        $('#ItemCategoryForm').attr({
            action: "/ItemCategory/Update"
        });
    });
})

$(document).ready(function () {

    $("#itemCategoryFile").change(function () {

        if (this.files && this.files[0]) {

            if (this.files[0].name.match(/\.(jpg|jpeg|png|gif)$/)) {

                if (!(this.files[0].size > (1 * 1024 * 1024))) {

                    var reader = new FileReader();

                    reader.onload = function (element) {
                        $("#itemCategoryFilePreview").attr('src', element.target.result);
                    };
                    reader.readAsDataURL(this.files[0]);
                } else {
                    alert("Image size larger than 1 MB");
                    $(this).val(null);
                    $("#itemCategoryFilePreview").attr('src', null);
                }
            } else {
                alert("This is not image file");
                $(this).val(null);
                $("#itemCategoryFilePreview").attr('src', null);
            }
        } else {
            $("#itemCategoryFilePreview").attr('src', null);
        }
    });

});

//-----------------------------------------------------------------------------------------------
$(document).ready(function () {

    $("#ImageFile").change(function () {

        if (this.files && this.files[0]) {

            if (this.files[0].name.match(/\.(jpg|jpeg|png|gif)$/)) {

                if (!(this.files[0].size > (1 * 1024 * 1024))) {

                    var reader = new FileReader();

                    reader.onload = function (element) {
                        $("#ImagePreview").attr('src', element.target.result);
                    };
                    reader.readAsDataURL(this.files[0]);
                } else {
                    alert("Image size larger than 1 MB");
                    $(this).val(null);
                    $("#ImagePreview").attr('src', null);
                }
            } else {
                alert("This is not image file");
                $(this).val(null);
                $("#ImagePreview").attr('src', null);
            }
        } else {
            $("#ImagePreview").attr('src', null);
        }
        $('#ImagePreview').css({
            "height": "150px",
            "width": "150px"
        });
    });

});

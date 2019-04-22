
$.notify.defaults({ autoHideDelay: 2000 });

$("#stockReportExportToPdf").click(function () {

    var branchId = $("#branchId").val();

    $.ajax({
        type: "POST",
        url: "/StockReport/ExportAllInfoToPdf",
        data: { branchId: branchId },
        success: function (response) {
            $.notify("Export Completed", "success");
        },
        error: function (response) {
            $.notify("Export Failed", "error");
        }

    });

});


function CheckReportValue() {

    if ($('#branchId').val() == '') {
        $('#branchId').focus();
        $('#branchId').notify("Please select the branch");
        return false;
    }

    return true;
}

function getPdf() {
    html2canvas($('#pdfFile'),
    {
        onrendered: function (canvas) {
            var img = canvas.toDataURL("image/png");
            var doc = new jsPDF();
            doc.addImage(img, 'JPEG', 15, 15);
            doc.save('StockReport.pdf');
        }
    });
}
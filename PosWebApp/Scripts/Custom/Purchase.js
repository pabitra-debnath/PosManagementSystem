$(document).ready(function() {

    
    //Load item dropdown
    $.ajax({
        url: "/Purchase/GetAllItem",
        type: "POST",
        success: function(response) {
            var options = "<option value=0>---Select Item---</option>";
            var items = response;
            $.each(items,
                function(key, item) {
                    options += "<option value=" + item.Id + ">" + item.Name + "</option>";
                });
            $('#ItemId').append(options);
        },
        error: function(response) {
            alert("Can't load items for" + response);
        }
    });
    //-----------------------------------------------------------------------------

    //var price = "";
    //$('#Price').keyup(function () {
    //    price = $(this).val();
    //});
    //-----------------------------------------------------

    //Load item price
    $('#ItemId').change(function () {
        var id = $(this).val();
        if (id == 0) {
            $('#Quantity').val(0);
            $('#Price').val(0);
        } else {
            $('#Quantity').val(1);
            $.ajax({
                url: "/Purchase/GetItemById",
                data: { itemId: id },
                type: "POST",
                success: function (response) {
                    price = response.CostPrice;
                    var Qty = $('#Quantity').val();
                    var totalPrice = price * Qty;
                    $('#Price').val(totalPrice);
                }
            });
        }
    });

    //Quantity change event------------------------------------------------------------
    //$('#Quantity').change(function () {
    //    if (price <= 0) {
    //        price = $('#Price').val();
    //    }
    //    var id = $('#ItemId').val();
    //    if ($(this).val() <=0) {
    //        $('#Price').val(0);
    //        $('#Quantity').val(0);
    //    }
    //    else {
    //        var totalPrice = price * $(this).val();
    //        $('#Price').val(totalPrice);
    //    }
        
    //});

    //Quantity keyup event------------------------------------------------------------
    //$('#Quantity').keyup(function () {
    //    if (price <= 0) {
    //        price = $('#Price').val();
    //    }
    //    if ($(this).val() <= 0) {
    //        $('#Price').val(0);
    //        $('#Quantity').val("");
    //    } else {
    //        var totalPrice = price * $(this).val();
    //        $('#Price').val(totalPrice);
    //    }
    //});
    //---------------------------------------------------------

    //Load Organization Dropdown
    $.ajax({
        url: "/Organization/GetAll",
        type: "POST",
        success: function(response) {
            var orgs = response;
            var options = "<option value=0>---Select Organization---</option>";
            $.each(orgs,
                function(key, org) {
                    options += "<option value=" + org.Id + ">" + org.Name + "</option>";
                });
            $('#OrganizationId').append(options);
        }
    });
    //------------------------------------------------------

    //Load Branch Dropdown
    $('#OrganizationId').change(function () {
        var id = $('#OrganizationId').val();
        $('#BranchId').empty();
       $.ajax({
           url: "/Branch/GetByOrganization",
           data:{organizationId:id},
           type: "POST",
           success: function (response) {
               var branchs = response;
               var options = "<option value=0>---Select Branch---</option>";
               $.each(branchs,
                   function (key, branch) {
                       options += "<option value=" + branch.Id + ">" + branch.Address + "</option>";
                   });
               $('#BranchId').append(options);
           }
       });
   })
    //------------------------------------------------------

    //Load Employee Dropdown
    $.ajax({
        url: "/Employee/GetAll",
        type: "POST",
        success: function (response) {
            var employees = response;
            var options = "<option value=0>---Select Employee---</option>";
            $.each(employees,
                function (key, emp) {
                    options += "<option value=" + emp.Id + ">" + emp.Name + "</option>";
                });
            $('#EmployeeId').append(options);
        }
    });
    //------------------------------------------------------

    //Load Supplier Dropdown
    $.ajax({
        url: "/Party/GetAll",
        type: "POST",
        success: function (response) {
            var parties = response;
            var options = "<option value=0>---Select Supplier---</option>";
            $.each(parties,
                function (key, party) {
                    options += "<option value=" + party.Id + ">" + party.Name + "</option>";
                });
            $('#PartyId').append(options);
        }
    });
    //-------------------------------------------------------------

    //Purchase Table operation
    $('.addBtn').click(function () {
        CreatePurchaseRow();
    });


    function CreatePurchaseRow() {
        var selectedItem = GetSelectedItem();
        var index = $('.AddedDataTable').children("tr").length;
        var sl = index;

        var indexCell = "<td style='display:none;'><input type='hidden' id='Index" +index +"' name='PurchaseDetailses.Index' value='" +index +"'/></td>";
        var serialCell = "<td>" + (sl++) + "</td>";
        var itemNameCell = "<td><input type='hidden' id='ItemName" +index +"' name='PurchaseDetailses[" +index +"].ItemId' value='" +selectedItem.ItemId +"'/>" +selectedItem.ItemName +"</td>";
        var itemQuantityCell = "<td><input type='hidden' id='ItemQuantity" + index + "' name='PurchaseDetailses[" + index + "].Quantity' value='" + selectedItem.ItemQuantity + "'/>" + selectedItem.ItemQuantity + "</td>";
        var itemPriceCell = "<td><input type='hidden' id='ItemPrice" + index + "' name='PurchaseDetailses[" + index + "].Price' value='" + selectedItem.ItemPrice + "'/>" + selectedItem.ItemPrice + "</td>";
        var itemTotalCell = "<td><input type='hidden' id='ItemTotalPrice" + index + "' name='PurchaseDetailses[" + index + "].TotalPrice' value='" + selectedItem.TotalPrice + "'/>" + selectedItem.TotalPrice + "</td>";

        var newRow = "<tr>" + indexCell + serialCell + itemNameCell + itemQuantityCell + itemPriceCell + itemTotalCell + "</tr>";

        $('.AddedDataTable').append(newRow);
    }

    function GetSelectedItem() {
        var itemId = $('#ItemId').val();
        var itemName = $('#ItemId').text();
        var itemQuantity = $('#Quantity').val();
        var itemPrice = $('#Price').val();
        var totalPrice = itemQuantity * itemPrice;

        var item = {
            "ItemId": itemId,
            "ItemName": itemName,
            "ItemQuantity": itemQuantity,
            "ItemPrice": itemPrice,
            "TotalPrice": totalPrice
        }
        return item;
    }






})
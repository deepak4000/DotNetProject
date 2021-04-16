
//For Calendar
var Alldays = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
var disableDays = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Saturday", "Sunday"];
function ShowDisableDates(date) {
    ymd = date.getFullYear() + "/" + ("0" + (date.getMonth() + 1)).slice(-2) + "/" + ("0" + date.getDate()).slice(-2);
    day = new Date(ymd).getDay();
    if ($.inArray() < 0 && $.inArray(Alldays[day], disableDays) < 0) {
        return [true, "enabled", "Book Now"];
    } else {
        return [false, "disabled", "Sold Out"];
    }
}
$(function () {
    $("#datepicker").datepicker({ beforeShowDay: ShowDisableDates });
});


// For Add Row
$(function () {
    //For Add Row
    $("#add-row").click(function (e) {
        e.preventDefault();
        var rowCount = $('#table-row > tbody > tr').length;
        rowCount = rowCount + 1;
        var abc = $('#ddlProject').html();
        var ad = $('#ddlTask').html();
        $('#table-row > tbody > tr:last').after('<tr id="row-' + rowCount + '"><td><select>' + abc + '</select></td ><td><select>' + ad + '</select></td><td><input type="checkbox" id="isSelected' + rowCount + '"   value=""></td><td><input class="inputday inputday-mon"  data-row="' + rowCount + '" type="text" /></td><td><input class="inputday inputday-tues"  data-row="' + rowCount + '" type="text" /></td><td><input class="inputday inputday-wed"  data-row="' + rowCount + '" type="text" /></td><td><input class="inputday inputday-thurs"  data-row="' + rowCount + '" type="text" /></td><td><input class="inputday inputday-fri"  data-row="' + rowCount + '" type="text" /></td><td><input class="inputday inputday-sat"  data-row="' + rowCount + '" type="text" /></td><td><input class="inputday inputday-sun"  data-row="' + rowCount + '" type="text" /></td><td><textarea type="text"></textarea></td><td><a href="#"> <img src="/Images/deleteicon.jpg"  class="icon delete"> </a></td><td><label for="Cal" class="total">0.00</label></td></tr>');
    });
});

//For Row
$(function () {
    $(document).on('change', 'input[type="text"]', function () {

        var total = 0;
        var daytotal = 0;
        var billabletotal = 0;
        var nonbillabletotal = 0;
        var idName = $(this).parent().parent().attr('id');
        $('#' + idName + ' :input[type="text"]').each(function () {
            var row = $(this).attr('data-row');
            if ($("#" + "isSelected" + row).is(':checked') == true) {

            }
            var currentValue = parseInt($(this).val());
            if (!isNaN(currentValue)) {
                total += currentValue;
            }
        });
        var className = ($(this).attr('class').split(' ')[1]);
        // console.log(className);
        $('.' + className).each(function () {
            var test = parseInt($(this).val());

            var row = $(this).attr('data-row');
            if ($("#" + "isSelected" + row).is(':checked') == true) {
                if (!isNaN(test)) {
                    billabletotal += test;
                }
            } else {
                if (!isNaN(test)) {
                    nonbillabletotal += test;
                }
            }

        });

        $('#' + idName + ' .total').text(total);
        //start total hours sum
        var totalhourssum = 0;

        $(".total").each(function () {
            var ab = parseInt($(this).text()); 
           // console.log(parseInt(ab));
            if (ab !="0.00") {
                totalhourssum += ab;
            }
                                
        });
        
        $('.inputday-hours-total').text(totalhourssum);
        //End TotalHoursSum
       
        $('.' + className + '-billable-total').text(billabletotal);

        //Start Billable Total

        var billabletitotalsum = 0;

        $(".bilcolumntotal").each(function () {
            var bilsum = parseInt($(this).text());
            
            if (bilsum != 0) {
                billabletitotalsum += bilsum;
            }           

        });
        //console.log(billabletitotalsum);
        $('.sumtotalbillable').text(billabletitotalsum);
        //End Billable Total

        $('.' + className + '-nonbillable-total').text(nonbillabletotal);
        //Start NonBillable Total

        var nonbillabletotalsum = 0;

        $(".nonbillablecolumntotal").each(function () {

            var nonbillsum = parseInt($(this).text());
            if (nonbillsum != 0) {
                nonbillabletotalsum += nonbillsum;

            }

        });
        //console.log(billabletitotalsum);
        $('.sumtotalnonbillable').text(nonbillabletotalsum);
        //End NonBillable Total
    });


    $("#table-row").on("click", '.delete', function () {

        var rowid = $(this).parent().parent().parent().attr('id');
        var rowV = $('#' + rowid + ' .total').text();

        var rowhourstotal = parseInt($('.inputday-hours-total').text());

        var rowandcoltotal = 0;

        rowandcoltotal = rowhourstotal - rowV;

        $(this).closest("tr").remove();
        $('.inputday-hours-total').text(rowandcoltotal);




        var colbill = $(this).nextall().attr('.bilcolumntotal');
        var colV = $('.bilcolumntotal').text();
        console.log(colbill);
        var columnhours = parseInt($('.sumtotalbillable').text());
       
        var column = 0;
        column = columnhours - colbill;

       // $(this).closest("tr").remove();
        $('.sumtotalbillable').text(column);

    });

});



    




































































































































































































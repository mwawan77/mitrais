function checkIndoPhone(field, rules, i, options) {
    var arrProvider = [];
    arrProvider[0] = ["^(\\+62|\\+0|0|62)8(1[123]|52|53|21|22|23)[0-9]{5,9}$", "Telkomsel"];
    arrProvider[1] = ["^(\\+62|\\+0|0|62)8(1[123]|2[12])[0-9]{5,9}$", "Simpati"];
    arrProvider[2] = ["^(\\+62|\\+0|0|62)8(52|53|23)[0-9]{5,9}$", "AS"];
    arrProvider[3] = ["^(\\+62815|0815|62815|\\+0815|\\+62816|0816|62816|\\+0816|\\+62858|0858|62858|\\+0814|\\+62814|0814|62814|\\+0814)[0-9]{5,9}$", "Indosat"];
    arrProvider[4] = ["^(\\+62855|0855|62855|\\+0855|\\+62856|0856|62856|\\+0856|\\+62857|0857|62857|\\+0857)[0-9]{5,9}$", "IM3"];
    arrProvider[5] = ["^(\\+62817|0817|62817|\\+0817|\\+62818|0818|62818|\\+0818|\\+62819|0819|62819|\\+0819|\\+62859|0859|62859|\\+0859|\\+0878|\\+62878|0878|62878|\\+0877|\\+62877|0877|62877)[0-9]{5,9}$", "XL"];
    var isValid = 0;

    for (var i = 0; i < arrProvider.length; i++) {
        var re = new RegExp(arrProvider[i][0]);
        if (re.test(field.val())) {
            //console.log("Valid");
            isValid++;
        } else {
            //console.log("Invalid");
        }
    }

    if (isValid == 0) {
        // this allows the use of i18 for the error msgs
        return "* Invalid Indonesia Mobile Number";
    }
}

jQuery(document).ready(function ($) { //wait for the document to load

    $.blockUI.defaults.overlayCSS = {}; 

    forceFooter();
    populateDate();

    $(window).resize(function () {
        forceFooter();
    });

    function populateDate() {
        var monthName = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
        for (var month = 0; month < monthName.length; month++) {
            $("#reg_month").append('<option value="' + (month+1) + '">' + monthName[month] + '</option>');
        }
        for (var date = 1; date <= 31; date++) {
            $("#reg_date").append('<option value="' + date + '">' + date + '</option>');
        }
        var this_year = new Date().getFullYear();
        for (var year = this_year; year >= this_year - 70; year--) {
            $("#reg_year").append('<option value="' + year + '">' + year + '</option>');
        }
    }

    function forceFooter() {
        if ($(window).height() < 600) {
            $("footer").removeClass("footer-bottom");
        } else {
            $("footer").addClass("footer-bottom");
        }
    }

    // Registration Page
    $(".login_form").hide();
    $("#btnRegister").click(function () {
        $('#registration_form').validationEngine('hide');
        if ($("#registration_form").validationEngine('validate')) {
            // Check Date 
            var checkDate = $("#reg_month").val() + $("#reg_date").val() + $("#reg_year").val();
            if (checkDate != "") {
                if ($("#reg_month").val() == "") {
                    $('#reg_month').validationEngine('showPrompt', '* Month required', 'error', 'topRight', true);
                    return;
                }
                if ($("#reg_date").val() == "") {
                    $('#reg_date').validationEngine('showPrompt', '* Date required', 'error', 'topRight', true);
                    return;
                }
                if ($("#reg_year").val() == "") {
                    $('#reg_year').validationEngine('showPrompt', '* Year required', 'error', 'topRight', true);
                    return;
                }
                checkDate = $("#reg_year").val() + "-" + $("#reg_month").val() + "-" + $("#reg_date").val();
            }

            if (checkDate == "") {
                checkDate = "1900-01-01";
            }

            var reg_data = {
                "MobileNumber": $("#reg_mobile_number").val(),
                "FirstName": $("#reg_first_name").val(),
                "LastName": $("#reg_last_name").val(),
                "DateOfBirth": checkDate,
                "Sex": $("input[name='reg_sex']:checked").val(),
                "Email": $("#reg_email").val(),
                "Password": "",
                "CreatedDate": "",
                "CreatedBy": "",
                "UpdatedDate": "",
                "UpdatedBy": ""
            };

            $(".reg_form").block({
                message: null
            });

            $.ajax({
                type: 'POST',
                async: true,
                dataType: "json",
                url: "api/user",
                data: reg_data,
                success: function (data) {
                    var json = data;
                    if (json.status == "error") {
                        $(".reg_form").unblock();
                        if (json.data == "Mobile Number exist on database") {
                            $('#reg_mobile_number').validationEngine('showPrompt', '* ' + json.data, 'error', 'topRight', true);
                            return;
                        }
                        if (json.data == "Email exist on database") {
                            $('#reg_email').validationEngine('showPrompt', '* ' + json.data, 'error', 'topRight', true);
                            return;
                        }
                    } else {
                        $(".login_form").show();
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });

        }
    });

});
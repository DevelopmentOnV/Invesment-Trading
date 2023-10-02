

$("#submit").click(function ()

{
   

    if ($("#fist_name").val() == null || $("#fist_name").val() == "") {
        $("#firstname").css("display", "block");
        CustomAlert('Please Provide Only 10 Digit Contact No');
        return false;
    }
    else {
        $("#firstname").css("display", "none");
    }
    if ($("#last_name").val() == null || $("#last_name").val() == "") {
        $("#firstnme").css("display", "block");

        return false;
    }
    else {
        $("#firstname").css("display", "none");
    }
    if ($("#gmail_id").val() == null || $("#gmail_id").val() == "") {
        $("#firstnme").css("display", "block");

        return false;
    }
    else {
        $("#firstname").css("display", "none");
    }
    if ($("#Mobile_number").val() == null || $("#Mobile_number").val() == "") {
        $("#firsname").css("display", "block");

        return false;
    }
    else {
        $("#firstname").css("display", "none");
    }

    var formdata = {
        First_name: $("#fist_name").val(),
        Last_name: $("#last_name").val(),
        Gmail_id: $("#gmail_id").val(),
        Mobilenumber: $("#Mobile_number").val(),
        Country: $("#ddlNationality").val()
    }
    $.ajax({
        url: "/Home/Signuppage",
        type: 'Post',
        dataType: 'json',
        contenttype: 'application/json;',
        data: formdata,
        success: function (data) {


            if (data == "ok") {
                //window.location.href = https://www.investmentz.com/
                window.location.href = "/Home/Cofeepage";

            }

            else {
                alert("error");
            }
           

            //    window.location = "/Home/Cofeepage";

            
        },
        error: function () {
            // TODO: Show error
            window.location.href = "/Home/Cofeepage";
        }
    });
});



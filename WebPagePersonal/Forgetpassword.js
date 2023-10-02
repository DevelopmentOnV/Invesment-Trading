$("#forgetpasswords").click(function () {

    var formdatavalue = {
        Gmail_id: $("#email").val(),
        passwordconfirm: $("#passwordvalueforlogin").val(),
    }
    $.ajax({
        url: "/Home/Forgetpasseord",
        type: 'Post',
        dataType: 'json',
        contenttype: 'application/json;',
        data: formdatavalue,
        success: function (data)
        {
            var inputgmail = $("#email").val();
            if (data.Gmail_id != inputgmail) {


                alert("Please Enter Correct Email Address.!");
                $("#divforpassword").css("display", "none");
                return false;

            }
            else
            {
                $("#divforpassword").css("display", "block");
             /*   window.location.href = "/Home/Createnewpassword";  */ 
            }
          
     


        },
        error: function () {
        }
    })
});
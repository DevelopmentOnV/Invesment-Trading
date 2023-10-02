const forms = document.querySelector(".forms"),
    pwShowHide = document.querySelectorAll(".eye-icon"),
    links = document.querySelectorAll(".link");

pwShowHide.forEach(eyeIcon => {
    eyeIcon.addEventListener("click", () => {
        let pwFields = eyeIcon.parentElement.parentElement.querySelectorAll(".password");
        pwFields.forEach(password => {
            if (password.type === "password") {
                password.type = "text";
                eyeIcon.classList.replace("bx-hide", "bx-show");
                return;
            }
            password.type = "password";
            eyeIcon.classList.replace("bx-show", "bx-hide");
        })

    })
})
links.forEach(link => {
    link.addEventListener("click", e => {
        e.preventDefault(); //preventing form submit
        forms.classList.toggle("show-signup");
    })
})


/****************for_email_validation*********************/



$('#emailidinputd').keypress(function () {
    var Emailidvalue = $('#emailidinputd').val();
    var EmailidregExp = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    if (!Emailidvalue.match(EmailidregExp)) {
        document.getElementById("emailidinputd").style.borderColor = "red";
    }
    else if (Emailidvalue.match(EmailidregExp)) {
    document.getElementById("emailidinputd").style.borderColor = "green";
    }
    else
    {
       
    }
});  



/****************for_signup_page_validation*********************/



$("#signupbutton").click(function () {

   

    var xyz = $("#fullnameidinputd").val();
    if ($("#fullnameidinputd").val() == "")
    {

        Swal.fire('Enter Your Name')
    return false;
    }
    if ($("#Emailidinputdvalue").val() == "") {

        Swal.fire('Enter Your Gmail')
        return false;
    }
    if ($("#mobileidinputd").val() == "") {

        Swal.fire('Enter Your Mobile Number')
        return false;
    }
    if ($("#stateidinputd").val() == "") {

        Swal.fire('Select State')
        return false;
    }
    if ($("#fistpasswordd").val() == "") {

        Swal.fire('Enter Your Password')
        return false;
    }
    if ($("#fistpasswordd").val() != "") {

        signupdata();
       
    }
   
});



/****************after_checking_email_register_function*********************/



function signupdata() {
   
    if ($("#fistpasswordd").val() != null || $("#fistpasswordd").val() != "") {
        var passwordmatch = $("#fistpasswordd").val();
        localStorage.setItem("setfirstpassword", passwordmatch)
    }
    else
    {
    }
    if ($("#Confirmpasswordd").val() == null || $("#Confirmpasswordd").val() == "") {
        swal.fire("Please Enter Second Password")
        return false;
    }
    if ($("#Confirmpasswordd").val() != null || $("#Confirmpasswordd").val() != "") {
        var firstpassword = localStorage.getItem("setfirstpassword");
        var seconpassword = $("#Confirmpasswordd").val();
        if (firstpassword == seconpassword) {   
        }
        else {
            alert("Password Does Not Match");
        }
    }
    var formdata = {
        Fullname: $("#fullnameidinputd").val(),
        Gmail_id: $("#Emailidinputdvalue").val(),
        mobile: $("#mobileidinputd").val(), 
        State: $("#stateidinputd").val(),
        passwordconfirm: $("#Confirmpasswordd").val(),
    }
    $.ajax({
        url: 'https://localhost:44396/api/Home/InsertForm',
        type: 'GET',
        dataType: 'json',
        data: formdata,
        success: function (data, xhr) {

            var savegetdata = xhr;
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation');
        }
    });



    //$.ajax({
    //    url:"/Insertinpdf/Signuppage",
    //    type: 'Post',
    //    dataType: 'json',
    //    contenttype: 'application/json;',
    //    data: formdata,
    //    success: function (data) {
    //    if (data == "200")
    //    {
    //        $("#succsessfully").css("display", "block");
    //        setTimeout(function () {
    //            window.location.reload(1);
    //        }, 2000); 
    //    }
    //    else {
    //    alert("error");
    //    $("#succsessfully").css("display", "none");
    //        }
    //    },
    //    error: function () {
    //        alert("something wrong");
    //    }
    //});
};

/****************for_loginvalidation_validation*********************/

$("#loginpage").click(function () {
    if ($("#emailloginidforlogin").val() == "") {

        alert('Please Enter Register Gmail')
        return false;
    }

    if ($("#passwordvalueforlogin").val() == "") {
        alert('Please Enter Password')
        return false;
    }
    var formdatavalue = {
        Gmail_id: $("#emailloginidforlogin").val(),
        passwordconfirm: $("#passwordvalueforlogin").val(),
    }
    $.ajax({
        url: "/Insertinpdf/loginpage",
        type: 'Post',
        dataType: 'json',
        contenttype: 'application/json;',
        data: formdatavalue,
        success: function (data) {
            var emailid = $("#emailloginidforlogin").val();
            var password = $("#passwordvalueforlogin").val();

            if (data[0] != emailid) {
                alert("This Email Does Not Register.Please Signup And Try Again");
                return false;
            }
            if (data[0] == emailid) {
                var Gmail = data[0];
                localStorage.setItem("Sendmail", Gmail)


            }
            if (data[1] != password) {

                alert("Please Enter Correct Password.Your Password Does Not Match");
                return false;
            }
            
            if (data[1] == password) {

                $("#emailloginidforlogin").val("");
                $("#passwordvalueforlogin").val("");

            }
            window.location.href = "/Home/Cofeepage"; 
            
        },
        error: function () {   
        }
    });
});
function CheckEmailForLogin() {
    var formdatavalue = {
        Gmail_id: $("#emailidinputd").val() 
    }
    $.ajax({
        url: "/Insertinpdf/loginpage",
        type: 'Post',
        dataType: 'json',
        contenttype: 'application/json;',
         data: formdatavalue,
        success: function (data) {
            var emailid = $("#emailidinputd").val();
           
        if (data[0] == emailid)
        {
            swal.fire("Email Already Register");
            
        }
        else
        {
            signupdata();
        }   
        },
        error: function () {    
        }
    });
}
/****************for Forget Password*********************/

$("#Confirmpassword").click(function () {
    
    $("#forgtonpassword").show();
    if ($("#emailloginidforloginbg").val() == "") {

        alert('Please Enter Register Gmail')
        $("#forgtonpassword").show();
        return false;
    }

    if ($("#passwordvalueforlogind").val() == "") {
        alert('Please Enter Password')
        return false;
    }
    var formdatavalue = {
        Gmail_id: $("#emailloginidforlogfin").val(),
        passwordconfirm: $("#passwordvalueforlogin").val(),
    }
    $.ajax({
        url: "/Insertinpdf/loginpage",
        type: 'Post',
        dataType: 'json',
        contenttype: 'application/json;',
        data: formdatavalue,
        success: function (data) {
            var emailid = $("#emailloginidforlogin").val();
            var password = $("#passwordvalueforlogin").val();

            if (data[0] != emailid) {
                alert("This Email Does Not Register.Please Signup And Try Again");
                return false;
            }
            if (data[0] == emailid) {
            }
            if (data[1] != password) {

                alert("Please Enter Correct Password.Your Password Does Not Match");
                return false;
            }

            if (data[1] == password) {

                $("#emailloginidforlogin").val("");
                $("#passwordvalueforlogin").val("");
                window.location.href = "/Home/Cofeepage";
            }
        },
        error: function () {
        }
    });
});




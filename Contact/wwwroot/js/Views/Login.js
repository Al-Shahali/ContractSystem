"use strict"
String.isNullOrEmpty = function (value) {
    return (!value || value == undefined || value == "" || value.length == 0);
}
function Login() {
    $(".validation").addClass("hide");
    var Name = $('#name').val();
    var Password = $('#password').val();
    
    var valid = true;
    if (String.isNullOrEmpty(Name)) {
        valid = false;
        $(".validation").removeClass("hide");
    }

    if (String.isNullOrEmpty(Password)) {
        valid = false;
        $(".validation").removeClass("hide");
    }


    var User = {
        Concod: 0,
        Name: Name,
        Password: Password,
       
    };
    if (valid) {
        $.ajax({
            type: "POST",
            url: '/Home/IsUserPass/',
            data: JSON.stringify(User),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            async: true,
            success: function (data) {
                if (data.errcod == "GEN100") {
                    window.location.href = "/Home/Index";
                }
            },
            error: function () {

            }
        });
    }
}
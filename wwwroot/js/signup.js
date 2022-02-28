async function CheckName(paramName, stringName) 
{
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: paramName + "/" + $('input[name="' + stringName + '"]').val(),
        success: function(response)
        {
            if(response != "Exists")
            {
                $('input[name="' + stringName + '"]').removeClass("is-invalid");
                $('input[name="' + stringName + '"]').addClass("is-valid");
            }
            else
            {
                $('input[name="' + stringName + '"]').removeClass("is-valid");
                $('input[name="' + stringName + '"]').addClass("is-invalid");
            }
        },
        error: function()
        {
            
        }
    });
}

$('input[name="SignUpName"]').on("click change keyup", function()
{
    if($('input[name="SignUpName"]').val().length > 0) CheckName("api/User/IsExists", "SignUpName");
});
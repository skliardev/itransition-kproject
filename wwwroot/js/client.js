$(document).ready(function ()
{
    GetUsers();
    $("form").submit(function(e)
    {
        e.preventDefault();
        $.ajax({
            type: "PUT",
            contentType: "application/json; charset=utf-8",
            url: "api/UserApi",
            data: JSON.stringify({
                userName: this.elements["username"].value,
                email: this.elements["email"].value
            }),
            success: function(response)
            {
                row(response);
            }
        });
    });
});

async function GetUsers() 
{
    $.ajax(
    {
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "api/UserApi",
        success: function(response)
        {
            response.forEach(user => {
                row(user);
            });
        }
    });
}

var row = function(item)
{
    $("table tbody").append("<tr><td>" + item['id'] 
        + "</td><td>" + item['userName'] 
        + "</td><td>" + item['email'] 
        + "</td><td>" + item['published']
        + "</td><td>" + item['lastLogin'] 
        + "</td><td>" + item['status'] + "</td></tr>");
}
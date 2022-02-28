using Microsoft.AspNetCore.Mvc;
using project.Domain.Entities;
using project.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.JsonPatch;
using project.Models;
using System.Linq;

namespace project.Controllers.Api;

[Route("api/[controller]/[action]")]
public class UserController : Controller
{   
    private IRepository<UserAccount> users;

    public UserController(IRepository<UserAccount> userAccount)
    {
        users = userAccount;
    }

    [HttpGet("{name}")]
    public string IsExists(string name)
    {
        return users.GetRecords().FirstOrDefault(user => user.UserName == name) != null ? "Exists" : "NotExists";
    }

    [HttpGet]
    public IEnumerable<UserWrapperModel> Get() 
    {
        var list = new List<UserWrapperModel>();
        foreach(var user in users.GetRecords())
        {
            list.Add(new UserWrapperModel 
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Published = user.Published.ToString("ddd, dd MMM yyyy HH:mm"),
                LastLogin = user.LastLogin.ToString("ddd, dd MMM yyyy HH:mm"),
                Status = Enum.GetName(typeof(UserStatus), user.Status) ?? "unknow"  
            });
        }
        return list;
    }

    [HttpGet("{name}")]
    public UserAccount? Get(string name) => users.GetFirstRecord(x => x.UserName == name);

    [HttpPut]
    public UserWrapperModel? Put([FromBody] UserWrapperModel user) 
    {
        if(user == default) return null;
        users.SaveRecord(new UserAccount 
        {
            Id = null,
            UserName = user.UserName,
            NormalizedUserName = user.UserName.ToUpper(),
            Email = user.Email,
            NormalizedEmail = user.Email.ToUpper(),
        });
        return user;
        
    }

    // [HttpPost]
    // public UserWrapperModel? Post([FromBody] UserWrapperModel user)
    // {
    //     return Put(user);
    // }

    // [HttpPatch("{name}")]
    // public StatusCodeResult Patch(string name, [FromBody] JsonPatchDocument<UserAccount> patch)
    // {
    //     UserAccount? user = Get(name);
    //     if(user == default) return NotFound();
    //     patch.ApplyTo(user);
    //     return Ok();
    // }

    // [HttpDelete("{name}")]
    // public void Delete(string name) => users.RemoveRecord()
}
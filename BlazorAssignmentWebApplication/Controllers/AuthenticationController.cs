using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorAssignmentWebApplication.Data;
using BlazorAssignmentWebApplication.Data.Model;
using Microsoft.AspNetCore.Mvc;



namespace BlazorAssignmentWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController :  ControllerBase
    {
        
    private readonly IUserService userService = new InMemoryUserService();
    
    
    [HttpGet("/login")]
    public async Task<ActionResult<User>> LoginUser(string username, string password) {
        if (string.IsNullOrEmpty(username)) return BadRequest("Enter username");
        if (string.IsNullOrEmpty(password)) return BadRequest("Enter password");
       
        /*var identity = new ClaimsIdentity();*/
      
        /*if (cachedUser == null) {*/

        try
        {
            User user = new User();
            user =  userService.ValidateUser(username, password); //reading from file should be async????
            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
       
        /*} else {
            identity = SetupClaimsForUser(cachedUser);
        }*/
        
        
    }

    /*public User ValidateLogin(string username, string password) {
        Console.WriteLine("Validating log in");
        User user = new User();

        ClaimsIdentity identity = new ClaimsIdentity();
        try {
             user = userService.ValidateUser(username, password);
        } catch (Exception e) {
            throw e;
        }

        return user;

    }*/


    /*private ClaimsIdentity SetupClaimsForUser(User user) {
        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
        claims.Add(new Claim("Role", user.Role));
        claims.Add(new Claim("City", user.City));
        claims.Add(new Claim("Domain", user.Domain));
        claims.Add(new Claim("BirthYear", user.BirthYear.ToString()));
        claims.Add(new Claim("Level", user.SecurityLevel.ToString()));

        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
        return identity;
    }*/
}
}
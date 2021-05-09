using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using LoginExample.Data.HttpServices;
using LoginExample.Data.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace LoginExample.Authentication {
public class CustomAuthenticationStateProvider : AuthenticationStateProvider {
    private readonly IJSRuntime _jsRuntime;

    private User _cachedUser;
    private readonly IUsersHttpService _usersHttpService;

    public CustomAuthenticationStateProvider(IJSRuntime jsRuntime,IUsersHttpService usersHttpService)
    {
        _jsRuntime = jsRuntime;
        _usersHttpService = usersHttpService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
        var identity = new ClaimsIdentity();
        if (_cachedUser == null) {
            string userAsJson = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
            if (!string.IsNullOrEmpty(userAsJson)) {
                var tmp = JsonSerializer.Deserialize<User>(userAsJson);
                ValidateLogin(tmp.UserName, tmp.Password);
            }
        } else {
            identity = SetupClaimsForUser(_cachedUser);
        }

        ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
        return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
    }

    public  async void ValidateLogin(string username, string password) {
        Console.WriteLine("Validating log in");
        if (string.IsNullOrEmpty(username)) throw new Exception("Enter username");
        if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");

        ClaimsIdentity identity;
        try {
            
            var user = await _usersHttpService.GetUser(username, password);
            identity = SetupClaimsForUser(user);
            var serialisedData = JsonSerializer.Serialize(user);
          await  _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
            _cachedUser = user;
        } catch (Exception e) {
            //TODO error handling
            throw e;
        }

        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
    }

    public void Logout() {
        _cachedUser = null;
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    private ClaimsIdentity SetupClaimsForUser(User user) {
        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
        claims.Add(new Claim("Role", user.Role));
        claims.Add(new Claim("City", user.City));
        claims.Add(new Claim("Domain", user.Domain));
        claims.Add(new Claim("BirthYear", user.BirthYear.ToString()));
        claims.Add(new Claim("Level", user.SecurityLevel.ToString()));

        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
        return identity;
    }
}
}
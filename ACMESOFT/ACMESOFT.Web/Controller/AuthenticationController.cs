using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


public class AuthenticationController : Controller
{
    private readonly HttpContext httpContext = null;

    public AuthenticationController(ACMESOFT.Entity.User user, HttpContext _httpContext)
    {
        httpContext = _httpContext;

        this.GenerateClaim(user);
    }
    public AuthenticationController(HttpContext _httpContext)
    {
        httpContext = _httpContext;
        this.SignOutClaim();
    }

    private void GenerateClaim(ACMESOFT.Entity.User user)
    {
        var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserId)),
                        new Claim(ClaimTypes.Name, user.UserName)
                };
        //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity   
        var principal = new ClaimsPrincipal(identity);
        //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
        httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
        {
            IsPersistent = true,
            ExpiresUtc = DateTime.Now.AddHours(24)
        }).Wait();

    }

    private void SignOutClaim()
    {
        httpContext.SignOutAsync();
    }
}

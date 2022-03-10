using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PersonManagement.Model.Login_Model;
using PersonService.Abstractions;
using PersonService.Implementations;
using PersonService.Model;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MyPersonManagement.Infastucture.Handler
{
    //public class BasicAutenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    //{
    //    //    private readonly IUserService _userService;

    //    //    public BasicAutenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,  ILoggerFactory factory,UrlEncoder encoder,ISystemClock clock,IUserService userService):base(options,factory,encoder,clock)
    //    //    {
    //    //        _userService = userService;
    //    //    }


    //    //    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    //    //    {
    //    //        var endpoint = Context.GetEndpoint();

    //    //        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>()!=null)
    //    //        {
    //    //           return AuthenticateResult.NoResult();
    //    //        }

    //    //        if (!Request.Headers.ContainsKey("Authorization"))
    //    //        {
    //    //          return  AuthenticateResult.Fail("Missing Authorization");
    //    //        }

    //    //        User user = null;

    //    //        try
    //    //        {
    //    //            var authHeader = AuthenticationHeaderValue.Parse( Request.Headers["Authorization"]);
    //    //            var credintialBytes = Convert.FromBase64String(authHeader.Parameter);
    //    //            var credential = Encoding.ASCII.GetString(credintialBytes).Split(new[] { ':' }, 2);

    //    //            var username = credential[0];
    //    //            var password = credential[1];

    //    //           user = await _userService.Login(username, password);

    //    //            if (user == null)
    //    //            {
    //    //               return AuthenticateResult.Fail("Incorrect name or password");
    //    //            }
    //    //        }
    //    //        catch (Exception ex)
    //    //        {

    //    //            AuthenticateResult.Fail("Missing Authorization"); 
    //    //        }

    //    //        var claims = new []
    //    //        {
    //    //            new Claim(ClaimTypes.Name,user.UserName),
    //    //            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
    //    //            new Claim("postiction", "admin")

    //    //        };

    //    //        var identity = new ClaimsIdentity(claims, Scheme.Name);
    //    //        var principal = new ClaimsPrincipal(identity);
    //    //        var ticket =new  AuthenticationTicket(principal, Scheme.Name);

    //    //        return AuthenticateResult.Success(ticket);
    //    //    }
    //}
}

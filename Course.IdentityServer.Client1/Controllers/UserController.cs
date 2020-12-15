using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;


namespace Course.IdentityServer.Client1.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            //no longer, we have a user in this scope 
            //User.Claims;
            //User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            //if we wants more info about users, we can use userInfo Endpoint
            
            return View();
        }
        public async Task LogOut()
        {
            await HttpContext.SignOutAsync("myCookies");
            await HttpContext.SignOutAsync("oidc");
        }

        public async Task<IActionResult> GetRefleshToken()
        {
            HttpClient httpClient = new HttpClient();
            var disco = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                //logging
            }
            var refleshToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
            RefreshTokenRequest refleshTokenRequest = new RefreshTokenRequest();
            refleshTokenRequest.ClientId = _configuration["ClientMvc:ClientId"];
            refleshTokenRequest.ClientSecret = _configuration["ClientMvc:ClientSecret"];
            refleshTokenRequest.RefreshToken = refleshToken;
            refleshTokenRequest.Address = disco.TokenEndpoint;
            //not required username and password bcs there are defined in cookies

            var token = await httpClient.RequestRefreshTokenAsync(refleshTokenRequest);

            if (token.IsError)
            {
                //loggin
                //redirection
            }

            var tokens = new List<AuthenticationToken>()
            {
                new AuthenticationToken{Name = OpenIdConnectParameterNames.IdToken,Value = token.IdentityToken},
                new AuthenticationToken{Name = OpenIdConnectParameterNames.RefreshToken,Value = token.RefreshToken},
                new AuthenticationToken{Name = OpenIdConnectParameterNames.AccessToken,Value = token.AccessToken},
                new AuthenticationToken{Name = OpenIdConnectParameterNames.ExpiresIn,Value =DateTime.UtcNow.AddSeconds(token.ExpiresIn).ToString("o",CultureInfo.InvariantCulture)},

            };

            var authenticationResult = await HttpContext.AuthenticateAsync();
            var properties = authenticationResult.Properties;
            properties.StoreTokens(tokens);

            await HttpContext.SignInAsync("myCookies", authenticationResult.Principal, properties);

            return RedirectToAction("Index");
        }

        [Authorize(Roles="admin")]
        public IActionResult AdminAction()
        {
            return View();
        }
        [Authorize(Roles = "customer,admin")]
        public IActionResult CustomerAction()
        {
            return View();
        }
    }
}

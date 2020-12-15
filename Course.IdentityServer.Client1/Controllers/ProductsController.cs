using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Course.IdentityServer.Client1.Models;
using Course.IdentityServer.Client1.Services;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;

namespace Course.IdentityServer.Client1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiResourceHttpClient _apiResourceHttpClient;
        public ProductsController(IConfiguration configuration, IApiResourceHttpClient apiResourceHttpClient)
        {
            _configuration = configuration;
            _apiResourceHttpClient = apiResourceHttpClient;
        }
        public async Task<IActionResult> Index()
        {
            //require http client object for requests
            HttpClient httpClient = new HttpClient();
            //we're gets information about auth server such as scopes and base url
            var discovery = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");

            if (discovery.IsError)
            {
                //logging
            }

            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest();
            clientCredentialsTokenRequest.ClientId = _configuration["Client:ClientId"];//değiştirilecek
            clientCredentialsTokenRequest.ClientSecret = _configuration["Client:ClientSecret"];
            //We define address (https://base-ulr/connect/token) where we will receive token   
            clientCredentialsTokenRequest.Address = discovery.TokenEndpoint;
            //And sending request
            var token = await httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);

            if (token.IsError)
            {
                //logging
            }
            //at now we have a access token. We can request to api. Also require authorization type in header
            httpClient.SetBearerToken(token.AccessToken);

            var response = await httpClient.GetAsync("https://localhost:5016/api/product/getproducts");
            List<Product> products = new List<Product>();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            else
            {
                //logging
            }
            return View(products);
        }
        [Authorize]
        public async Task<IActionResult> Index2()
        {
            //require http client object for requests
            HttpClient httpClient = new HttpClient();
            //we're gets information about auth server such as scopes and base url
            var discovery = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");

            if (discovery.IsError)
            {
                //logging
            }

            //already we have access token in cookie
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            //at now we have a access token. We can request to api. Also require authorization type in header
            httpClient.SetBearerToken(accessToken);

            var response = await httpClient.GetAsync("https://localhost:5016/api/product/getproducts");
            List<Product> products = new List<Product>();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            else
            {
                //logging
            }
            return View(products);
        }

        [Authorize]
        public async Task<IActionResult> BestPractice()
        {
          
            var response = await _apiResourceHttpClient.GetHttpClient().Result.GetAsync("https://localhost:5016/api/product/getproducts");
            List<Product> products = new List<Product>();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            else
            {
                //logging
            }
            return View(products);
        }
    }
}

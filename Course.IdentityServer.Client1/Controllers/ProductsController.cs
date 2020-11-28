using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Course.IdentityServer.Client1.Models;
using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Course.IdentityServer.Client1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();
            var discovery = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (discovery.IsError)
            {
                //logging
            }
            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest();
            clientCredentialsTokenRequest.ClientId = _configuration["Client:ClientId"];
            clientCredentialsTokenRequest.ClientSecret = _configuration["Client:ClientSecret"];
            clientCredentialsTokenRequest.Address = discovery.TokenEndpoint;
            var token = await httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);
            if (token.IsError)
            {
                //logging
            }
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
    }
}

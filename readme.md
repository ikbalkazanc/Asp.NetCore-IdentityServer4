<div align="center">
<img src="https://github.com/ikbalkazanc/Asp.NetCore-IdentityServer4/blob/master/images/identityserver4.jpg" alt="Logo" width="50%" height="50%">
</div>

# Identity Server
## Instruction
I tried explain identity server. in the enf of article you will have knowledge of many significant topics like grants and endpoint. Also i explained client credentials grant step by step. Could be some grammer and word mistakes because of my english. I hope it's understandable. Good luck 🍀      
## What is Identity Server 4 
Identity server is provide many easiness to us. We can define authorization rules. And we can assing this rules to APIs and Clients. As example, client1 can do just read process in Apı2. It provides many facilities like this. We will talk about in detail later. Indentity Server is use OAuth 2 and OpenId Connect protocols. So we are required to know what they are.
#### OAuth 2.0 (Authorization)
OAuth protocols is provide secure authorization for systems like web, mobile. We are seeing many instances in daily life as sign in to any web sites. I will tell many information about OAuth. if you want see about it You can examine <a href="https://oauth.net/2/">here</a>. 
<div align="center">
<img src="https://github.com/ikbalkazanc/Asp.NetCore-IdentityServer4/blob/master/images/bootstrap-social.png" alt="Logo" width="20%" height="20%">
 </div>

#### OpenId Connect (Authentication)
OpenId Connect allows Clients to verify the identity of the End-User based on the authentication performed by an Authorization Server. if you want see about it You can examine <a href="https://openid.net/connect/">here</a>. 

## Some Important Terms
<strong>Resources :</strong> Resources are a series of identity. We will define identity rules inside resource. And we are assign to clients them. As example, we will do define just reading to in API 1 for Client1.  
<strong>Identity Token :</strong> Information about how and when the user authenticated. It can contain additional identity data.      
<strong>Access Token :</strong> We are give token to request. These are contained in client names, base urls, scopes, private key and public key. There are a lot of details, but for now, these concern us. Also below is a sample token.
```
eyJhbGciOiJSUzI1NiIsImtpZCI6IjJDQzA3MEI2NjMxRTUzMEY0MjkwRUJEOEY0MzI4QzQ1IiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2MDYzOTEwNzYsImV4cCI6MTYwNjM5NDY3NiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6InJlc291cmNlX2FwaTEiLCJjbGllbnRfaWQiOiJDbGllbnQxIiwianRpIjoiQjE1N0JFRjc1MkUxMzQzNzlGOUFFM0I5MzJCNkYzNTIiLCJpYXQiOjE2MDYzOTEwNzYsInNjb3BlIjpbImFwaTEucmVhZCIsImFwaTEudXBkYXRlIiwiYXBpMS53cml0ZSJdfQ.dQYwd9JLt9YGvhkxp36GSNRttSI9rYoz2KctY0FFD2XQ5X0pvyLi07FmHJik8zZnXRezXH2txwy9VkbbQ-bwEZ5cWzylmuS2fXKkUTr2wyQhV6_tyPOjluGrKBcUHkB1cL_ypXRm6ijy-i1XxVuGNjPiT0LZH9aB69RaeQn4khWAY27VFVucWkPhf3nkTvH7dOKPu-cK8cmpLPkQa7BT08cxddOqB8kK_9YZEp3wyvjTBXF_V0GfxvQfMtEp60LBx2gfXJGHm1PMftF5k0oTCZB1xYWwR_P2HY-3Edl0AwZSvz80-v2GTSm2q9RWfuLSlZVB5AvAmQyh0OfyNUx7XA
```
## OAuth 2.0 Grands (Flows)
#### Authorization Code Grant
This is so complicated. But in sum, Resource owner(user) is sending request to identity server with client identifier(username&password). This server can be facebook, twitter authorization servers(identity server) etc. Then server checking client identifier. if it's right it send authorization code(identity token) to client. And when client request to APIs it sending authorization code to authorization servers. Authorization servers is sending back access token and client credential. anymore client can be request to api with access token.
<div align="center">
 <img src="https://github.com/ikbalkazanc/Asp.NetCore-IdentityServer4/blob/master/images/IdentityServer4-Yazi-Serisi-8-Authorization-Code-GrantFlow.png" alt="Logo" width="40%" height="40%">
</div>
You can read more in <a href="https://tools.ietf.org/html/rfc6749#section-4.1">here</a> 

#### Implicit Grant
Implicit grant is such as authorization code grant but have a one difference. It's sending one request to authorization server. Authorization server redirection URI with access token and client credential.    
<div align="center">
 <img src="https://github.com/ikbalkazanc/Asp.NetCore-IdentityServer4/blob/master/images/implicit-spa_4.png" alt="Logo" width="50%" height="50%">
</div>
You can read more in <a href="https://tools.ietf.org/html/rfc6749#section-4.2">here</a> 

#### Resource Owner Credentials Grandt
In this, it sends "resource owner" and "password credentials" information to the authorization server. Authorization server redirection URI with access token and client credential. Such as implicit grant but includes authorization code grant properties.
<div align="center">
 <img src="https://github.com/ikbalkazanc/Asp.NetCore-IdentityServer4/blob/master/images/ropc-flow.png" alt="Logo" width="50%" height="50%">
</div>
You can read more in <a href="https://tools.ietf.org/html/rfc6749#section-4.3">here</a>

#### Client credentials grant
It is the simplest of them all. we are send client authentication to authorization server. Then, server is send back response to client with access token.

<div align="center">
 <img src="https://github.com/ikbalkazanc/Asp.NetCore-IdentityServer4/blob/master/images/ClientCredentials.png" alt="Logo" width="50%" height="50%">
</div>
You can read more in <a href="https://tools.ietf.org/html/rfc6749#section-4.4">here</a>

## Identity Endpoints
Identity server is provide a series endpoints. We will by using them communicate with identity server. We will include Http client then request token and info from server. Below I tried to explain some of the "endpoints" that I think significant. Also you can find out more in <a href="https://identityserver4.readthedocs.io/en/latest/endpoints/discovery.html">here</a>

#### Discovery Endpoint
Discovery endpoint is a information request about auth server. its response json string to us. Has many info inside of discovery. Such as base url, supported scopes, claims, grant types and response types. Below url is discovery endpoint.
````
https://base-url/.well-known/openid-configuration
````
#### User Info Endpoint
We can get information about user idenity from auth server. We need token for this.Also when we get information, some data will be missing. We can set this up in client services. 
```
GET https://base-url/connect/userinfo
Authorization: Bearer <access_token>
```
#### Introspection Endpoint
This time we are checking to token authorize on API as client. of course we're require token and authorization type. Server is send back response to client as true or false.
```
POST https://base-url/connect/introspect
```
## Quickstart UI
A sample UI is exist in identityServer4 github page. I will by using this UI i contunie this project. For this reason required including in the auth server for those who will read the entire blog. You easily can include with powershell.You can visit the github repository for more details in <a href="https://github.com/IdentityServer/IdentityServer4.Quickstart.UI">here</a>. 

## Creating Solution Project
First of all we are need a project template. I will use 2 API, 2 Client and a AuthServer as web application project in my solution. I will tell the whole scenario through these projects. You can examine structure in the repository.
## Client Credentials Grant Application
Let's remember again. What is Client Credentials Grant? We were doing client authentication request to auth server. Then it sending back with Access Token. Hereunder let's create a scenario. We have two client and two API . And we define identity allowance for APIs. such as read or write. as example, client1 can read to API1 and client2 can write to API2. Apart from these, clients cannot access to apıs.
### 1. Configure Sources
We will work in memorylable. For this reason we creating a named `Config.cs` in Auth server project. We define clients, resources and scopes in this class. Actually this code part is so understandable. But still let's explain. We are defining for middleware services. And we are create `ApiScope` list. Then we defining resource for APIs. And clients... 
##### Scopes
```csharp
public static IEnumerable<ApiScope> GerApiScopes()
{
 return new List<ApiScope>
 {
  new ApiScope("api1.read","read permission for API 1"),                
  new ApiScope("api2.write","write permission for API 2"),              
 };
}
```
##### API Resources
```csharp
 public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>
            {
                new ApiResource("resource_api1"){Scopes = {"api1.read"}},
                new ApiResource("resource_api2"){Scopes = {"api2.write"}}
            };
        }
```
##### Clients
```csharp
public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "Client1",
                    ClientName = "Client 1 API app",
                    ClientSecrets = new[] {new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"api1.read"}
                },
                new Client()
                {
                    ClientId = "Client2",
                    ClientName = "Client 2 API app",
                    ClientSecrets = new[] {new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"api2.write"}
                },
                }
            };
        }
```
We defined some resource. On next, there is introducing resources to identity server. We will add service and middleware layer. Also require define grant type for identity server in sevices. 
```csharp
services.AddIdentityServer()
  .AddInMemoryApiResources(Config.GerApiResource())
  .AddInMemoryApiScopes(Config.GerApiScopes())
  .AddInMemoryClients(Config.GetClients())
  .AddDeveloperSigningCredential();
```
<strong>Note :</strong>It's must define after from authorization
```csharp
app.UseIdentityServer();
```
### 2. Client Side Processes
in the next, require to realizationing of client credentials grant algorithm. I tried explain process by process in below. I hope it's apprehensible. 
```csharp
public async Task<IActionResult> Index()
  {
  //require http client object for requests
  HttpClient httpClient = new HttpClient();
  //we're gets information about auth server such as scopes and base url
  var discovery = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");
  
  if (discovery.IsError){/*Logging*/}

  ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest();
  clientCredentialsTokenRequest.ClientId = "Client1";
  clientCredentialsTokenRequest.ClientSecret = "secret";
  //We define address (https://base-ulr/connect/token) where we will receive token   
  clientCredentialsTokenRequest.Address = discovery.TokenEndpoint;
  //And sending request
  var token = await httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);

  if (token.IsError){/*Logging*/}

  //at now we have a access token. We can request to api. Also require authorization type in header
  httpClient.SetBearerToken(token.AccessToken);

  var response = await httpClient.GetAsync("https://localhost:5016/api/product/getproducts");
  List<Product> products = new List<Product>();
  if (response.IsSuccessStatusCode)
  {
  var content = await response.Content.ReadAsStringAsync();
  products = JsonConvert.DeserializeObject<List<Product>>(content);
  }
  else{/*Logging*/}

  return View(products);
}
```
### 3. API Side Processes
Now, We must inform to API project about resources lastly. But after we must include Jwt Token nutget package. Also since it's the middleware level we are adding `app.UseAuthentication()` to configure method. Footnote, authentitcation must be after authorize.    
```csharp
  public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(/*NormalUser*/JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(/*NormalUser*/JwtBearerDefaults.AuthenticationScheme, opt =>
                {
                    opt.Authority = "https://localhost:5001";
                    opt.Audience = "resource_api1";
                });
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("ReadProduct", policy =>
                {
                    policy.RequireClaim("scope", "api1.read");
                });
                opts.AddPolicy("UpdateOrCreate", policy =>
                {
                    policy.RequireClaim("scope", new [] {"api1.update","api1.create"});
                });
            });
            services.AddControllers();
        }
```
in contorller, we can use authorize attribute for action. Or can be direct controller level. if request is not authorized, identity server will return unauthorized status. 
```csharp
[Authorize(Policy = "ReadProduct")]
public IActionResult GetProducts()
{
  return Ok(new List<Product>());
}
```
## Result
We learned many topic about identity server 4. And we solved an example according to the scenario. Now we can code system using client credentials flow with identity server. I didnt mention so about another flows. But you can find many article about its in internet.Thank you for reading. Good luck with coding.  


## Source
https://www.gencayyildiz.com/blog/identityserver4-yazi-serisi-8-authorization-code-grantflow/</br>
https://tools.ietf.org/html/rfc6749</br>
https://identityserver4.readthedocs.io/en/latest/index.html</br>

## Contact
Muhammet İkbal KAZANCI - [LinkedIn](https://www.linkedin.com/in/ikbalkazanc/) - mi.kazanci@hotmail.com

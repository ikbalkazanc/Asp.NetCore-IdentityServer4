using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Course.IdentityServer.AuthServer
{
    public static class Config
    {
        //define rules resources
        public static IEnumerable<ApiResource> GerApiResource()
        {
            return new List<ApiResource>
            {
                new ApiResource("resource_api1"){Scopes = {"api1.read","api1.write","api1.update"}},
                new ApiResource("resource_api2"){Scopes = {"api2.read","api2.write","api2.update"}}
            };
        }
        //define rules
        public static IEnumerable<ApiScope> GerApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("api1.read","read permission for API 1"),
                new ApiScope("api1.write","write permission for API 1"),
                new ApiScope("api1.update","update permission for API 1"),
                new ApiScope("api2.read","read permission for API 2"),
                new ApiScope("api2.write","write permission for API 2"),
                new ApiScope("api2.update","update permission for API 2"),
            };
        }


        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                //25.7.22
                new IdentityResources.OpenId(), //sub Id
                new IdentityResources.Profile(),
                new IdentityResource()
                {
                    Name = "CountryAndCity",DisplayName ="Country And City" ,Description = " city and country information of user",
                    UserClaims = new []{"country","city"}
                },
                new IdentityResource()
                {
                    Name = "Roles",DisplayName = "Roles",Description = "user roles",UserClaims = new []{"role"}
                }
            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {
                new TestUser{SubjectId = "1",Username = "mikbal",Password = "1234",Claims = new List<Claim>()
                {
                    new Claim("given_name","ikbal"),
                    new Claim("family_name","kazanci"),
                    new Claim("country","türkey"),
                    new Claim("city","istanbul"),
                    new Claim("role","admin")
                }},
                new TestUser{SubjectId = "2",Username = "pelin",Password = "1234",Claims = new List<Claim>()
                {
                    new Claim("given_name","pelin"),
                    new Claim("family_name","su"),
                    new Claim("country","Turkey"),
                    new Claim("city","Anakara"),
                    new Claim("role","customer")
                }}
            };
        }

        //define clients
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
                    AllowedScopes = {"api1.read","api1.write","api1.update"}
                },
                new Client()
                {
                    ClientId = "Client2",
                    ClientName = "Client 2 API app",
                    ClientSecrets = new[] {new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"api2.read","api2.write","api1.read"}
                },
                new Client()
                {
                    ClientId = "Client1-Mvc",
                    //auth pkce
                    RequirePkce = false,
                    ClientName = "Client1-Mvc mvc app",
                    ClientSecrets = new[] {new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    //front channel
                    RedirectUris = new List<string>{ "https://localhost:5026/signin-oidc" },
                    PostLogoutRedirectUris = new List<string>{"https://localhost:5026/signout-callback-oidc"},
                    AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1.read",
                        "api2.write",
                        "api1.update",
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "CountryAndCity",
                        "Roles"
                    },
                    //default 1 hour
                    AccessTokenLifetime = 2*3600,
                    //allow reflesh token
                    AllowOfflineAccess = true,
                    //use more than one
                    RefreshTokenUsage = TokenUsage.ReUse,
                    //
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    //
                    RequireConsent = true
                },
                new Client()
                {
                    ClientId = "Client2-Mvc",
                    //auth pkce
                    RequirePkce = false,
                    ClientName = "Client2-Mvc mvc app",
                    ClientSecrets = new[] {new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    //front channel
                    RedirectUris = new List<string>{ "https://localhost:5026/signin-oidc" },
                    PostLogoutRedirectUris = new List<string>{"https://localhost:5026/signout-callback-oidc"},
                    AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1.read",
                        "api2.write",
                        "api1.update",
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "CountryAndCity",
                        "Roles"
                    },
                    //default 1 hour
                    AccessTokenLifetime = 2*3600,
                    //allow reflesh token
                    AllowOfflineAccess = true,
                    //use more than one
                    RefreshTokenUsage = TokenUsage.ReUse,
                    //
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    //
                    RequireConsent = true
                }

            };
        }
    }
}

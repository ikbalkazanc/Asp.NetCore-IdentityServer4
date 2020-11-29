using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {
                new TestUser{SubjectId = "1",Username = "mikbal",Password = "1234",Claims = new List<Claim>()
                {
                    new Claim("given_name","ikbal"),
                    new Claim("family_name","kazanci")
                }},
                new TestUser{SubjectId = "2",Username = "pelin",Password = "1234",Claims = new List<Claim>()
                {
                    new Claim("given_name","pelin"),
                    new Claim("family_name","su")
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
                }
            };
        }
    }
}

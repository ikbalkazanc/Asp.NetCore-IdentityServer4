using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

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

        //define clients
        public static IEnumerable<Client> GetClients()
        {
            return  new List<Client>()
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

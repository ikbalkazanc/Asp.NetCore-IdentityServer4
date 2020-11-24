using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace Course.IdentityServer.AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GerApiResoruce()
        {
            return new List<ApiResource>
            {
                new ApiResource("resource_Api1"){Scopes = {"api1.read","api1.write","api1.update"}},
                new ApiResource("resource_api2"){Scopes = {"api2.read","api2.write","api2.update"}}
            };
        }
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
    }
}

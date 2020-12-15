using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.IdentityServer.AuthServer.Model;

namespace Course.IdentityServer.AuthServer.Services
{
    public interface ICustomUserRepository
    {
        Task<bool> Validate(string email,string password);
        Task<CustomUser> FindById(int id);
        Task<CustomUser> FindByEmail(string email);
    }
}

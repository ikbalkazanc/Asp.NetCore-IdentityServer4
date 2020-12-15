using Course.IdentityServer.AuthServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Course.IdentityServer.AuthServer.Services
{
    public class CustomUserRepository : ICustomUserRepository
    {
        private readonly CustomDbContext _context;

        public CustomUserRepository(CustomDbContext context)
        {
            _context = context;
        }
        public  async Task<CustomUser> FindByEmail(string email)
        {
            return await _context.CustomUsers.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<CustomUser> FindById(int id)
        {
            return await _context.CustomUsers.FindAsync(id);
        }

        public async Task<bool> Validate(string email, string password)
        {
            return  await _context.CustomUsers.AnyAsync(x => x.Email == email && x.Password == password);
        }
    }
}

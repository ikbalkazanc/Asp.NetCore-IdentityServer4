using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Extensions;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Course.IdentityServer.AuthServer.Services
{
    public class CustomProfileService : IProfileService
    {
        private readonly ICustomUserRepository _customUserRepository;
        public CustomProfileService(ICustomUserRepository customUserRepository)
        {
            _customUserRepository = customUserRepository;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subId = context.Subject.GetSubjectId();
            var user = await _customUserRepository.FindById(int.Parse(subId));
            var claims = new List<Claim>()
            {
               new Claim(JwtRegisteredClaimNames.Email,user.Email),
               new Claim("username",user.UserName),
               new Claim("city",user.City)

            };
            if (user.Id == 1)
            {
                claims.Add(new Claim("role", "admin"));
            }
            else
            {
                claims.Add(new Claim("role","customer"));
            }
            context.AddRequestedClaims(claims);

            //claimlerin jwtnin içerisinde gözükmesini sağlar ama sağlıklı değildir.
            context.IssuedClaims = claims;
        }
        //kullanıcı varmı
        public async Task IsActiveAsync(IsActiveContext context)
        {
            var userId = context.Subject.GetSubjectId();
            var user = await _customUserRepository.FindById(int.Parse(userId));
            context.IsActive = user != null ? true : false;

        }
    }
}

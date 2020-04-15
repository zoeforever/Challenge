using Entities;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationCenter.Classes
{
    public class ProfileService : IProfileService
    {
        IUserService userService;
        public ProfileService(IUserService _userService)
        {
            userService = _userService;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var users = await userService.GetAll();

            var claims = new List<Claim> {
                new Claim(JwtClaimTypes.Subject,user.Id.ToString()),
                new Claim(JwtClaimTypes.PreferredUserName,user.UserName)
            };
            context.IssuedClaims = claims;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}

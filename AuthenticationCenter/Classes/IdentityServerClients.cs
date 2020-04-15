using Entities;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationCenter.Classes
{
    public class IdentityServerClients
    {
        IServiceProvider serviceProvider;
        public IdentityServerClients(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
        }
        public static IEnumerable<Client> GetClients()
        {
            var list = new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = { "WebAppAPI" },//添加允许访问API范围
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 60 * 60,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    SlidingRefreshTokenLifetime = 60 * 30,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    ClientSecrets =
                    {
                        new Secret("challenge".Sha256())
                    }
                }
            };

            return list;
        }
        public async Task<List<TestUser>> GetUsers()
        {
            List<TestUser> Testers = new List<TestUser>()
            {
                new TestUser()
                {
                    SubjectId = "1",
                    Password ="123456",
                    Username = "zs"
                },
                new TestUser()
                {
                    SubjectId = "2",
                    Password ="123456",
                    Username = "ls"
                }
            };

            return Testers;
            IUserService userService = (IUserService)serviceProvider.GetService(typeof(IUserService));
            var users = await userService.GetAll();
            List<TestUser> testUsers = new List<TestUser>();
            foreach (var item in users)
            {
                testUsers.Add(new TestUser { Username = item.UserName, Password = item.Password });
            }
            return testUsers;
        }
    }
}

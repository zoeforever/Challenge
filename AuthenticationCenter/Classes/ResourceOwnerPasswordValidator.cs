using Entities;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthenticationCenter.Classes
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private string baseUserServiceUrl;
        public ResourceOwnerPasswordValidator(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            baseUserServiceUrl = _configuration["MySqlServiceUrl"] + "/api/Users";
        }

        /// <summary>
        /// Validates the resource owner password credential
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {

            User u = null;
            var request = new HttpRequestMessage(HttpMethod.Get, baseUserServiceUrl + "/" + context.UserName);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                u = await response.Content.ReadAsAsync<User>();
            }
            if (u == null)
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    "用户名或密码错误"
                    );
            }
            else
            {
                if (u.Password == context.Password)
                {
                    context.Result = new GrantValidationResult(u.UserId.ToString(), OidcConstants.AuthenticationMethods.Password, DateTime.UtcNow);
                }
                else
                {
                    context.Result = new GrantValidationResult(
                        TokenRequestErrors.InvalidGrant,
                        "用户名或密码错误"
                        );
                }
            }
        }
    }
}

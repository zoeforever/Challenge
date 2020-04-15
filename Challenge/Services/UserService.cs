using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace challenge.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private string baseUserServiceUrl;
        private string ids4Url;
        public UserService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            baseUserServiceUrl = _configuration["MySqlServiceUrl"] + "/api/Users";
            ids4Url = _configuration["Ids4Url"];
        }

        public async Task<User> AddUser(User user)
        {
            User newUser = null;
            var client = _clientFactory.CreateClient();
            string postData = "UserName=" + user.UserName + "&Password=" + user.Password + "&Name=" + user.Name;
            var httpContent = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await client.PostAsync(baseUserServiceUrl, httpContent);
            if (response.IsSuccessStatusCode)
            {
                newUser = await response.Content.ReadAsAsync<User>();
            }
            return newUser;
        }

        public async Task<List<User>> GetAll()
        {
            List<User> users = null;
            var request = new HttpRequestMessage(HttpMethod.Get, baseUserServiceUrl);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<List<User>>();
            }
            return users;
        }

        public async Task<User> GetUserByUsername(string userName)
        {
            User user = null;
            var request = new HttpRequestMessage(HttpMethod.Get, baseUserServiceUrl + "/" + userName);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            return user;
        }

        public async Task<Token> IsUserValid(User user)
        {
            Token token = null;
            var client = _clientFactory.CreateClient();
            string postData = "grant_type=password&username=" + user.UserName + "&password=" + user.Password + "&scope=WebAppAPI&client_id=client&client_secret=challenge";
            var httpContent = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await client.PostAsync(ids4Url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                token = await response.Content.ReadAsAsync<Token>();
            }
            return token;
        }
    }
}

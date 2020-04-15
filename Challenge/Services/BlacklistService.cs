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
    public class BlacklistService : IBlacklistService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private string baseBlacklistServiceUrl;
        public BlacklistService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            baseBlacklistServiceUrl = _configuration["MySqlServiceUrl"] + "/api/Blacklists";
        }

        public async Task<Blacklist> AddBlacklist(Blacklist blacklist)
        {
            Blacklist newBlacklist = null;
            var client = _clientFactory.CreateClient();
            string postData = "Ip=" + blacklist.Ip + "&Createtime=" + blacklist.Createtime;
            var httpContent = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await client.PostAsync(baseBlacklistServiceUrl, httpContent);
            if (response.IsSuccessStatusCode)
            {
                newBlacklist = await response.Content.ReadAsAsync<Blacklist>();
            }
            return newBlacklist;
        }


        public async void DeleteBlacklist(string ip)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, baseBlacklistServiceUrl + "/" + ip);
            var client = _clientFactory.CreateClient();
            await client.SendAsync(request);
        }


        public async Task<Blacklist> GetBlacklistByIp(string ip)
        {
            Blacklist blacklist = null;
            var request = new HttpRequestMessage(HttpMethod.Get, baseBlacklistServiceUrl + "/" + ip);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                blacklist = await response.Content.ReadAsAsync<Blacklist>();
            }
            return blacklist;
        }


        public async Task<List<Blacklist>> GetAll()
        {
            List<Blacklist> blacklists = null;
            var request = new HttpRequestMessage(HttpMethod.Get, baseBlacklistServiceUrl);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                blacklists = await response.Content.ReadAsAsync<List<Blacklist>>();
            }
            return blacklists;
        }
    }
}

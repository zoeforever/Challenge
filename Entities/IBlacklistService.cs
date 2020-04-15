using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IBlacklistService
    {
        Task<List<Blacklist>> GetAll();
        Task<Blacklist> GetBlacklistByIp(string ip);
        Task<Blacklist> AddBlacklist(Blacklist blacklist);
        void DeleteBlacklist(string ip);
    }
}

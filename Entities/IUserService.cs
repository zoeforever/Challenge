using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetUserByUsername(string userName);
        Task<User> AddUser(User user);
        Task<Token> IsUserValid(User user);
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;
using LoginExample.Data.Model;

namespace LoginExample.Data.HttpServices
{
    public interface IUsersHttpService
    {
        public Task<User> GetUser(string username, string password);
    }
}
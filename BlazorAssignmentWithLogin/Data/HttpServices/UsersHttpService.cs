using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LoginExample.Data.Model;

namespace LoginExample.Data.HttpServices
{
    public class UserHttpService : IUsersHttpService
    {
        
        private readonly HttpClient _httpClient;


        public UserHttpService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        
        public async Task<User> GetUser(string username, string password)
        {
            
            var url = "https://localhost:5001/login?username=" + username + "&password=" + password;
            var resp =  await   _httpClient.GetAsync(url);
            var user = resp.Content.ReadFromJsonAsync<User>().Result;
            return user;
        }
    }
}
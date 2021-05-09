using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LoginExample.Data.Model;
using LoginExample.Pages;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LoginExample.Data.HttpServices
{
    public class AdultsHttpServices : IAdultsHttpServices
    {
        private readonly HttpClient _httpClient;

        public AdultsHttpServices(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<Adult>> GetAdults()
        {
            return await _httpClient.GetFromJsonAsync<IList<Adult>>("/Adults");
        }

        public async Task AddAdult(Adult adult)
        {
            await _httpClient.PostAsJsonAsync("/adults", adult);
        }
        
        public async Task EditAdult(Adult adult)
        {
            await _httpClient.PutAsJsonAsync("/adults", adult);
        }
        public async Task<Adult> GetAdult(int id)
        {
           return await _httpClient.GetFromJsonAsync<Adult>("/adults/"+id);
        }
        public async Task DeleteAdult(int id)
        {
             await _httpClient.DeleteAsync("/adults/"+id);
        }
        
    }
}
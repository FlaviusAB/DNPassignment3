using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LoginExample.Data.Model;

namespace LoginExample.Data.HttpServices
{
    public interface IAdultsHttpServices
    {
        public Task<IEnumerable<Adult>> GetAdults();
        public Task AddAdult(Adult adult);
        public Task EditAdult(Adult adult);

        public Task<Adult> GetAdult(int id);
        public Task DeleteAdult(int id);

    }
}
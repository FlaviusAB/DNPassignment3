using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAssignmentWebApplication.Data.Model;

namespace BlazorAssignmentWebApplication.repository
{
    public interface IAdultRepo
    {
        Task Create(Adult adult);
        Task Update(Adult adult);
        Task<Adult> GetAdult(int id);
        Task Delete(int id);
        Task<IReadOnlyCollection<Adult>> GetAllAdults();

    }
}
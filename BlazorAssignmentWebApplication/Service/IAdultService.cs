using System.Collections.Generic;
using BlazorAssignmentWebApplication.Data.Model;
using System.Threading.Tasks;

namespace BlazorAssignmentWebApplication.Service
{
    public interface IAdultService
    {
        Task Create(Adult adult);
        Task Delete(int id);
        Task<Adult> Read(int id);
        Task Update(Adult adult);
        Task<IReadOnlyCollection<Adult>> GetAllAdults();
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAssignmentWebApplication.Data.Model;
using BlazorAssignmentWebApplication.repository;

namespace BlazorAssignmentWebApplication.Service
{
    public class AdultService : IAdultService
    {
        private IAdultRepo _adultRepo;

        public AdultService(IAdultRepo repo)
        {
            _adultRepo = repo;
        }

        public async Task Create(Adult adult)
        {
            await _adultRepo.Create(adult);
        }

        public async Task Update(Adult adult)
        {
            await _adultRepo.Update(adult);
        }

        public async Task<Adult> Read(int id)
        {
            var adult = await _adultRepo.GetAdult(id);
            return adult;
        }

        public async Task Delete(int id)
        {
            await _adultRepo.Delete(id);
        }

        public async Task<IReadOnlyCollection<Adult>> GetAllAdults()
        {
            var adults = await _adultRepo.GetAllAdults();
            return adults;
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAssignmentWebApplication.Data.Model;
using BlazorAssignmentWebApplication.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlazorAssignmentWebApplication.repository
{
    public class AdultRepo : IAdultRepo
    {
        private DatabaseContext _databaseContext;

        public void AdultRep(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }
        
        public async Task Create(Adult adult)
        {
           await _databaseContext.Persons.AddAsync(adult);
           await _databaseContext.SaveChangesAsync();
        }

        public async Task Update(Adult adult)
        {
             _databaseContext.Update(adult);
             await _databaseContext.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var adult = await _databaseContext.Persons.FirstOrDefaultAsync( x =>x.Id==id);
            _databaseContext.Remove(adult);
           await _databaseContext.SaveChangesAsync();
        }

        public async Task<Adult> GetAdult(int id)
        {
            var adult = await _databaseContext.Adults.FirstOrDefaultAsync( x =>x.Id==id);
            return adult;

        }
        public async Task<IReadOnlyCollection<Adult>> GetAllAdults()
        {
            var adults =await _databaseContext.Adults.ToListAsync();
            return adults;
        }
    }
   
}
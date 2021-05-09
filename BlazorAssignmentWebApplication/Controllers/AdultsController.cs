
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAssignmentWebApplication.Data.Model;
using BlazorAssignmentWebApplication.Data.Persistence;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorAssignmentWebApplication.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private readonly IFileContext _fileContextProvider;
        
        private IList<Adult> _adultList;

        public AdultsController(IFileContext fileContext)
        {
            _fileContextProvider = fileContext;
        }

        [HttpGet]
        public IList<Adult> Get()
        {
            _adultList = _fileContextProvider.Adults;
            
            return _adultList;
        }

        [HttpPost]
        public async Task<ActionResult> AddAdult(Adult adult)
        {
        
            _fileContextProvider.Adults.Add(adult);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> EditAdult(Adult adult)
        {
            var existingAdult = _fileContextProvider.Adults.FirstOrDefault(x => x.Id == adult.Id);
            _fileContextProvider.Adults.Remove(existingAdult);
            _fileContextProvider.Adults.Add(adult);
            _fileContextProvider.SaveChanges();
            return Ok(adult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Adult>> GetAdult(int id)
        {
            var existingAdult = _fileContextProvider.Adults.FirstOrDefault(x => x.Id == id);
            return Ok(existingAdult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdult(int id)
        {
            var existingAdult =  _fileContextProvider.Adults.FirstOrDefault(x => x.Id == id);
            _fileContextProvider.Adults.Remove(existingAdult);
            return Ok();
        }
        
      
    }
}
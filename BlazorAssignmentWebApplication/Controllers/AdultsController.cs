
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAssignmentWebApplication.Data.Model;
using BlazorAssignmentWebApplication.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAssignmentWebApplication.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class AdultsController : ControllerBase
    {

        private readonly IAdultService _adultService;
        

        public AdultsController(IAdultService adultService)
        {
            _adultService = adultService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Adult>>> GetAll()
        {
            var adultList = await _adultService.GetAllAdults();
            return Ok(adultList);
        }

        [HttpPost]
        public async Task<ActionResult> AddAdult(Adult adult)
        {
        
            await _adultService.Create(adult);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> EditAdult(Adult adult)
        {
            await _adultService.Update(adult);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Adult>> GetAdult(int id)
        {
            var adult = await _adultService.Read(id);
            return Ok(adult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdult(int id)
        {
            await _adultService.Delete(id);
            return Ok();
        }
        
      
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_Models.Model;
using MS_Models.ViewModel;
using MS_Services.CampusService;

namespace MS_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampusController : ControllerBase
    {
        private readonly ICampusService campusService;
        public CampusController(ICampusService campusService)
        {
            this.campusService = campusService;
        }

        [HttpGet("GetCampus")]
        public async Task<IActionResult> GetCampus()
        {
            if (ModelState.IsValid)
            {
                var result = await campusService.GetCampusAsync();
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpGet("GetByCampusId")]
        public async Task<IActionResult> GetByCampusId(int CampusId)
        {
            if (ModelState.IsValid)
            {
                var result = await campusService.GetByCampusIdAsync(CampusId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost("AddCampus")]
        public async Task<IActionResult> AddCampus(CampusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await campusService.AddCampusAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPut("UpdateCampus")]
        public async Task<IActionResult> UpdateCampus(Campus model)
        {
            if (ModelState.IsValid)
            {
                var result = await campusService.UpdateCampusAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpDelete("DeleteCampus")]
        public async Task<IActionResult> DeleteCampus(int CampusId)
        {
            if (ModelState.IsValid)
            {
                var result = await campusService.DeleteCampusAsync(CampusId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }
    }
}

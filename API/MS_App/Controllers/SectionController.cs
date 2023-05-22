using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_Models.Model;
using MS_Models.ViewModel;
using MS_Services.SectionService;

namespace MS_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService secService;
        public SectionController(ISectionService secService)
        {
            this.secService = secService;
        }

        [HttpGet("GetSection")]
        public async Task<IActionResult> GetSection()
        {
            if (ModelState.IsValid)
            {
                var result = await secService.GetSectionAsync();
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpGet("GetBySectionId")]
        public async Task<IActionResult> GetBySectionId(int SecId)
        {
            if (ModelState.IsValid)
            {
                var result = await secService.GetBySectionIdAsync(SecId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost("AddSection")]
        public async Task<IActionResult> AddSection(SectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await secService.AddSectionAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPut("UpdateSection")]
        public async Task<IActionResult> UpdateSection(Section model)
        {
            if (ModelState.IsValid)
            {
                var result = await secService.UpdateSectionAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpDelete("DeleteSection")]
        public async Task<IActionResult> DeleteSection(int SecId)
        {
            if (ModelState.IsValid)
            {
                var result = await secService.DeleteSectionAsync(SecId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }
    }
}

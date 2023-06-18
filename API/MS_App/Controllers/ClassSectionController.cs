using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_Models.Model;
using MS_Models.ViewModel;
using MS_Services.ClassSectionService;

namespace MS_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassSectionController : ControllerBase
    {
        private readonly IClassSectionService classSectionService;
        public ClassSectionController(IClassSectionService classSectionService)
        {
            this.classSectionService = classSectionService;
        }

        [HttpGet("GetClassSection")]
        public async Task<IActionResult> GetCampus()
        {
            if (ModelState.IsValid)
            {
                var result = await classSectionService.GetClassSectionAsync();
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpGet("GetByClassSectionId")]
        public async Task<IActionResult> GetByClassId(int ClassSecId)
        {
            if (ModelState.IsValid)
            {
                var result = await classSectionService.GetByClassSectionIdAsync(ClassSecId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost("AddClassSection")]
        public async Task<IActionResult> AddClassSection(AddClassSectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await classSectionService.AddClassSectionAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPut("UpdateClassSection")]
        public async Task<IActionResult> UpdateClassSection(ClassSection model)
        {
            if (ModelState.IsValid)
            {
                var result = await classSectionService.UpdateClassSectionAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpDelete("DeleteClassSection")]
        public async Task<IActionResult> DeleteClassSection(int ClassSecId)
        {
            if (ModelState.IsValid)
            {
                var result = await classSectionService.DeleteClassSectionAsync(ClassSecId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }
    }
}

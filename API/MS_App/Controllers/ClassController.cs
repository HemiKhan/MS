using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_Models.Model;
using MS_Models.ViewModel;
using MS_Services.ClassService;

namespace MS_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService classService;
        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }

        [HttpGet("GetClass")]
        public async Task<IActionResult> GetCampus()
        {
            if (ModelState.IsValid)
            {
                var result = await classService.GetClassAsync();
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpGet("GetByClassId")]
        public async Task<IActionResult> GetByClassId(int ClassId)
        {
            if (ModelState.IsValid)
            {
                var result = await classService.GetByClassIdAsync(ClassId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost("AddClass")]
        public async Task<IActionResult> AddClass(ClassViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await classService.AddClassAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPut("UpdateClass")]
        public async Task<IActionResult> UpdateClass(Class model)
        {
            if (ModelState.IsValid)
            {
                var result = await classService.UpdateClassAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpDelete("DeleteClass")]
        public async Task<IActionResult> DeleteClass(int ClassId)
        {
            if (ModelState.IsValid)
            {
                var result = await classService.DeleteClassAsync(ClassId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }
    }
}

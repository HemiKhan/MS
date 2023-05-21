using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_Models.ViewModel;
using MS_Services.AdmissionService;
using MS_Services.Seed;

namespace MS_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        private readonly IAdmissionService admissionService;
        public AdmissionController(IAdmissionService admissionService)
        {
            this.admissionService = admissionService;
        }

        [HttpPost("Admission")]
        public async Task<IActionResult> Admission(AdmissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await admissionService.AdmissionAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_Models.Model;
using MS_Models.ViewModel;
using MS_Services.Account;
using MS_Services.OrganizationService;

namespace MS_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService orgServices;
        public OrganizationController(IOrganizationService orgServices)
        {
            this.orgServices = orgServices;
        }

        [HttpGet("GetOrganiation")]
        public async Task<IActionResult> GetOrganiation()
        {
            if (ModelState.IsValid)
            {
                var result = await orgServices.GetOrgainzationAsync();
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpGet("GetByOrgainzationId")]
        public async Task<IActionResult> GetByOrgainzationId(int OrgId)
        {
            if (ModelState.IsValid)
            {
                var result = await orgServices.GetByOrgainzationIdAsync(OrgId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost("AddOrgainzation")]
        public async Task<IActionResult> AddOrgainzation(OrganizationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await orgServices.AddOrgainzationAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPut("UpdateOrgainzation")]
        public async Task<IActionResult> UpdateOrgainzation(Organization model)
        {
            if (ModelState.IsValid)
            {
                var result = await orgServices.UpdateOrgainzationAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpDelete("DeleteOrgainzation")]
        public async Task<IActionResult> DeleteOrgainzation(int OrgId)
        {
            if (ModelState.IsValid)
            {
                var result = await orgServices.DeleteOrgainzationAsync(OrgId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }
    }
}

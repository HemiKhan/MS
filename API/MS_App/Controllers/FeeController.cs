using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_Models.Model;
using MS_Models.ViewModel;
using MS_Services.FeeStrutureService;
using MS_Services.SessionService;

namespace MS_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeController : ControllerBase
    {
        private readonly IFeeStrutureService feeService;
        public FeeController(IFeeStrutureService feeService)
        {
            this.feeService = feeService;
        }

        [HttpGet("GetFeeStructure")]
        public async Task<IActionResult> GetFeeStructure()
        {
            if (ModelState.IsValid)
            {
                var result = await feeService.GetFeeStructureAsync();
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpGet("GetByFeeStructureId")]
        public async Task<IActionResult> GetByFeeStructureId(int FeeId)
        {
            if (ModelState.IsValid)
            {
                var result = await feeService.GetByFeeStructureIdAsync(FeeId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost("AddFeeStructure")]
        public async Task<IActionResult> AddFeeStructure(FeeStructureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await feeService.AddFeeStructureAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPut("UpdateFeeStructure")]
        public async Task<IActionResult> UpdateFeeStructure(FeeStructure model)
        {
            if (ModelState.IsValid)
            {
                var result = await feeService.UpdateFeeStructureAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpDelete("DeleteFeeStructure")]
        public async Task<IActionResult> DeleteFeeStructure(int FeeId)
        {
            if (ModelState.IsValid)
            {
                var result = await feeService.DeleteFeeStructureAsync(FeeId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }
    }
}

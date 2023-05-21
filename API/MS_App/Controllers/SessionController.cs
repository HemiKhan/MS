using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_Models.Model;
using MS_Models.ViewModel;
using MS_Services.SessionService;

namespace MS_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService sessService;
        public SessionController(ISessionService sessService)
        {
            this.sessService = sessService;
        }

        [HttpGet("GetSession")]
        public async Task<IActionResult> GetSession()
        {
            if (ModelState.IsValid)
            {
                var result = await sessService.GetSessionAsync();
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpGet("GetBySessionId")]
        public async Task<IActionResult> GetBySessionId(int SessId)
        {
            if (ModelState.IsValid)
            {
                var result = await sessService.GetBySessionIdAsync(SessId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost("AddSession")]
        public async Task<IActionResult> AddSession(SessionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await sessService.AddSessionAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPut("UpdateSession")]
        public async Task<IActionResult> UpdateSession(Session model)
        {
            if (ModelState.IsValid)
            {
                var result = await sessService.UpdateSessionAsync(model);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpDelete("DeleteSession")]
        public async Task<IActionResult> DeleteSession(int SessId)
        {
            if (ModelState.IsValid)
            {
                var result = await sessService.DeleteSessionAsync(SessId);
                if (result.Status)
                    return Ok(result);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");
        }
    }
}

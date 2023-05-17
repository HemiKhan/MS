using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_Models.Common;
using static MS_Models.Common.ExceptionResponse;

namespace MS_App.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionController : ControllerBase
    {
        [Route("exception")]
        public ExceptionResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error; // Get Exception
            var code = 500;

            if (exception is HttpStatusException httpStatusException)
            {
                code = (int)httpStatusException.Status;
            }

            Response.StatusCode = code;
            return new ExceptionResponse(exception);
        }
    }
}

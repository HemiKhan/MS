using MS_Data.AppContext;
using MS_App.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MS_Models.Model;
using MS_Services.Pagination;
using MS_Models.Common;

namespace MS_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaginationController : ControllerBase
    {
        private readonly IPaginationSerivce paginationSerivce;
        private readonly AppDbContext context;
        public PaginationController(IPaginationSerivce paginationSerivce, AppDbContext context)
        {
            this.paginationSerivce = paginationSerivce;
            this.context = context;
        }


        [HttpGet("GetListWithPagination")]
        public async Task<IActionResult> GetListWithPagination(FilterViewModel filter)
        {
            var result = await paginationSerivce.GetListAsync(filter);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        //[HttpGet("FilterWithoutModel")]
        //public async Task<IActionResult> FilterWithoutModel(FilterViewModel filter)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await paginationSerivce.FilterWithoutModel(filter);
        //        if (result.Status)
        //            return Ok(result);
        //        return BadRequest(result);
        //    }
        //    return BadRequest("Some properties are not valid");
        //}

        //[HttpGet("FilterWithModel")]
        //public async Task<IActionResult> FilterWithModel(FilterViewModel filter)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await paginationSerivce.FilterWithModel(filter);
        //        if (result.Status)
        //            return Ok(result);
        //        return BadRequest(result);
        //    }
        //    return BadRequest("Some properties are not valid");
        //}

    }
}

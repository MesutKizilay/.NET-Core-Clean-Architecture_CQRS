using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new GetListModelQuery() { PageRequest = pageRequest };
            var response = await Mediator.Send(getListModelQuery);
            return Ok(response);
        }

        [HttpPost("GetListByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery = null)
        {
            GetListByDynamicModelQuery getListByDynamicModelQuery = new GetListByDynamicModelQuery() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
            var response = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(response);
        }
    }
}
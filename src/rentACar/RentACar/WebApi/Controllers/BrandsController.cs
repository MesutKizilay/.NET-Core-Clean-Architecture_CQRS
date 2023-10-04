using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            var response = await Mediator.Send(createBrandCommand);
            return Ok(response);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageResuest)
        {
            GetListBrandQuery getListBrandQuery = new GetListBrandQuery() { PageRequest = pageResuest };
            GetListResponse<GetListBrandListItemDto> response = await Mediator.Send(getListBrandQuery);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdBrandQuery getByIdBrandQuery = new GetByIdBrandQuery() { Id = id };
            GetByIdBrandResponse response = await Mediator.Send(getByIdBrandQuery);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
        {
            UpdatedBrandResponse response = await Mediator.Send(updateBrandCommand);
            return Ok(response);
        }
    }
}
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoHouseMediatR.Queries;
using AutoHouseMediatR.Queries.CarQueries;
using AutoHouseMediatR.Queries.DealerQueries;
using MediatR;

namespace AutoHouseMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DealerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllDealers()
        {
            var query = new GetAllDealersQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{dealerId:guid}")]
        public async Task<IActionResult> GetDealer(Guid dealerId)
        {
            var query = new GetDealerByIdQuery(dealerId);
            var result = await _mediator.Send(query);

            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet("{dealerId}/cars")]
        public async Task<IActionResult> GetDealerCars(Guid dealerId)
        {
            var query = new GetDealerCarsQuery(dealerId);
            var result = await _mediator.Send(query);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}

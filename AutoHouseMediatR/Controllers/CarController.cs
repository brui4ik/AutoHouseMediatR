using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoHouseMediatR.Commands;
using AutoHouseMediatR.Queries.CarQueries;
using MediatR;

namespace AutoHouseMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCars()
        {
            var query = new GetAllCarsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{carId:guid}")]
        public async Task<IActionResult> GetCar(Guid carId)
        {
            var query = new GetCarByIdQuery(carId);
            var result = await _mediator.Send(query);

            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewCar([FromBody] CreateDealerCarCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetCar", new { carId = result.Id }, result);
        }
    }
}

using AutoMapper;
using FlightService.Api.Dtos.Passenger;
using FlightService.Core.Interfaces.Services;
using FlightService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ApiControllerBase
    {
        private readonly IPassengerService _passengerService;

        public PassengerController(
            IPassengerService passengerService,
            IMapper mapper)
            : base(mapper)
        {
            _passengerService = passengerService;
        }

        [HttpGet("{ticketOrderNumber:long}")]
        [ProducesResponseType(typeof(List<GetPassengerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPassengersByTicket([FromRoute] long ticketOrderNumber)
        {
            var passengers = await _passengerService.GetPassengersByTicketsAsync(ticketOrderNumber);
            return Ok(_mapper.Map<List<GetPassengerDto>>(passengers));
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePassenger([FromBody] UpdatePassengerDto passengerDto)
        {
            await _passengerService.UpdatePassengerAsync(_mapper.Map<Passenger>(passengerDto));
            return Ok();
        }

        [HttpDelete("{passengerId:long}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePassenger([FromRoute] long passengerId)
        {
            await _passengerService.DeletePassengerAsync(passengerId);
            return Ok();
        }
    }
}

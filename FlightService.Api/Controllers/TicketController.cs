using AutoMapper;
using FlightService.Api.Dtos.Ticket;
using FlightService.Core.Interfaces.Services;
using FlightService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ApiControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(
            ITicketService ticketService,
            IMapper mapper)
            : base(mapper)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetTicketDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _ticketService.GetTickets();
            return Ok(_mapper.Map<List<GetTicketDto>>(tickets));
        }

        [HttpGet("{ticketOrderNumber:long}")]
        [ProducesResponseType(typeof(GetFullTicketDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTicketByOrderNumber([FromRoute] long ticketOrderNumber)
        {
            var ticker = await _ticketService.GetTicketByOrderNumber(ticketOrderNumber);
            return Ok(_mapper.Map<GetFullTicketDto>(ticker));
        }

        [HttpPut]
        [ProducesResponseType(typeof(GetTicketDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTicket([FromBody] UpdateTicketDto ticketDto)
        {
            var updatedTicket = await _ticketService.UpdateTicket(_mapper.Map<Ticket>(ticketDto));
            return Ok(_mapper.Map<GetTicketDto>(updatedTicket));
        }

        [HttpDelete("{ticketOrderNumber:long}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTicket([FromRoute] long ticketOrderNumber)
        {
            await _ticketService.DeleteTicket(ticketOrderNumber);
            return Ok();
        }
    }
}

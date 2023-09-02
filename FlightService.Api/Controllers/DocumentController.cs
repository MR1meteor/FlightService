using AutoMapper;
using FlightService.Api.Dtos.Document;
using FlightService.Core.Interfaces.Services;
using FlightService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ApiControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(
            IDocumentService documentService,
            IMapper mapper)
            : base(mapper) 
        {
            _documentService = documentService;
        }

        [HttpGet("{passengerId:long}")]
        [ProducesResponseType(typeof(List<GetDocumentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDocumentsByPassenger([FromRoute] long passengerId)
        {
            var documents = await _documentService.GetDocumentsByPassengersAsync(passengerId);

            return Ok(_mapper.Map<List<GetDocumentDto>>(documents));
        }

        [HttpPut]
        [ProducesResponseType(typeof(GetDocumentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateDocument([FromBody] UpdateDocumentDto updateDto)
        {
            var updatedDocument = await _documentService.UpdateDocumentAsync(_mapper.Map<Document>(updateDto));
            return Ok(_mapper.Map<GetDocumentDto>(updatedDocument));
        }

        [HttpDelete("{documentId:long}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDocument([FromRoute] long documentId)
        {
            await _documentService.DeleteDocumentAsync(documentId);
            return Ok();
        }
    }
}

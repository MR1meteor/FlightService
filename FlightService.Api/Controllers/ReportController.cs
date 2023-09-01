using AutoMapper;
using FlightService.Api.Filters.Report;
using FlightService.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ApiControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(
            IReportService reportService,
            IMapper mapper)
            : base(mapper)
        {
            _reportService = reportService;
        }

        [HttpGet("{passengerId:long}")]
        public async Task<IActionResult> GetReport([FromRoute] long passengerId, [FromQuery] ReportFilter reportFilter)
        {
            var report = await _reportService.GetReportAsync(passengerId, reportFilter.StartTime, reportFilter.EndTime);
            return Ok(report);
        }
    }
}

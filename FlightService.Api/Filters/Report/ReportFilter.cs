using System.ComponentModel.DataAnnotations;

namespace FlightService.Api.Filters.Report
{
    public class ReportFilter
    {
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    }
}

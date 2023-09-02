using FlightService.Core.Models;

namespace FlightService.Core.Interfaces.Services
{
    public interface IReportService
    {
        Task<IEnumerable<ReportElement>> GetReportAsync(long passengerId, DateTime startTime, DateTime endTime);
    }
}

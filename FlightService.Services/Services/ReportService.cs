using FlightService.Core.Exceptions;
using FlightService.Core.Interfaces.Repositories;
using FlightService.Core.Interfaces.Services;
using FlightService.Core.Models;

namespace FlightService.Services.Services
{
    public class ReportService : IReportService
    {
        private readonly ITicketRepository _ticketRepository;

        public ReportService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<ReportElement>> GetReportAsync(long passengerId, DateTime startTime, DateTime endTime)
        {
            if (passengerId <= 0)
                throw new BadRequestException("Passenger id cannot be less than 1");

            if (startTime <= endTime)
                throw new BadRequestException("Start time cannot be less than or equal to the end time");

            var tickets = await _ticketRepository.GetAllByPassengerInRange(passengerId, startTime, endTime);

            List<ReportElement> report = new List<ReportElement>(); 

            foreach (var ticket in tickets)
            {
                report.Add(new ReportElement
                {
                    OrderTime = ticket.OrderTime,
                    DepartureTime = ticket.DepartureTime,
                    OrderNumber = ticket.OrderNumber,
                    DeparturePoint = ticket.DeparturePoint,
                    ArrivalPoint = ticket.ArrivalPoint,
                    IsCompleted = ticket.ArrivalTime <= endTime && ticket.ArrivalTime >= startTime
                });
            }

            return report;
        }
    }
}

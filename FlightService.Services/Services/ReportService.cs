using FlightService.Core.Exceptions;
using FlightService.Core.Interfaces.Repositories;
using FlightService.Core.Interfaces.Services;
using FlightService.Core.Models;

namespace FlightService.Services.Services
{
    public class ReportService : IReportService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IPassengerRepository _passengerRepository;

        public ReportService(
            ITicketRepository ticketRepository,
            IPassengerRepository passengerRepository)
        {
            _ticketRepository = ticketRepository;
            _passengerRepository = passengerRepository;
        }

        public async Task<IEnumerable<ReportElement>> GetReportAsync(long passengerId, DateTime startTime, DateTime endTime)
        {
            if (passengerId <= 0)
                throw new BadRequestException("Passenger id cannot be less than 1");

            if (startTime >= endTime)
                throw new BadRequestException("Start time cannot be greater than or equal to the end time");

            var passengerExists = await _passengerRepository.ExistsById(passengerId);

            if (!passengerExists)
                throw new NotFoundException($"Passenger with id: {passengerId} not found");

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

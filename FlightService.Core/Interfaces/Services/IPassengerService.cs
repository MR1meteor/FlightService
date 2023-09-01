using FlightService.Core.Interfaces.Repositories;
using FlightService.Core.Models;

namespace FlightService.Core.Interfaces.Services
{
    public interface IPassengerService
    {
        Task<IEnumerable<Passenger>> GetPassengersByTicketsAsync(long ticketOrderNumber);
        Task UpdatePassengerAsync(Passenger passenger);
        Task DeletePassengerAsync(long passengerId);
    }
}

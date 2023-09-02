using FlightService.Core.Models;

namespace FlightService.Core.Interfaces.Repositories
{
    public interface IPassengerRepository
    {
        Task<IEnumerable<Passenger>> GetAllByTicket(long ticketOrderNumber);
        Task<Passenger> Update(Passenger passenger);
        Task Delete(long passengerId);

        Task<bool> ExistsById(long passengerId);
    }
}

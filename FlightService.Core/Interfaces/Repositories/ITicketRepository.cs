using FlightService.Core.Models;

namespace FlightService.Core.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket> GetById(long ticketOrderNumber);
        Task Update(Ticket ticket);
        Task Delete(long ticketOrderNumber);
        
        Task<bool> ExistsByOrderNumber(long ticketOrderNumber);
    }
}

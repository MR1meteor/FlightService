using FlightService.Core.Exceptions;
using FlightService.Core.Interfaces.Repositories;
using FlightService.Core.Interfaces.Services;
using FlightService.Core.Models;

namespace FlightService.Services.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly ITicketRepository _ticketRepository;

        public PassengerService(
            IPassengerRepository passengerRepository,
            ITicketRepository ticketRepository)
        {
            _passengerRepository = passengerRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<Passenger>> GetPassengersByTicketsAsync(long ticketOrderNumber)
        {
            if (ticketOrderNumber <= 0)
                throw new BadRequestException("Ticket Order Id cannot be less than 1");

            var ticketExists = await _ticketRepository.ExistsByOrderNumber(ticketOrderNumber);

            if (!ticketExists)
                throw new NotFoundException($"Ticket with order number: {ticketOrderNumber} not found");

            var passengers = await _passengerRepository.GetAllByTicket(ticketOrderNumber);
            return passengers;
        }

        public async Task<Passenger> UpdatePassengerAsync(Passenger passenger)
        {
            if (passenger == null)
                throw new BadRequestException("Passenger was null");

            if (passenger.Id <= 0)
                throw new BadRequestException("Passenger Id cannot be less than 1");

            var passengerExists = await _passengerRepository.ExistsById(passenger.Id);

            if (!passengerExists)
                throw new NotFoundException($"Passenger with id: {passenger.Id} not found");

            var updatedPassenger = await _passengerRepository.Update(passenger);
            
            return updatedPassenger;
        }
        
        public async Task DeletePassengerAsync(long passengerId)
        {
            if (passengerId <= 0)
                throw new BadRequestException("Passenger Id cannot be less than 1");

            var passengerExists = await _passengerRepository.ExistsById(passengerId);

            if (!passengerExists)
                throw new NotFoundException($"Passenger with id: {passengerId} not found");

            await _passengerRepository.Delete(passengerId);
        }
    }
}

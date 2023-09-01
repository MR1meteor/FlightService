using FlightService.Core.Exceptions;
using FlightService.Core.Interfaces.Repositories;
using FlightService.Core.Interfaces.Services;
using FlightService.Core.Models;

namespace FlightService.Services.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerService(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<IEnumerable<Passenger>> GetPassengersByTicketsAsync(long ticketOrderNumber)
        {
            if (ticketOrderNumber <= 0)
                throw new BadRequestException("Ticket Order Id cannot be less than 1");

            var passengers = await _passengerRepository.GetAllByTicket(ticketOrderNumber);
            return passengers;
        }

        public async Task UpdatePassengerAsync(Passenger passenger)
        {
            if (passenger == null)
                throw new BadRequestException("Passenger was null");

            if (passenger.Id <= 0)
                throw new BadRequestException("Passenger Id cannot be less than 1");

            var passengerExists = await _passengerRepository.ExistsById(passenger.Id);

            if (!passengerExists)
                throw new NotFoundException($"Passenger with id: {passenger.Id} not found");

            await _passengerRepository.Update(passenger);
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

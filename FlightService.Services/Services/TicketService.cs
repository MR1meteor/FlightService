﻿using FlightService.Core.Exceptions;
using FlightService.Core.Interfaces.Repositories;
using FlightService.Core.Interfaces.Services;
using FlightService.Core.Models;

namespace FlightService.Services.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IDocumentRepository _documentRepository;

        public TicketService(
            ITicketRepository ticketRepository,
            IPassengerRepository passengerRepository,
            IDocumentRepository documentRepository )
        {
            _ticketRepository = ticketRepository;
            _passengerRepository = passengerRepository;
            _documentRepository = documentRepository;
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            var tickets = await _ticketRepository.GetAll();
            return tickets;
        }

        public async Task<Ticket> GetTicketByOrderNumber(long ticketOrderNumber)
        {
            if (ticketOrderNumber <= 0)
                throw new BadRequestException("Ticket Order Number cannot be less than 1");

            var ticket = await _ticketRepository.GetById(ticketOrderNumber);

            if (ticket == null)
                throw new NotFoundException($"Ticket with order number: {ticketOrderNumber} not found");

            ticket.Passengers = await _passengerRepository.GetAllByTicket(ticketOrderNumber);

            foreach (var passenger in ticket.Passengers)
            {
                passenger.Documents = await _documentRepository.GetAllByPassenger(passenger.Id);
            }
            
            return ticket;
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new BadRequestException("Ticket was null");

            if (ticket.OrderNumber <= 0)
                throw new BadRequestException("Ticket Order Number cannot be less than 1");

            if (ticket.DepartureTime >= ticket.ArrivalTime)
                throw new BadRequestException("Departure time cannot be greater than or equal to the arrival time");

            if (ticket.OrderTime >= ticket.DepartureTime)
                throw new BadRequestException("Order time cannot be greater than or equal to the departure and arrival times");

            var ticketExists = await _ticketRepository.ExistsByOrderNumber(ticket.OrderNumber);

            if (!ticketExists)
                throw new NotFoundException($"Ticket with order number: {ticket.OrderNumber} not found");

            var updatedTicket = await _ticketRepository.Update(ticket);

            return updatedTicket;
        }
        
        public async Task DeleteTicket(long ticketOrderNumber)
        {
            if (ticketOrderNumber <= 0)
                throw new BadRequestException("Ticker Order Number cannot be less than 1");

            var ticketExists = await _ticketRepository.ExistsByOrderNumber(ticketOrderNumber);

            if (!ticketExists)
                throw new NotFoundException($"Ticket with order number: {ticketOrderNumber} not found");

            await _ticketRepository.Delete(ticketOrderNumber);
        }
    }
}

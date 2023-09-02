using AutoMapper;
using FlightService.Api.Dtos.Document;
using FlightService.Api.Dtos.Passenger;
using FlightService.Api.Dtos.Ticket;
using FlightService.Core.Models;

namespace FlightService.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Document
            CreateMap<Document, GetDocumentDto>();
            CreateMap<UpdateDocumentDto, Document>();
            #endregion

            #region Passenger
            CreateMap<Passenger, GetPassengerDto>();
            CreateMap<Passenger, GetPassengerWithDocumentsDto>();
            CreateMap<UpdatePassengerDto, Passenger>();
            #endregion

            #region Ticket
            CreateMap<Ticket, GetTicketDto>();
            CreateMap<Ticket, GetFullTicketDto>();
            CreateMap<UpdateTicketDto, Ticket>();
            #endregion
        }
    }
}

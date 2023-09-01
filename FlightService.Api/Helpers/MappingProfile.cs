using AutoMapper;
using FlightService.Api.Dtos.Document;
using FlightService.Api.Dtos.Passenger;
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
            CreateMap<UpdatePassengerDto, Passenger>();
            #endregion
        }
    }
}

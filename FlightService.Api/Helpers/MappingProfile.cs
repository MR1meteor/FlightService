using AutoMapper;
using FlightService.Api.Dtos.Document;
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
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected readonly IMapper _mapper;

        protected ApiControllerBase(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}

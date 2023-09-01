using System.Net;

namespace FlightService.Core.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {

        }
    }
}

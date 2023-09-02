using System.Net;

namespace FlightService.Core.Exceptions
{
    public class BadRequestException : ApiException
    {
        public BadRequestException(string message) : base(message, HttpStatusCode.BadRequest)
        {

        }
    }
}

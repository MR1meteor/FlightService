using System.Net;

namespace FlightService.Core.Exceptions
{
    public class ConflictException : ApiException
    {
        public ConflictException(string message) : base(message, HttpStatusCode.Conflict)
        {

        }
    }
}

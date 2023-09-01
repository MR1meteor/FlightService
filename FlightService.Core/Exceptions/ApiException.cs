using System.Net;

namespace FlightService.Core.Exceptions
{
    public class ApiException : Exception
    {
        public string ApiMessage { get; }
        public HttpStatusCode StatusCode { get; }

        protected ApiException(string apiMessage, HttpStatusCode statusCode)
        {
            ApiMessage = apiMessage;
            StatusCode = statusCode;
        }
    }
}

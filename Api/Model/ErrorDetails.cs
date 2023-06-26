using System.Net;

namespace Api.Model
{
    class ErrorDetails
    {
        public string Message { get; set; } = "";
        public int Status { get; set; } = HttpStatusCode.InternalServerError.GetHashCode();
    }
}

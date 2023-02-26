using System.Net;

namespace Domain.Common.Errors
{
    public class InvalidPropertyNameError : IError
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string Title => "There is no such property";
    }
}

using System.Net;

namespace Domain.Common.Errors
{
    public class NoBooksGenreError : IError
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string Title => "There are no books in this genre";
    }
}

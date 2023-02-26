using System.Net;

namespace Domain.Common.Errors
{
    public interface IError
    {
        HttpStatusCode StatusCode { get; }
        string Title { get; }
    }
}

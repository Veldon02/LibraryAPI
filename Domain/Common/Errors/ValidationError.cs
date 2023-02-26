using System.Net;

namespace Domain.Common.Errors
{
    public class ValidationError : IError
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        public string Title => "Validation Error";
        public List<ValidationFailure> Errors { get; set; } = new();
    }

    public class ValidationFailure
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}

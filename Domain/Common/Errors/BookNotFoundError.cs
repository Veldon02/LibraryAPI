using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Errors
{
    public class BookNotFoundError : IError
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string Title => "There is no book with such id";
    }
}

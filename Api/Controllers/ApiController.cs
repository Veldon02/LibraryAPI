using Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected ActionResult Problem(IError error)
        {
            if (error is ValidationError validationError)
            {
                return ValidationProblem(validationError);
            }
            return Problem(statusCode: (int)error.StatusCode, title: error.Title);
        }

        protected ActionResult ValidationProblem(ValidationError error)
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var e in error.Errors)
            {
                modelStateDictionary.AddModelError(
                    e.PropertyName,
                    e.ErrorMessage);
            }

            return ValidationProblem(modelStateDictionary);
        }
    }
}

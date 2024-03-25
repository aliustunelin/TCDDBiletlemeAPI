using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
        // burası breakfastcontroller için base olduğundan route buraya koyunca ok
    [ApiController]
    [Route("breakfast")]
    public class ApiController : ControllerBase
    {
        // hata durumunu artık buradan döndereceğim, çünkü breakfastcontroller icinde direk alınca istediğpim hata kodunu dönderemem
        protected IActionResult Problem(List<Error> errors){
            var FirstError = errors[0];

            var statusCode = FirstError.Type switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title:FirstError.Description);

        }
    }
}
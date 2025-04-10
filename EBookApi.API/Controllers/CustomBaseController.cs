using System.Net;
using EBookApi.Services.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBookApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ServiceResult<T> serviceResult)
        {
            if (serviceResult.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null) { StatusCode = serviceResult.Status.GetHashCode() };
            }
            return new ObjectResult(serviceResult) { StatusCode = serviceResult.Status.GetHashCode() };
        }
        [NonAction]
        public IActionResult CreateActionResult(ServiceResult serviceResult)
        {
            if (serviceResult.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null) { StatusCode = serviceResult.Status.GetHashCode() };
            }
            return new ObjectResult(serviceResult) { StatusCode = serviceResult.Status.GetHashCode() };
        }
    }
}

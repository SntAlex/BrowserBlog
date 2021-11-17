using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace BrowserBlog.Browsers.WebApi.Controllers.Base
{
    [ApiController]
    [Route("v1/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper Mapper;

        protected BaseController(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected ActionResult GetErrorResult(string errorMessage, int statusCode)
        {
            return statusCode switch
            {
                404 => NotFound(errorMessage),
                400 => BadRequest(errorMessage),
                _ => StatusCode(500, errorMessage)
            };
        }
    }
}
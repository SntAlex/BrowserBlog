using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace BrowserBlog.Browsers.WebApi.Controllers.Base
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper Mapper;

        protected BaseController(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}

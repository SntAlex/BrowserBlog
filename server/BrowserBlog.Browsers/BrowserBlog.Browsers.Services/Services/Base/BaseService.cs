using AutoMapper;
using BrowserBlog.Browsers.Domain.Contracts.Services.Base;
using Microsoft.Extensions.Logging;

namespace BrowserBlog.Browsers.Services.Services.Base
{ 
    public abstract class BaseService : IBaseService
    {
        protected readonly IMapper Mapper;

        protected BaseService(IMapper mapper)
        {
            Mapper = mapper;
        }
    }

    public abstract class BaseService<TService> : BaseService
        where TService : class, IBaseService
    {
        protected readonly ILogger<TService> Logger;

        protected BaseService(IMapper mapper, ILogger<TService> logger) : base(mapper)
        {
            Logger = logger;
        }
    }
}

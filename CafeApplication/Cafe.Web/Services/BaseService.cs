using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Cafe.Web.Services
{
    public class BaseService
    {
        protected readonly IMediator _mediator;
        protected readonly IMemoryCache _cache;

        protected int _cacheTime = 360;
        public BaseService(IMediator mediator, IMemoryCache cache)
        {
            _mediator = mediator;
            _cache = cache;
        }
    }
}

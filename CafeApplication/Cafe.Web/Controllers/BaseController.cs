using Cafe.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Web.Controllers
{
    public class BaseController<T> : Controller where T : BaseService
    {
        protected T _service;

        public BaseController(T service) => _service = service;
    }
}

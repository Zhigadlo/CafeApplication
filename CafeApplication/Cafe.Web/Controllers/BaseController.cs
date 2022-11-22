using Azure.Core;
using Cafe.Domain;
using Cafe.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Cafe.Web.Controllers
{
    public class BaseController<T> : Controller where T : BaseService
    {
        protected T _service;

        public BaseController(T service) => _service = service;

        protected string GetStringFromSession(HttpContext context, string key, string queryName, string defaultValue = "")
        {
            if (context.Request.Query[queryName].Count() > 0)
            {
                return context.Request.Query[queryName][0];
            }
            else if (context.Session.GetString(key) != null)
            {
                return context.Session.GetString(key);
            }
            else
            {
                return defaultValue;
            }
        }

    }
}

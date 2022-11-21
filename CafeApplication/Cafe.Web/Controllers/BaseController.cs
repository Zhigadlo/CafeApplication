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

        protected string GetStringFromSession(string key, string value = null, string defaultValue = "")
        {
            if(value != null) 
            {
                HttpContext.Session.SetString(key, value);
                return value;
            }
            else if(HttpContext.Session.GetString(key) != null)
            {
                value = HttpContext.Session?.GetString(key);
                HttpContext.Session.SetString(key, value);
                return value;
            }
            else
            {
                HttpContext.Session.SetString(key, defaultValue);
                return defaultValue;
            }
        }

    }
}

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cafe.Web.Infrastrcture
{
    public class SetToSessionAttribute : Attribute, IActionFilter
    {
        private string _key;

        public SetToSessionAttribute( string key)
        {
            _key = key;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}

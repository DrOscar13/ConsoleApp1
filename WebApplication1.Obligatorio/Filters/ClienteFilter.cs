using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace LibreriaWebApp.Filters
{
    public class ClienteFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("rol");
            if (string.IsNullOrEmpty(rol) || rol != "Cliente")
            {
                context.Result = new RedirectToActionResult("Index", "Home", new { errorMessage = "Acceso denegado para clientes" });
            }
            base.OnActionExecuting(context);
        }
    }
}

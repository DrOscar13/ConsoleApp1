using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace LibreriaWebApp.Filters
{
    public class AdministradorFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("rol");
            if (string.IsNullOrEmpty(rol) || rol != "Administrador")
            {
                context.Result = new RedirectToActionResult("Index", "Home", new { errorMessage = "Acceso denegado para administradores" });
            }
            base.OnActionExecuting(context);
        }
    }
}

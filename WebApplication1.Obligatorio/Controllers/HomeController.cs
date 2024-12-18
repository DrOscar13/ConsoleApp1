using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Necesario para la gestión de sesión


namespace LibreriaWebApp.Controllers
{
    public class HomeController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult Index(string errorMessage)
        {
            ViewData["Title"] = "Inicio";
            ViewBag.errorMessage = errorMessage;

            // Verificar si el usuario está autenticado y obtener su rol desde la sesión
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")))
            {
                ViewBag.Rol = HttpContext.Session.GetString("rol"); // Obtiene el rol de la sesión (Administrador o Cliente)
            }
            else
            {
                return RedirectToAction("Login"); // Redirigir a la página de login si no está autenticado
            }

            return View();
        }
        public IActionResult Registro()
        {
            ViewData["Title"] = "Registro";
            return View();
        }

     
        [HttpPost]
        public IActionResult Registro(Cliente cliente)
        {
            try
            {
                sistema.RegistrarCliente(cliente);
                return RedirectToAction("Index", new { successMessage = $"{cliente.Nombre} se agregó correctamente con el id {cliente.Id}" });
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(/*"Index"*/);
            }
        }


        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                Usuario logueado = sistema.Login(email, password);
                HttpContext.Session.SetString("username", logueado.Email);
                HttpContext.Session.SetString("rol", logueado.GetType().Name); // Guarda el tipo de usuario (Administrador o Cliente) como rol
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}


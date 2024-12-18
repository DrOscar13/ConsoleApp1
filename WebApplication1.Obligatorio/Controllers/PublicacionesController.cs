using LibreriaWebApp.Filters;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Obligatorio.Controllers
{

    public class PublicacionesController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            sistema.OrdernarListaPublicaciones();
            return View(sistema.Publicaciones);
        }


        [HttpPost]
        [ClienteFilter]
        public IActionResult Comprar(int publicacionId)
        {
            string email = HttpContext.Session.GetString("username");

            try
            {
                sistema.ProcesarCompra(publicacionId, email);

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View("Index", sistema.Publicaciones);
        }

        [AdministradorFilter]
        public IActionResult ListadoDeSubastas()
        {
            List<Subasta> subastas = sistema.ObtenerSubastasOrdenadas();

            // Envía la lista de subastas a la vista
            return View(subastas);

        }

        [HttpPost]
        [ClienteFilter]
        public IActionResult Ofertar(int publicacionId, int montoOferta)
        {
            string email = HttpContext.Session.GetString("username");
            Cliente cliente = sistema.ObtenerClientePorEmail(email);
            Publicacion publicacion = sistema.BuscarPublicacionPorId(publicacionId);

            if (publicacion is Subasta subasta && subasta.EstadoPublicacion == EstadoPublicacion.ABIERTA && montoOferta > 0)
            {
                sistema.AgregarOferta(cliente, subasta, montoOferta);
                ViewBag.Message = "Oferta realizada con éxito.";
            }
            else
            {
                ViewBag.Message = "La oferta no es válida o la subasta está cerrada.";
            }
            return View("Index", sistema.Publicaciones);
        }

  


        [HttpPost]
        [AdministradorFilter]
        public IActionResult CerrarSubasta(int publicacionId)
        {
            string emailAdmin = HttpContext.Session.GetString("username");
            try
            {
                  sistema.ProcesarCierre(publicacionId, emailAdmin);
                
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View("ListadoDeSubastas", sistema.ObtenerSubastasOrdenadas());
        }
            public IActionResult CargarSaldo()
        {
            return View();
        }

        [HttpPost]
        [ClienteFilter]
        public IActionResult CargarSaldo(decimal monto)
        {
            // Obtener el email del cliente autenticado desde la sesión
            string email = HttpContext.Session.GetString("username");
            Cliente cliente = sistema.ObtenerClientePorEmail(email);

            if (cliente == null)
            {
                ViewBag.Message = "Debe iniciar sesión como cliente para cargar saldo.";
                return RedirectToAction("Login", "Home");
            }

            try
            {
                sistema.CargarSaldo(cliente, monto);
                ViewBag.Message = $"Se cargaron {monto} en su cuenta correctamente.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }
    }



}









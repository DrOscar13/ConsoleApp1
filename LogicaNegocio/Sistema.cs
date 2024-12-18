using System.Collections.Generic;
using System.Net.Http;

namespace LogicaNegocio
{
    public class Sistema
    {
        private static Sistema _instancia;
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Articulo> _articulos = new List<Articulo>();
        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }

        public List<Publicacion> Publicaciones { get { return _publicaciones; } }
        public List<Usuario> Usuarios { get { return _usuarios; } }
        public List<Articulo> Articulos { get { return _articulos; } }



        private Sistema()
        {
            this.Precarga();
        }
        public void Precarga()
        {
            PrecargaUsuarios();
            PrecargaArticulos();
            PrecargaPublicaciones();
        }

        public void PrecargaUsuarios()
        {
            //Precargamos 10 Clientes
            _usuarios.Add(new Cliente("Juan", "Pérez", "juan.perez@example.com", "password123", 5000));
            _usuarios.Add(new Cliente("Ana", "García", "ana.garcia@example.com", "password123", 1000));
            _usuarios.Add(new Cliente("Carlos", "Rodríguez", "carlos.rod@example.com", "password123", 800));
            _usuarios.Add(new Cliente("María", "Fernández", "maria.fernandez@example.com", "password123", 1200));
            _usuarios.Add(new Cliente("Pedro", "González", "pedro.g@example.com", "password123", 900));
            _usuarios.Add(new Cliente("Sofía", "López", "sofia.lopez@example.com", "password123", 700));
            _usuarios.Add(new Cliente("Laura", "Martínez", "laura.m@example.com", "password123", 1100));
            _usuarios.Add(new Cliente("Javier", "Díaz", "javier.d@example.com", "password123", 1300));
            _usuarios.Add(new Cliente("Mónica", "Suárez", "monica.suarez@example.com", "password123", 600));
            _usuarios.Add(new Cliente("David", "Ramos", "david.ramos@example.com", "password123", 1500));

            _usuarios.Add(new Administrador("Laura", "Méndez", "laura.mendez@example.com", "adminpass1"));
            _usuarios.Add(new Administrador("Federico", "Sosa", "federico.sosa@example.com", "adminpass2"));

        }



        public void PrecargaArticulos()
        { // Precargamos 50 articulos
            _articulos.Add(new Articulo("Laptop", "Electronica", 1000));
            _articulos.Add(new Articulo("Celular", "Electronica", 600));
            _articulos.Add(new Articulo("Mouse", "Electronica", 50));
            _articulos.Add(new Articulo("Zapatillas", "Deportes", 120));
            _articulos.Add(new Articulo("Camiseta de Fútbol", "Deportes", 80));
            _articulos.Add(new Articulo("Cafetera", "Electrodomésticos", 200));
            _articulos.Add(new Articulo("Microondas", "Electrodomésticos", 300));
            _articulos.Add(new Articulo("Sofá", "Muebles", 500));
            _articulos.Add(new Articulo("Silla de Oficina", "Muebles", 150));
            _articulos.Add(new Articulo("Escritorio", "Muebles", 250));

            _articulos.Add(new Articulo("Zapatillas de futbol", "Deportes", 120));
            _articulos.Add(new Articulo("Camiseta de Training", "Deportes", 80));
            _articulos.Add(new Articulo("Bicicleta", "Deportes", 400));
            _articulos.Add(new Articulo("Pelota de Básquet", "Deportes", 50));
            _articulos.Add(new Articulo("Raqueta de Tenis", "Deportes", 150));
            _articulos.Add(new Articulo("Guantes de Boxeo", "Deportes", 70));
            _articulos.Add(new Articulo("Casco de Ciclismo", "Deportes", 90));
            _articulos.Add(new Articulo("Cinta para Correr", "Deportes", 800));
            _articulos.Add(new Articulo("Pesas", "Deportes", 100));
            _articulos.Add(new Articulo("Saco de Dormir", "Deportes", 60));

            _articulos.Add(new Articulo("Cafetera Italiana", "Electrodomésticos", 200));
            _articulos.Add(new Articulo("Microondas", "Electrodomésticos", 300));
            _articulos.Add(new Articulo("Heladera", "Electrodomésticos", 900));
            _articulos.Add(new Articulo("Licuadora", "Electrodomésticos", 150));
            _articulos.Add(new Articulo("Aspiradora", "Electrodomésticos", 250));
            _articulos.Add(new Articulo("Lavarropas", "Electrodomésticos", 1200));
            _articulos.Add(new Articulo("Secadora", "Electrodomésticos", 700));
            _articulos.Add(new Articulo("Plancha", "Electrodomésticos", 60));
            _articulos.Add(new Articulo("Batidora", "Electrodomésticos", 80));
            _articulos.Add(new Articulo("Horno Eléctrico", "Electrodomésticos", 400));

            _articulos.Add(new Articulo("Sofá", "Muebles", 500));
            _articulos.Add(new Articulo("Silla Gamer", "Muebles", 150));
            _articulos.Add(new Articulo("Escritorio completo", "Muebles", 250));
            _articulos.Add(new Articulo("Mesa de Comedor", "Muebles", 300));
            _articulos.Add(new Articulo("Silla de Comedor", "Muebles", 75));
            _articulos.Add(new Articulo("Cama", "Muebles", 800));
            _articulos.Add(new Articulo("Ropero", "Muebles", 600));
            _articulos.Add(new Articulo("Biblioteca", "Muebles", 200));
            _articulos.Add(new Articulo("Estantería", "Muebles", 180));
            _articulos.Add(new Articulo("Mesa de Noche", "Muebles", 120));

            _articulos.Add(new Articulo("Bolso de Viaje", "Accesorios", 100));
            _articulos.Add(new Articulo("Gafas de Sol", "Accesorios", 60));
            _articulos.Add(new Articulo("Reloj de Pulsera", "Accesorios", 150));
            _articulos.Add(new Articulo("Maletín", "Accesorios", 130));
            _articulos.Add(new Articulo("Mochila", "Accesorios", 80));
            _articulos.Add(new Articulo("Sombrero", "Accesorios", 40));
            _articulos.Add(new Articulo("Billetera", "Accesorios", 50));
            _articulos.Add(new Articulo("Bufanda", "Accesorios", 30));
            _articulos.Add(new Articulo("Cinturón", "Accesorios", 35));
            _articulos.Add(new Articulo("Llavero", "Accesorios", 15));
        }

        public void PrecargaPublicaciones()
        {
            // 10 Ventas
            _publicaciones.Add(new Venta("Venta Electrónica", DateTime.Parse("12/04/2023"), new List<Articulo> { _articulos[0], _articulos[1] }, (Cliente)_usuarios[0], EstadoPublicacion.ABIERTA, null, null, false));
            _publicaciones.Add(new Venta("Venta de Deportes", DateTime.Parse("15/05/2023"), new List<Articulo> { _articulos[2], _articulos[3] }, (Cliente)_usuarios[1], EstadoPublicacion.CERRADA, (Administrador)_usuarios[10], DateTime.Parse("20/05/2023"), true));
            _publicaciones.Add(new Venta("Venta de Muebles", DateTime.Parse("10/06/2023"), new List<Articulo> { _articulos[4], _articulos[5] }, (Cliente)_usuarios[2], EstadoPublicacion.ABIERTA, null, null, false));
            _publicaciones.Add(new Venta("Venta de Electrodomésticos", DateTime.Parse("01/07/2023"), new List<Articulo> { _articulos[6], _articulos[7] }, (Cliente)_usuarios[3], EstadoPublicacion.CERRADA, (Administrador)_usuarios[11], DateTime.Parse("05/07/2023"), true));
            _publicaciones.Add(new Venta("Venta de Accesorios", DateTime.Parse("18/08/2023"), new List<Articulo> { _articulos[8], _articulos[9] }, (Cliente)_usuarios[4], EstadoPublicacion.ABIERTA, null, null, false));
            _publicaciones.Add(new Venta("Venta de Herramientas", DateTime.Parse("22/09/2023"), new List<Articulo> { _articulos[10], _articulos[11] }, (Cliente)_usuarios[5], EstadoPublicacion.CERRADA, (Administrador)_usuarios[10], DateTime.Parse("30/09/2023"), true));
            _publicaciones.Add(new Venta("Venta de Jardinería", DateTime.Parse("01/10/2023"), new List<Articulo> { _articulos[12], _articulos[13] }, (Cliente)_usuarios[6], EstadoPublicacion.ABIERTA, null, null, false));
            _publicaciones.Add(new Venta("Venta de Ropa", DateTime.Parse("15/11/2023"), new List<Articulo> { _articulos[14], _articulos[15] }, (Cliente)_usuarios[7], EstadoPublicacion.CERRADA, (Administrador)_usuarios[11], DateTime.Parse("20/11/2023"), true));
            _publicaciones.Add(new Venta("Venta de Juguetes", DateTime.Parse("05/12/2023"), new List<Articulo> { _articulos[16], _articulos[17] }, (Cliente)_usuarios[8], EstadoPublicacion.ABIERTA, null, null, false));
            _publicaciones.Add(new Venta("Venta de Bicicletas", DateTime.Parse("20/12/2023"), new List<Articulo> { _articulos[18], _articulos[19] }, (Cliente)_usuarios[9], EstadoPublicacion.CERRADA, (Administrador)_usuarios[10], DateTime.Parse("25/12/2023"), true));

            // 10 Subastas
            Subasta subasta1 = new Subasta("Subasta Electrónica", DateTime.Parse("12/04/2023"), new List<Articulo> { _articulos[0], _articulos[1] }, (Cliente)_usuarios[0], EstadoPublicacion.ABIERTA, null, null);
            subasta1.AgregarOferta(new Oferta((Cliente)_usuarios[0], 500, DateTime.Parse("13/04/2023")));
            subasta1.AgregarOferta(new Oferta((Cliente)_usuarios[1], 600, DateTime.Parse("14/04/2023")));

            Subasta subasta2 = new Subasta("Subasta de Deportes", DateTime.Parse("10/05/2023"), new List<Articulo> { _articulos[2], _articulos[3] }, (Cliente)_usuarios[1], EstadoPublicacion.CERRADA, (Administrador)_usuarios[10], DateTime.Parse("15/05/2023"));
            subasta2.AgregarOferta(new Oferta((Cliente)_usuarios[2], 400, DateTime.Parse("11/05/2023")));
            subasta2.AgregarOferta(new Oferta((Cliente)_usuarios[3], 450, DateTime.Parse("12/05/2023")));

            _publicaciones.Add(subasta1);
            _publicaciones.Add(subasta2);

            _publicaciones.Add(new Subasta("Subasta de Muebles", DateTime.Parse("01/06/2023"), new List<Articulo> { _articulos[4], _articulos[5] }, (Cliente)_usuarios[2], EstadoPublicacion.ABIERTA, null, null));
            _publicaciones.Add(new Subasta("Subasta de Electrodomésticos", DateTime.Parse("20/07/2023"), new List<Articulo> { _articulos[6], _articulos[7] }, (Cliente)_usuarios[3], EstadoPublicacion.CERRADA, (Administrador)_usuarios[11], DateTime.Parse("25/07/2023")));
            _publicaciones.Add(new Subasta("Subasta de Accesorios", DateTime.Parse("30/07/2023"), new List<Articulo> { _articulos[8], _articulos[9] }, (Cliente)_usuarios[4], EstadoPublicacion.ABIERTA, null, null));
            _publicaciones.Add(new Subasta("Subasta de Herramientas", DateTime.Parse("31/07/2023"), new List<Articulo> { _articulos[10], _articulos[11] }, (Cliente)_usuarios[5], EstadoPublicacion.CERRADA, (Administrador)_usuarios[10], DateTime.Parse("20/09/2023")));
            _publicaciones.Add(new Subasta("Subasta de Jardinería", DateTime.Parse("01/10/2023"), new List<Articulo> { _articulos[12], _articulos[13] }, (Cliente)_usuarios[6], EstadoPublicacion.ABIERTA, null, null));
            _publicaciones.Add(new Subasta("Subasta de Ropa", DateTime.Parse("15/11/2023"), new List<Articulo> { _articulos[14], _articulos[15] }, (Cliente)_usuarios[7], EstadoPublicacion.CERRADA, (Administrador)_usuarios[11], DateTime.Parse("20/11/2023")));
            _publicaciones.Add(new Subasta("Subasta de Juguetes", DateTime.Parse("05/12/2023"), new List<Articulo> { _articulos[16], _articulos[17] }, (Cliente)_usuarios[8], EstadoPublicacion.ABIERTA, null, null));
            _publicaciones.Add(new Subasta("Subasta de Bicicletas", DateTime.Parse("20/12/2023"), new List<Articulo> { _articulos[18], _articulos[19] }, (Cliente)_usuarios[9], EstadoPublicacion.CERRADA, (Administrador)_usuarios[10], DateTime.Parse("25/12/2023")));
        }



        public List<Usuario> ListarClientes() //listar clientes de la clase usuario
        {
            List<Usuario> aRetornar = new List<Usuario>();
            foreach (Usuario u in this.Usuarios)
            {
                if (u is Cliente)
                {
                    aRetornar.Add(u);
                }
            }
            return aRetornar;
        }


        public List<Articulo> ListarArticulosPorCategoria(string unaCategoria) // lista articulos por categoria 
        {

            List<Articulo> aRetornar = new List<Articulo>();

            foreach (Articulo a in this.Articulos)
            {
                if (a.Categoria == unaCategoria)
                {
                    aRetornar.Add(a);
                }
            }
            return aRetornar;
        }


        public void AgregarArticulo(Articulo unArticulo) //// Método para agregar un artículo a la lista de artículos
        {
            try
            {
                unArticulo.Validar();
                this.Articulos.Add(unArticulo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // dada dos fechas ingresadas, una de inicio y otra de fin, listar las publicaciones que hay entre ellas
        public List<Publicacion> ListarPublicacionesEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Publicacion> publicacionesEntreFechas = new List<Publicacion>();

            foreach (Publicacion publicacion in _publicaciones)
            {
                if (publicacion.FechaPublicacion >= fechaInicio && publicacion.FechaPublicacion <= fechaFin)
                {
                    publicacionesEntreFechas.Add(publicacion);
                }
            }
            return publicacionesEntreFechas;

        }

        public Publicacion BuscarPublicacionPorId(int id)
        {
            foreach (Publicacion publicacion in _publicaciones)
            {
                if (publicacion.Id == id)
                {
                    return publicacion;
                }
            }
            return null;
        }

        public Cliente ObtenerClientePorEmail(string email)
        {
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Cliente cliente && cliente.Email == email)
                {
                    return cliente;
                }
            }
            return null;
        }

        public Administrador ObtenerAdministradorPorEmail(string email)
        {
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Administrador administrador && administrador.Email == email)
                {
                    return administrador;
                }
            }
            return null;
        }

        public void OrdernarListaPublicaciones()
        {
            this.Publicaciones.Sort();
           
        }

        public void RegistrarCliente(Usuario usuario)
        {
            try
            {
                usuario.Validar();
                this._usuarios.Add(usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Usuario Login(string email, string password)
        {
            foreach (Usuario usuario in this.Usuarios)
            {
                if (usuario.Email == email)
                {
                    if (usuario.Contrasena == password)
                    {
                        // Retornar el usuario autenticado
                        return usuario;
                    }
                    throw new Exception("Email o Password incorrecto");
                }
            }
            throw new Exception("Email o Password incorrecto");
        }




        public List<Subasta> ObtenerSubastasOrdenadas()
        {
            List<Subasta> subastas = new List<Subasta>();

            // Filtra solo subastas y las agrega a la lista
            foreach (Publicacion publicacion in _publicaciones)
            {
                if (publicacion is Subasta)
                {
                    subastas.Add(publicacion as Subasta);
                }
            }

            // Ordena subastas por la implementación de IComparable en Publicacion

            subastas.Sort();


            return subastas;
        }


        public bool CargarSaldo(Cliente cliente, decimal monto)
        {
            if (monto <= 0)
            {
                throw new Exception("El monto debe ser positivo.");
            }

            cliente.Saldo += monto;
            return true;
        }

        public void ProcesarCompra(int publicacionId, string emailCliente)
        {
            // Busca la publicación por ID
            Publicacion publicacion = BuscarPublicacionPorId(publicacionId);
            Cliente cliente = ObtenerClientePorEmail(emailCliente);

            if (publicacion == null)
            {
                throw new Exception("Publicación no encontrada"); 
            }

            if (cliente == null)
            {
                throw new Exception("Cliente no encontrado o sesión expirada");
            }

            // Llama al método polimórfico para realizar la compra
            publicacion.CerrarPublicacion(cliente);
            return; 
        }

        // Método para procesar el cierre de una publicación (subasta o venta)
        public void ProcesarCierre(int publicacionId, string emailAdmin)
        {
            // Busca la publicación por ID
            Publicacion publicacion = BuscarPublicacionPorId(publicacionId);
            Administrador admin = ObtenerAdministradorPorEmail(emailAdmin);

            if (publicacion == null)
            {
                throw new Exception("Publicación no encontrada");
            }

            if (admin == null)
            {
                throw new Exception("Administrador no encontrado o sesión expirada");
            }

            // Llama al método polimórfico para cerrar la publicación
            publicacion.CerrarPublicacion(admin);
            return; 
        }

        public void AgregarOferta(Cliente cliente, Subasta subasta, int monto)
        {
            // Crea una nueva oferta y agrégala a la lista de ofertas de la subasta
            Oferta nuevaOferta = new Oferta(cliente, monto, DateTime.Now);
            subasta.AgregarOferta(nuevaOferta);
        }


    }


}


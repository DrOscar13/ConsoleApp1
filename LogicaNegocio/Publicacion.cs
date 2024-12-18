using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaNegocio
{
    public abstract class Publicacion : IComparable<Publicacion>
    {
        private static int s_ultimoId = 0;
        private int _id;
        private string _nombre;
        private DateTime _fechaPublicacion;
        private List<Articulo> _listaArticulos;
        private Cliente _comprador;
        private EstadoPublicacion _estadoPublicacion;
        private Administrador _finalizador;
        private DateTime? _fechaFinalizacion;
        private IEnumerable<object> ventas;

        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public DateTime FechaPublicacion
        {
            get { return this._fechaPublicacion; }
            set { this._fechaPublicacion = value; }
        }

        public List<Articulo> ListaArticulos
        {
            get { return this._listaArticulos; }
            set { this._listaArticulos = value; }
        }

        public Cliente Comprador
        {
            get { return this._comprador; }
            set { this._comprador = value; }
        }

        public EstadoPublicacion EstadoPublicacion
        {
            get { return this._estadoPublicacion; }
            set { this._estadoPublicacion = value; }
        }

        public Administrador Finalizador
        {
            get { return this._finalizador; }
            set { this._finalizador = value; }
        }

        public DateTime? FechaFinalizacion
        {
            get { return this._fechaFinalizacion; }
            set { this._fechaFinalizacion = value; }
        }

        public Publicacion()
        {
            this._id = Publicacion.s_ultimoId++;
            this._listaArticulos = new List<Articulo>();
        }

        public Publicacion(string unNombre,
            DateTime unaFecha,
             List<Articulo> unaListaArticulo,
             Cliente unClienteComprador,
            EstadoPublicacion unEstado,
            Administrador unFinalizador,
            DateTime? unaFechaFinalizacion)
        {
            this._id = Publicacion.s_ultimoId++;
            this._nombre = unNombre;
            this._fechaPublicacion = unaFecha;
            this._listaArticulos = unaListaArticulo ?? new List<Articulo>();
            this._comprador = unClienteComprador;
            this._estadoPublicacion = unEstado;
            this._finalizador = unFinalizador;
            this._fechaFinalizacion = unaFechaFinalizacion;


        }
        public override string ToString()
        {
            return $"\n - Id: {this._id}" +
                   $"\n - Nombre: {this._nombre}" +
                   $"\n - Estado Publicacion: {this._estadoPublicacion}" +
                   $"\n - Fecha Publicacion: ${this._fechaPublicacion}";
        }



        public static void ValidarFecha(DateTime unaFecha, DateTime unaFechaDos) //metodo para validar fecha
        {
            DateTime fechaComienzo = new DateTime(2023, 1, 1);
            DateTime fechaFinal = new DateTime(2024, 10, 30);


            if (unaFecha < fechaComienzo || unaFechaDos > fechaFinal || unaFecha > unaFechaDos)
            {
                throw new Exception("La fecha ingresada debe estar comprendida entre el 01/01/2023 y 30/10/2024");
            }

        }

        public int CompareTo(Publicacion other)
        {
            
            // Ordenar de más reciente a más antigua
            return other._fechaPublicacion.CompareTo(this._fechaPublicacion);
        }

       

        // Método abstracto para cerrar la publicación, que debe implementarse en las subclases
        public abstract void CerrarPublicacion(Usuario usuario);

        public abstract decimal CalcularCosto();


    }

    
}

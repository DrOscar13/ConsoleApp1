using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Articulo
    {
        private static int s_ultimoId = 0;
        private int _id;
        private string _nombre;
        private string _categoria;
        private decimal _precioVenta;

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

        public string Categoria
        {
            get { return this._categoria; }
            set { this._categoria = value; }
        }

        public decimal PrecioVenta
        {
            get { return this._precioVenta; }
            set { this._precioVenta = value; }
        }

        public Articulo()
        {
            this._id = Articulo.s_ultimoId++;
        }

        public Articulo(string unNombre, string unaCategoria, decimal unPrecioVenta)
        {
            this._id = Articulo.s_ultimoId++;
            this._nombre = unNombre;
            this._categoria = unaCategoria;
            this._precioVenta = unPrecioVenta;
        }

        public override string ToString()
        {
            return $"\n - Id: {this._id}" +
                   $"\n - Nombre: {this._nombre}" +
                   $"\n - Categoría: {this._categoria}" +
                   $"\n - Precio de Venta: ${this._precioVenta}";
        }

            public static List<string> CategoriasDisponibles = new List<string>
            {
                "Electrónica",
                "Deportes",
                "Muebles",
                 "Electrodomésticos",
                "Ropa",
                "Accesorios"
            };

        public void Validar() //metodo para validar un articulo
        {
            if (this._nombre == null || this._nombre.Length == 0 )
            {
                throw new Exception("El nombre del articulo no puede ser vacio");
            }
            if (this._nombre.Length <= 3)
            {
                throw new Exception("El titulo debe contener al menos 4 caracteres");
            }
            if (this._precioVenta < 1)
            {
                throw new Exception("El precio no puede ser menor a 1");
            }
            if (this._categoria != "Electrónica" && this._categoria != "Deportes" && this._categoria != "Muebles" && this._categoria != "Electrodomésticos" && this._categoria != "Ropa"
               && this._categoria != "Accesorios")
            {
                throw new Exception("La categoria ingresada no es correcta");
            }
        }
       
    }
}

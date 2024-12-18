using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public  class  Venta : Publicacion
    {
        private bool _ofertaRelampago;

        public bool OfertaRelampago
        {
            get { return this._ofertaRelampago; }
            set { this._ofertaRelampago = value; }
        }
       

        public Venta(string unNombre,
            DateTime unaFecha,
             List<Articulo> unaListaArticulo,
             Cliente unClienteComprador,
            EstadoPublicacion unEstado,
            Administrador unFinalizador,
            DateTime? unaFechaFinalizacion,
            bool esOfertaRelampago
             )
            : base(unNombre, unaFecha, unaListaArticulo, unClienteComprador, unEstado, unFinalizador, unaFechaFinalizacion)
        {
            this.OfertaRelampago = esOfertaRelampago;

        }




        public override void CerrarPublicacion(Usuario usuario)
        {
            if (!(usuario is Cliente))
            {
                throw new Exception("Solo los clientes pueden realizar compras");
            }
            Cliente cliente = (Cliente)usuario;
            decimal costo = this.CalcularCosto();

            if (this.EstadoPublicacion == EstadoPublicacion.ABIERTA && cliente.Saldo >= costo)
            {
                cliente.Saldo -= costo;
                this.Comprador = cliente;
                this.FechaFinalizacion = DateTime.Now;
                this.EstadoPublicacion = EstadoPublicacion.CERRADA;

               
                throw new Exception("Compra realizada con exito ");

            }
            throw new Exception("Compra fallida. La publicación no está disponible o el saldo es insuficiente."); 
        }



        public override decimal CalcularCosto()
        {
            decimal totalVenta = 0;
            foreach (Articulo articulo in this.ListaArticulos)
            {
                totalVenta += articulo.PrecioVenta;
            }

            if (OfertaRelampago)
            {
                totalVenta *= 0.8m; // Aplica el 20% de descuento
            }

            return totalVenta;
        }
    }
}





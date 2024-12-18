using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Subasta : Publicacion
    {
        private List<Oferta> _ofertas;

        public List<Oferta> Ofertas
        {
            get { return this._ofertas; }
            set { this._ofertas = value; }
        }
     

        public Subasta(string unNombre,
            DateTime unaFecha,
             List<Articulo> unaListaArticulo,
             Cliente unClienteComprador,
            EstadoPublicacion unEstado,
            Administrador unFinalizador,
            DateTime? unaFechaFinalizacion) : base(unNombre, unaFecha, unaListaArticulo, unClienteComprador, unEstado, unFinalizador, unaFechaFinalizacion)
        {
            this._ofertas = new List<Oferta>();
        }

        public void AgregarOferta(Oferta nuevaOferta)
        {
            this.Ofertas.Add(nuevaOferta);
        }

        // Implementación de CerrarPublicacion específica para Subasta
        public override void CerrarPublicacion(Usuario usuario)
        {
            if (this.EstadoPublicacion != EstadoPublicacion.ABIERTA)
            {
                throw new Exception("La subasta no está en estado ABIERTA y no puede cerrarse.");
            
            }

            if (this.Ofertas.Count == 0)
            {
                throw new Exception("No hay ofertas válidas para esta subasta.");
             
            }

            if (!(usuario is Administrador administrador))
            {
                throw new Exception("Solo un administrador puede cerrar la subasta.");
               
            }

            Oferta mejorOferta = ObtenerMejorOferta();
            Cliente ganador = mejorOferta.Usuario;

            if (ganador.Saldo < mejorOferta.Monto)
            {
                Oferta segundaMejorOferta = ObtenerSegundaMejorOferta(mejorOferta);
                if (segundaMejorOferta == null || segundaMejorOferta.Usuario.Saldo < segundaMejorOferta.Monto)
                {
                    this.EstadoPublicacion = EstadoPublicacion.CERRADA;
                    throw new Exception("No hay oferentes con saldo suficiente para adjudicar la subasta.");
              
                }
                ganador = segundaMejorOferta.Usuario;
            }

            ganador.Saldo -= mejorOferta.Monto;
            this.Comprador = ganador;
            this.EstadoPublicacion = EstadoPublicacion.CERRADA;
            this.FechaFinalizacion = DateTime.Now;
            this.Finalizador = administrador; // Asigna solo si es un administrador

            throw new Exception($"La subasta fue cerrada exitosamente. Comprador: {ganador.Nombre}, Fecha de finalización: {this.FechaFinalizacion}, Finalizado por: {administrador.Nombre}.");
         
        }


     

        public Oferta ObtenerMejorOferta()
        {
            Oferta mejor = null;
            foreach (Oferta oferta in _ofertas)
            {
                if (mejor == null || oferta.Monto > mejor.Monto)
                {
                    mejor = oferta;
                }
            }
            return mejor;
        }

        private Oferta ObtenerSegundaMejorOferta(Oferta mejorOferta)
        {
            Oferta segundaMejor = null;
            foreach (Oferta oferta in _ofertas)
            {
                if (oferta != mejorOferta && (segundaMejor == null || oferta.Monto > segundaMejor.Monto))
                {
                    segundaMejor = oferta;
                }
            }
            return segundaMejor;
        }


        public override decimal CalcularCosto()
        {
            if (Ofertas.Count == 0) // Si no hay ofertas
            {
                return 0; // No hay costo
            }

            Oferta mejorOferta = ObtenerMejorOferta(); // Busca la mejor oferta
            return mejorOferta != null ? mejorOferta.Monto : 0; // Devuelve el monto de la mejor oferta
        }


    }
    

}









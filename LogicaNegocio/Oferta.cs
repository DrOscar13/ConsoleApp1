using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Oferta
    {
        private static int s_ultimoId = 0;
        private int _id;
        private Cliente _usuario;
        private decimal _monto;
        private DateTime _fecha;

        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public Cliente Usuario
        {
            get { return this._usuario; }
            set { this._usuario = value; }
        }


        public decimal Monto
        {
            get { return this._monto; }
            set { this._monto = value; }
        }

        public DateTime Fecha
        {
            get { return this._fecha; }
            set { this._fecha = value; }
        }

        public Oferta()
        {
            this._id = Oferta.s_ultimoId++;
        }

       
        public Oferta(Cliente unUsuario, decimal unMonto, DateTime fecha)
        {
            this._id = Oferta.s_ultimoId++;
            this._usuario = unUsuario;
            this._monto = unMonto;
            this._fecha = fecha;  // Fecha pasada como parámetro
        }

        public override string ToString()
        {
            return $"{Usuario.Nombre} - Monto: {Monto:C}";
        }



    }
}

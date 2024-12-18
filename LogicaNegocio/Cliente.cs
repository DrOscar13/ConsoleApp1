using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Cliente : Usuario
    {
        private decimal _saldo;

        public decimal Saldo
        {
            get { return this._saldo; }
            set { this._saldo = value; }
        }

        public Cliente() : base()
        {
            this._saldo = 0m;
        }

        public Cliente(string unNombre, string unApellido, string unEmail, string unaContraseña, decimal saldoInicial)
            : base(unNombre, unApellido, unEmail, unaContraseña)
        {
            this._saldo = saldoInicial;
        }


       
        public override string ToString()
        {
            return "\n - Id: " + this.Id +
                   "\n - Nombre: " + this.Nombre +
                   "\n - Apellido: " + this.Apellido +
                   "\n - Email: " + this.Email +
                   "\n - Saldo: $" + this.Saldo;
        }
    }
}

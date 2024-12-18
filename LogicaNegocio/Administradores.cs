using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Administrador : Usuario
    {
        public Administrador() : base() { }

        public Administrador(string unNombre, string unApellido, string unEmail, string unaContraseña)
            : base(unNombre, unApellido, unEmail, unaContraseña)
        {

        }
    }
}

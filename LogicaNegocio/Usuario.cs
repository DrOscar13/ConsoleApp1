using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Usuario
    {
        private static int s_ultimoId = 0;
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _contrasena;

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

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }

        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public string Contrasena
        {
            get { return this._contrasena; }
            set { this._contrasena = value; }
        }

        public Usuario()
        {
            this._id = Usuario.s_ultimoId++;
        }

        public Usuario(string unNombre, string unApellido, string unEmail, string unaContraseña)
        {
            this._id = Usuario.s_ultimoId++;
            this._nombre = unNombre;
            this._email = unEmail;
            this._contrasena = unaContraseña;
        }

        
        public void Validar()
        {
            if (String.IsNullOrEmpty(this._nombre))
            {
                throw new Exception("El nombre no puede estar vacío.");
            }
            if (String.IsNullOrEmpty(this._apellido))
            {
                throw new Exception("El apellido no puede estar vacío.");
            }
            if (String.IsNullOrEmpty(this._contrasena) )
            {
                throw new Exception("La contraseña debe contener 8 caracteres");
            }
           
            if (String.IsNullOrEmpty(this._email))
            {
                throw new Exception("El email no puede estar vacio");
            }

        }
        public override string ToString()
        {
            return "\n - Id: " + this._id +
                   "\n - Nombre: " + this._nombre +
                   "\n - Apellido: " + this._apellido +
                   "\n - Email: " + this._email +
                    "\n - Contraseña:" + this._contrasena;
        }

    
        

    }
}

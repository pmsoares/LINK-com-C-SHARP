using System;

namespace LinqToObjects
{
    public enum TipoContacto
    {
        Telefone,
        Email
    }

    public abstract class Contacto
    {
        public String Valor { get; set; }
        public abstract TipoContacto TipoContacto { get; }
    }

    public class Telefone : Contacto
    {
        public override TipoContacto TipoContacto
        {
            get { return TipoContacto.Telefone; }
        }
    }

    public class Email : Contacto
    {
        public override TipoContacto TipoContacto
        {
            get { return TipoContacto.Email; }
        }
    }
}
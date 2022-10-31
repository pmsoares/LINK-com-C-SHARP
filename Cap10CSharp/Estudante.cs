using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public class Estudante
    {
        public String Nome { get; set; }
        public Morada Morada { get; set; }
        public Int32 IdTurma{ get; set;}

        public IList<Contacto> Contactos { get; set; }
        public IList<Disciplina> Disciplinas { get; set; }
    }
}
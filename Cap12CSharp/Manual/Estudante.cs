using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace LINQToSQL.Manual {
    [Table(Name="Estudantes")]
    public class Estudante {
        [Column(IsPrimaryKey=true, IsDbGenerated=true, DbType="INT NOT NULL IDENTITY", AutoSync=AutoSync.OnInsert)]
        public int IdEstudante { get; set; }
        [Column]public string Nome { get; set; }
        [Column(IsVersion=true)]public byte[] Versao{ get; set; }

        private EntityRef<Morada> _morada;
        [Association(Storage="_morada",ThisKey="IdEstudante", OtherKey="IdEstudante")]
        public Morada Morada {
            get { return _morada.Entity; }
            set { _morada.Entity = value; }
        }

//        public Estudante()
//        {
//            _contactos = new EntitySet<Contacto>();
//        }

        private EntitySet<Contacto> _contactos;
        [Association(Storage="_contactos",OtherKey="IdEstudante", ThisKey="IdEstudante")]
        public IList<Contacto> Contactos {
            get { return _contactos; }
            set { _contactos.Assign(value); }
        }

        [Association(ThisKey="IdEstudante", OtherKey="IdEstudante")]
        private EntitySet<DisciplinasEstudantes> DisciplinasEstudantes;
        public IEnumerable<Disciplina> Disciplinas {
            get { return DisciplinasEstudantes.Select(d => d.Disciplina); }
        }

        public void Detach()
        {
            _morada = default(EntityRef<Morada>);
            _contactos = new EntitySet<Contacto>();
            DisciplinasEstudantes = new EntitySet<DisciplinasEstudantes>();
        }

        /*
        private EntitySet<Disciplina> _disciplinas;
        public EntitySet<Disciplina> Disciplinas {
            get { return _disciplinas; }
            set { _disciplinas.Assign(value); }
        }*/

    }
}

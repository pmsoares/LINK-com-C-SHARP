using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LINQToSQL.Manual {
    [Table(Name = "DisciplinasEstudantes")]
    public class DisciplinasEstudantes {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL IDENTITY", AutoSync = AutoSync.OnInsert)]
        public int IdDisciplinaEstudante { get; set; }
        [Column]
        public int IdDisciplina { get; set; }
        [Column]
        public int IdEstudante { get; set; }

        private EntityRef<Estudante> _estudante;
        [Association(Storage = "_estudante", ThisKey = "IdEstudante", OtherKey = "IdEstudante")]
        public Estudante Estudante {
            get { return _estudante.Entity; }
            set { _estudante.Entity = value; }
        }

        private EntityRef<Disciplina> _disciplina;
        [Association(Storage = "_disciplina", ThisKey = "IdDisciplina", OtherKey = "IdDisciplina")]
        public Disciplina Disciplina {
            get { return _disciplina.Entity; }
            set { _disciplina.Entity = value; }
        }
    }
}

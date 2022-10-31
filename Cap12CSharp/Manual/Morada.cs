using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LINQToSQL.Manual {
    [Table(Name="Moradas")]
    public class Morada {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL IDENTITY", AutoSync = AutoSync.OnInsert)]
        public int IdMorada { get; set; }
        [Column]public int IdEstudante { get; set; }
        [Column]public string Rua { get; set; }
        [Column]public string CodigoPostal { get; set; }
        [Column(IsVersion=true)]public byte[] Versao { get; set; }

        private EntityRef<Estudante> _estudante;
        [Association(Storage = "_estudante", ThisKey = "IdEstudante", OtherKey = "IdEstudante", IsUnique = true, IsForeignKey = true, DeleteOnNull = true)]
        public Estudante Estudante {
            get { return _estudante.Entity; }
            set { _estudante.Entity = value; }
        }
    }
}

using System.Data.Linq.Mapping;

namespace LINQToSQL.Manual {
    [Table(Name="Disciplinas")]
    public class Disciplina {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL IDENTITY", AutoSync = AutoSync.OnInsert)]
        public int IdDisciplina { get; set; }
        [Column]public string Designacao { get; set; }
        [Column(IsVersion = true)]public byte[] Versao { get; set; }
    }
}

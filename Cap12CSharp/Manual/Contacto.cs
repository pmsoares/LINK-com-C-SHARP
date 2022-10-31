using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LINQToSQL.Manual {
    [Table(Name = "Contactos")]
    [InheritanceMapping(Code=0, Type=typeof(Telefone), IsDefault=true)]
    [InheritanceMapping(Code=1, Type=typeof(Email))]
    public class Contacto {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL IDENTITY", AutoSync = AutoSync.OnInsert)]
        public int IdContacto { get; set; }
        [Column]
        public int IdEstudante { get; set; }
        [Column]
        public string Valor { get; set; }
        [Column(Name = "Tipo",IsDiscriminator=true)]
        public int TipoContacto { get; set; }
        [Column(IsVersion = true)]
        public byte[] Versao { get; set; }

    }

    public class Telefone : Contacto {
    }

    public class Email : Contacto {
    }
}

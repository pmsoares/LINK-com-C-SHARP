using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace LINQToSQL.Manual
{
    public class CustomContext : DataContext
    {
        public CustomContext(string connectionString)
            : base(connectionString)
        {
        }

        [Function(Name = "dbo.ObtemContactos")]
        public IEnumerable<InfoEstudante> ObtemContactosEstudantes()
        {
            var aux =
                ExecuteMethodCall(this,
                                  (MethodInfo) (MethodBase.GetCurrentMethod()));
            return (IEnumerable<InfoEstudante>) (aux.ReturnValue);
        }

        [Function(Name = "dbo.ObtemContactosDoEstudante")]
        public IEnumerable<InfoEstudante> ObtemContactosDoEstudante([Parameter(Name = "id")] int id)
        {
            var aux =
                ExecuteMethodCall(this,
                                  (MethodInfo) (MethodBase.GetCurrentMethod()),
                                  id);
            return (IEnumerable<InfoEstudante>) (aux.ReturnValue);
        }
    }


    public class InfoEstudante
    {
        public string Nome { get; set; }

        [Column(Name = "Valor")]
        public string Contacto { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cap14CSharp {
    class Program {
        private static void Main(string[] args) {
            new Program().Query();
        }

        private void Query() {
            var liveKey = "F8A1EE74E4CD75A9D1B542287A9D868185518B5F";
            var liveContext = new LiveSearchContext(liveKey);
            
            var query2 = from item in liveContext.Web
                        where item.Titulo == "Luis"
                        select item;

            foreach (var hit in query2) {
                Console.WriteLine(String.Format("Url: {0}", hit.Url));
                Console.WriteLine(String.Format("Titulo: {0}", hit.Titulo));
                Console.WriteLine(String.Format("Descricao: {0}", hit.Descricao));
                Console.WriteLine("-------------------------");
            }

            var query3 = from item in liveContext.News
                        where item.Titulo == "Luis"
                        select item;

            foreach (var hit in query3) {
                Console.WriteLine(String.Format("Url: {0}", hit.Url));
                Console.WriteLine(String.Format("Titulo: {0}", hit.Titulo));
                Console.WriteLine(String.Format("Descricao: {0}", hit.Descricao));
                Console.WriteLine("-------------------------");
            }
        }
    }
}

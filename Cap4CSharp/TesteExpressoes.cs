using System;
using System.Linq.Expressions;

namespace Cap4CSharp 
{
    public class TesteExpressoes 
    {
        public void TestaExpressao()
        {
            Console.WriteLine("Utilização delegate Func");
            Func<int, int> duplicador = x => x * 2;
            Console.WriteLine("Execução da expressão: {0}", duplicador(2));

            Console.WriteLine("Utilização de árvores expressões");
            Expression<Func<int, int>> arvore = x => x * 2;
            // Número de parâmetros
            Console.WriteLine("Número parâmetros: {0}", arvore.Parameters.Count);
            foreach (var parameter in arvore.Parameters) 
            {
                // Tipo (int, float, etc.)
                Console.WriteLine("Tipo: {0}", parameter.Type);
                // Nome
                Console.WriteLine("Nome: {0}", parameter.Name);
                // Tipo de nó de expressão
                Console.WriteLine("Tipo nó: {0}", parameter.NodeType);
            }
            // Corpo
            Console.WriteLine("Corpo: {0}", arvore.Body);
            // Tipo de expressão do corpo
            Console.WriteLine("Tipo Corpo: {0}", arvore.Body.NodeType);
            // Lado esquerdo da expressão
            Console.WriteLine("Esquerda: {0}",
              ((BinaryExpression)arvore.Body).Left);
            // Lado direito da expressão
            Console.WriteLine("Direita: {0}",
              ((BinaryExpression)arvore.Body).Right);

        }
    }
}

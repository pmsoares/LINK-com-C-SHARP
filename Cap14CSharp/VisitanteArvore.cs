using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Cap14CSharp;
using Cap14CSharp.Live.Search;

namespace LINQToLive
{
    public class VisitanteArvore 
    {
        private StringBuilder _criterio;
        private List<String> _urls;
        private readonly string _appId;
        private SourceType _type;

        public VisitanteArvore(string appId, SourceType type)
        {
            _appId = appId;
            _type = type;
        }

        private void Inicializa()
        {
            _criterio = new StringBuilder();
            _urls = new List<string>();
        }

        public SearchRequest TraduzArvore(Expression expression)
        {
            Inicializa();
            VisitaNo(expression);
            return ConverteEmSearchRequest();
        }

        private SearchRequest ConverteEmSearchRequest()
        {
            var request = new SearchRequest
                              {
                                  AppID = _appId,
                                  Query = ConstroiQuery(),
                                  Requests = new[]
                                                 {
                                                     new SourceRequest
                                                         {
                                                             Source = _type
                                                         }
                                                 },
                                                 CultureInfo = "pt-PT"
                              };
            
            return request;
        }

        private string ConstroiQuery()
        {
            if (_urls.Count == 0) return _criterio.ToString();
            var total = string.Concat( _criterio.ToString(),
                                      " (SITE: ",
                                      string.Join(" OR ", _urls.ToArray()),
                                      ")");
            return total;
        }

        public void VisitaNo(Expression expression)
        {
            if (expression.NodeType == ExpressionType.Equal)
            {
                VisitaIgualdade((BinaryExpression) expression);
            }
            else if (expression.NodeType == ExpressionType.AndAlso)
            {
                VisitaAndAlso((BinaryExpression) expression);
            }
            else if (expression is MethodCallExpression)
            {
                VisitaInvocacaoMetodo((MethodCallExpression) expression);
            }
            else if(expression.NodeType == ExpressionType.Constant)
            {
                //apenas para permitir o funcionamento do metodo CreateQuery
            }
            else if (expression is LambdaExpression)
            {
                VisitaNo(((LambdaExpression) expression).Body);
            }
            else
            {
                throw new NotSupportedException("Este tipo de expressão não é suportada na versão actual");
            }
        }

        private void VisitaAndAlso(BinaryExpression expression)
        {
            var expressaoEsquerda = expression.Left;
            var expressaoDireita = expression.Right;
            VisitaNo(expressaoEsquerda);
            VisitaNo(expressaoDireita);
        }

        private void VisitaInvocacaoMetodo(MethodCallExpression expression)
        {
            if (string.Compare(expression.Method.Name, "Where") == 0)
            {
                VisitaNo(((UnaryExpression) expression.Arguments[1]).Operand);
                return;
            }
            throw new NotSupportedException(string.Format("Método {0} não é suportado nesta versão", expression.Method.Name));
        }

        private void VisitaIgualdade(BinaryExpression expression)
        {
            var ladoEsquerdo = expression.Left;
            if (ladoEsquerdo.IsMemberAccess())
            {
                var membro = ((MemberExpression) ladoEsquerdo).Member;
                var value = ObtemValorExpressaoDireita(expression.Right);
                if (string.Compare(membro.Name, "Titulo") == 0)
                {
                    if (_criterio.Length != 0)
                    {
                        _criterio.Append(" AND ");
                    }
                    _criterio.AppendFormat(" {0} ", value);
                    return;
                }
                if (String.Compare(membro.Name, "Url") == 0)
                {
                    _urls.Add(value);
                    return;
                }
                throw new NotSupportedException("Esta propriedade não pode ser usada nesta pesquisa");
            }
        }

        private string ObtemValorExpressaoDireita(Expression right)
        {
            if (right.NodeType == ExpressionType.Constant)
            {
                return ((ConstantExpression) right).Value.ToString();
            }
            if (right.NodeType == ExpressionType.MemberAccess)
            {
                return (string) ObtemValorMembro((MemberExpression) right);
            }
            throw new NotSupportedException();
        }

        private Object ObtemValorMembro(MemberExpression memberExpression) {
            MemberInfo memberInfo;
            Object obj;
            if (memberExpression.Member is FieldInfo 
                && ((FieldInfo)memberExpression.Member).IsStatic ){
                var fld = (FieldInfo) memberExpression.Member;
                return  fld.GetValue(null);
            }
            if (memberExpression.Expression is ConstantExpression)
                obj = ((ConstantExpression) memberExpression.Expression).Value;
            else if (memberExpression.Expression is MemberExpression)
                obj = ObtemValorMembro((MemberExpression) memberExpression.Expression);
            else
                throw new NotSupportedException("Expression type not supported: " +
                                                memberExpression.Expression.GetType().FullName);
            memberInfo = memberExpression.Member;
            if (memberInfo is PropertyInfo){
                var property = (PropertyInfo) memberInfo;
                return property.GetValue(obj, null);
            }
            if (memberInfo is FieldInfo) {
                var field = (FieldInfo) memberInfo;
                return field.GetValue(obj);
            }
            throw new NotSupportedException("MemberInfo type not supported: " + memberInfo.GetType().FullName);
        }
    }
}
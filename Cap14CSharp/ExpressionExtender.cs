using System;
using System.Linq.Expressions;

namespace Cap14CSharp
{
    public static class ExpressionExtender
    {
        public static Boolean IsMemberAccess(this Expression expression)
        {
            if (expression == null) return false;
            return expression.NodeType == ExpressionType.MemberAccess;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dnc.Queries
{
    public class Criteria
        : IQueryItem
    {
        #region Members.
        bool _calculateValue = false;
        dynamic _realValue = null;
        public CriteriaOperator _operator;
        #endregion

        #region Public props.
        public string Name { get; }
        public dynamic Value { get; set; }
        #endregion

        #region Ctor.
        public Criteria(string name, CriteriaOperator @operator, dynamic value)
        {
            Name = name;
            _operator = @operator;
            Value = value;
        }
        #endregion

        #region Methods for getting criteria value.
        public dynamic GetCriteriaRealValue()
        {
            if (_calculateValue)
                return _realValue;

            var value = Value as Expression;
            if (value != null)
            {
                _realValue = GetExpressionValue(value);
            }
            else
            {
                _realValue = value;
            }
            _calculateValue = true;
            return _realValue;
        }

        private dynamic GetExpressionValue(Expression expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
            switch (expression.NodeType)
            {
                case ExpressionType.Constant:
                    return ((ConstantExpression)expression).Value;
                case ExpressionType.Add:
                case ExpressionType.AddAssign:
                case ExpressionType.AddAssignChecked:
                case ExpressionType.AddChecked:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.AndAssign:
                case ExpressionType.ArrayIndex:
                case ExpressionType.ArrayLength:
                case ExpressionType.Assign:
                case ExpressionType.Block:
                case ExpressionType.Call:
                case ExpressionType.Coalesce:
                case ExpressionType.Conditional:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.DebugInfo:
                case ExpressionType.Decrement:
                case ExpressionType.Default:
                case ExpressionType.Divide:
                case ExpressionType.DivideAssign:
                case ExpressionType.Dynamic:
                case ExpressionType.Equal:
                case ExpressionType.ExclusiveOr:
                case ExpressionType.ExclusiveOrAssign:
                case ExpressionType.Extension:
                case ExpressionType.Goto:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Increment:
                case ExpressionType.Index:
                case ExpressionType.Invoke:
                case ExpressionType.IsFalse:
                case ExpressionType.IsTrue:
                case ExpressionType.Label:
                case ExpressionType.Lambda:
                case ExpressionType.LeftShift:
                case ExpressionType.LeftShiftAssign:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.ListInit:
                case ExpressionType.Loop:
                case ExpressionType.MemberAccess:
                case ExpressionType.MemberInit:
                case ExpressionType.Modulo:
                case ExpressionType.ModuloAssign:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyAssign:
                case ExpressionType.MultiplyAssignChecked:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.New:
                case ExpressionType.NewArrayBounds:
                case ExpressionType.NewArrayInit:
                case ExpressionType.Not:
                case ExpressionType.NotEqual:
                case ExpressionType.OnesComplement:
                case ExpressionType.Or:
                case ExpressionType.OrAssign:
                case ExpressionType.OrElse:
                case ExpressionType.Parameter:
                case ExpressionType.PostDecrementAssign:
                case ExpressionType.PostIncrementAssign:
                case ExpressionType.Power:
                case ExpressionType.PowerAssign:
                case ExpressionType.PreDecrementAssign:
                case ExpressionType.PreIncrementAssign:
                case ExpressionType.Quote:
                case ExpressionType.RightShift:
                case ExpressionType.RightShiftAssign:
                case ExpressionType.RuntimeVariables:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractAssign:
                case ExpressionType.SubtractAssignChecked:
                case ExpressionType.SubtractChecked:
                case ExpressionType.Switch:
                case ExpressionType.Throw:
                case ExpressionType.Try:
                case ExpressionType.TypeAs:
                case ExpressionType.TypeEqual:
                case ExpressionType.TypeIs:
                case ExpressionType.UnaryPlus:
                case ExpressionType.Unbox:
                    return ((LambdaExpression)expression).Compile().DynamicInvoke();
                default:
                    throw new Exception("not existed this type.");
            }

        } 
        #endregion
    }
}

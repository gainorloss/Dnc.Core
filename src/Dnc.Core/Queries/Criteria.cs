using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Queries
{
    public class Criteria
        :IQueryItem
    {
        #region Public props.
        public string Name { get; }
        public CriteriaOperator _operator;
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


    }
}

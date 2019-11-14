﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace NonFactors.Mvc.Grid
{
    public class EnumFilter : BaseGridFilter
    {
        protected override Expression Apply(Expression expression, String value)
        {
            if (String.IsNullOrEmpty(value) && Nullable.GetUnderlyingType(expression.Type) == null)
                expression = Expression.Convert(expression, typeof(Nullable<>).MakeGenericType(expression.Type));

            try
            {
                Object enumValue = TypeDescriptor.GetConverter(expression.Type).ConvertFrom(value);

                switch (Method)
                {
                    case "equals":
                        return Expression.Equal(expression, Expression.Constant(enumValue, expression.Type));
                    case "not-equals":
                        return Expression.NotEqual(expression, Expression.Constant(enumValue, expression.Type));
                    default:
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}

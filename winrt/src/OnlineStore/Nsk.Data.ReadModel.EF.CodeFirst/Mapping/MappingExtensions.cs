
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Reflection.Emit;
using System.Threading;

namespace Nsk.Data.ReadModel.EF.CodeFirst.Mapping
{
    public static class MappingExtensions
    {
        public static EntityTypeConfiguration<TEntity> FixedOrderItemHasKey<TEntity>(this EntityTypeConfiguration<TEntity> mapper, String columnKey1, String columnKey2)
            where TEntity : class
        {
            Type type = typeof(TEntity);
            PropertyInfo p1 = type.GetProperty(columnKey1, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo p2 = type.GetProperty(columnKey2, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            ParameterExpression parameterExpression = Expression.Parameter(type, "x");

            MemberExpression memberExpression1 = Expression.Property(parameterExpression, p1);
            MemberExpression memberExpression2 = Expression.Property(parameterExpression, p2);

            Type anType = new { OrderId = 1, ProductId = 2 }.GetType();

            PropertyInfo p3 = anType.GetProperty(columnKey1);
            PropertyInfo p4 = anType.GetProperty(columnKey2);

            ConstructorInfo cInfo = anType.GetConstructor(new Type[] { typeof(int), typeof(int) });

            NewExpression expr = Expression.New(cInfo,
                new MemberExpression[] { memberExpression1, memberExpression2 },
                new MemberInfo[] { p3, p4 });

            LambdaExpression lambda = Expression.Lambda<Func<TEntity, dynamic>>(expr, parameterExpression);

            Expression<Func<TEntity, dynamic>> hasKeyExpression = (Expression<Func<TEntity, dynamic>>)lambda;

            return mapper.HasKey(hasKeyExpression);
        }
    }
}
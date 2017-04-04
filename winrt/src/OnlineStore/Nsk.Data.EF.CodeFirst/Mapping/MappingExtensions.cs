
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

namespace Nsk.Data.EF.CodeFirst.Mapping
{
    public static class MappingExtensions
    {
        private static Expression<Func<T, K>> CreateExpression<T, K>(String propertyName)
        {
            Type type = typeof(T);
            PropertyInfo pi = type.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            if (pi == null) throw new ArgumentException("propertyName is not valid.");

            ParameterExpression argumentExpression = Expression.Parameter(type, "x");
            MemberExpression memberExpression = Expression.Property(argumentExpression, pi);
            LambdaExpression lambda = Expression.Lambda(memberExpression, argumentExpression);

            Expression<Func<T, K>> expression = (Expression<Func<T, K>>)lambda;

            return expression;
        }

        /// <summary>
        /// Primitive mapping.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="KPropertyType"></typeparam>
        /// <param name="mapper"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static PrimitivePropertyConfiguration Property<TEntity, KPropertyType>(this EntityTypeConfiguration<TEntity> mapper, String propertyName)
            where TEntity : class
            where KPropertyType : struct
        {
            Expression<Func<TEntity, KPropertyType>> expression = CreateExpression<TEntity, KPropertyType>(propertyName);

            return mapper.Property(expression);
        }

        /// <summary>
        /// Custom Many.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="KTargetEntity"></typeparam>
        /// <param name="mapper"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static DependentNavigationPropertyConfiguration<TEntity> WithMany<TEntity, KTargetEntity>(
            this  OptionalNavigationPropertyConfiguration<TEntity, KTargetEntity> mapper, String propertyName)
            where TEntity : class
            where KTargetEntity : class
        {
            Type type = typeof(KTargetEntity);

            ParameterExpression argumentExpression = Expression.Parameter(type, "x");

            PropertyInfo pi = type.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            MemberExpression memberExpression = Expression.Property(argumentExpression, pi);

            LambdaExpression lambda = Expression.Lambda(memberExpression, argumentExpression);

            var expression = (Expression<Func<KTargetEntity, ICollection<TEntity>>>)lambda;

            return mapper.WithMany(expression);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="KKeyType"></typeparam>
        /// <param name="mapper"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static EntityTypeConfiguration<TEntity> HasKey<TEntity, KKeyType>(this EntityTypeConfiguration<TEntity> mapper, String propertyName)
            where TEntity : class
            where KKeyType : struct
        {
            Expression<Func<TEntity, KKeyType>> expression = CreateExpression<TEntity, KKeyType>(propertyName);

            EntityTypeConfiguration<TEntity> m = mapper.HasKey<KKeyType>(expression);

            return mapper;
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="mapper"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static ManyNavigationPropertyConfiguration<T, U> HasMany<T, U>(this EntityTypeConfiguration<T> mapper, String propertyName)
            where T : class
            where U : class
        {
            Type type = typeof(T);

            PropertyInfo pi = type.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            if (pi == null) throw new ArgumentException("propertyName is not valid.");

            ParameterExpression parameterExpression = Expression.Parameter(type, "x");
            MemberExpression memberExpression = Expression.Property(parameterExpression, pi);
            LambdaExpression lambda = Expression.Lambda(memberExpression, parameterExpression);

            Expression<Func<T, ICollection<U>>> expression = (Expression<Func<T, ICollection<U>>>)lambda;

            return mapper.HasMany(expression);
        }


        public static StringPropertyConfiguration PropertyStr<T>(this EntityTypeConfiguration<T> mapper, String propertyName) where T : class
        {
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;

            PropertyInfo pi = type.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            expr = Expression.Property(expr, pi);

            LambdaExpression lambda = Expression.Lambda(expr, arg);

            Expression<Func<T, String>> expression = (Expression<Func<T, String>>)lambda;
            return mapper.Property(expression);
        }
    }
}
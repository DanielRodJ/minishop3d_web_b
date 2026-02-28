using System.Linq.Expressions;

namespace Application.Common
{

    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> query, string? sortColumn, bool descending)
        {
            if (string.IsNullOrWhiteSpace(sortColumn)) return query;

            var propertyInfo = typeof(T).GetProperty(sortColumn, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            if (propertyInfo == null) return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyInfo);
            var lambda = Expression.Lambda(property, parameter);

            string methodName = descending ? "OrderByDescending" : "OrderBy";

            var method = typeof(Queryable).GetMethods()
                .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), property.Type);

            return (IQueryable<T>)method.Invoke(null, new object[] { query, lambda })!;
        }
    }

}

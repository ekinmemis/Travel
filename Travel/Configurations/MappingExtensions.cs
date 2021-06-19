using AutoMapper;

using System.Linq;

namespace Travel.Configurations
{
    /// <summary>
    /// Defines the <see cref="MappingExtensions" />.
    /// </summary>
    public static class MappingExtensions
    {
        /// <summary>
        /// The MapTo.
        /// </summary>
        /// <typeparam name="TSource">.</typeparam>
        /// <typeparam name="TDestination">.</typeparam>
        /// <param name="source">The source<see cref="TSource"/>.</param>
        /// <returns>The <see cref="TDestination"/>.</returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// The MapTo.
        /// </summary>
        /// <typeparam name="TSource">.</typeparam>
        /// <typeparam name="TDestination">.</typeparam>
        /// <param name="source">The source<see cref="TSource"/>.</param>
        /// <param name="destination">The destination<see cref="TDestination"/>.</param>
        /// <returns>The <see cref="TDestination"/>.</returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        /// <summary>
        /// The IgnoreAllVirtual.
        /// </summary>
        /// <typeparam name="TSource">.</typeparam>
        /// <typeparam name="TDestination">.</typeparam>
        /// <param name="expression">The expression<see cref="IMappingExpression{TSource, TDestination}"/>.</param>
        /// <returns>The <see cref="IMappingExpression{TSource, TDestination}"/>.</returns>
        public static IMappingExpression<TSource, TDestination> IgnoreAllVirtual<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var desType = typeof(TDestination);

            foreach (var property in desType.GetProperties().Where(p => p.GetGetMethod().IsVirtual))
                expression.ForMember(property.Name, opt => opt.Ignore());

            return expression;
        }
    }
}

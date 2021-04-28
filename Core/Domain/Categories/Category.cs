using Core.Domain.Main;
using System.Collections.Generic;

namespace Core.Domain.Categories
{
    /// <summary>
    /// Defines the <see cref="Category" />.
    /// </summary>
    public partial class Category : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Blog.
        /// </summary>
        public ICollection<Blog> Blog { get; set; }
    }
}
using Core.Domain.Categories;
using System;
using System.Collections.Generic;

namespace Core.Domain.Main
{
    /// <summary>
    /// Defines the <see cref="Blog" />.
    /// </summary>
    public partial class Blog : BaseEntity
    {
        /// <summary>
        /// Gets or sets the CreateDate.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate.
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the Image1.
        /// </summary>
        public string Image1 { get; set; }

        /// <summary>
        /// Gets or sets the Image2.
        /// </summary>
        public string Image2 { get; set; }

        /// <summary>
        /// Gets or sets the Definition.
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Comments.
        /// </summary>
        public ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// Gets or sets the CategoryId.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        public Category Category { get; set; }
    }
}

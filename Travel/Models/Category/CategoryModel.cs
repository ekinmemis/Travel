using System;

namespace Travel.Models.Category
{
    /// <summary>
    /// Defines the <see cref="CategoryModel" />.
    /// </summary>
    public class CategoryModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        public bool IsActive { get; set; }
    }
}

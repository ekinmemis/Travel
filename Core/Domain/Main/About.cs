using System;

namespace Core.Domain.Main
{
    /// <summary>
    /// Defines the <see cref="About" />.
    /// </summary>
    public partial class About : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the ShortDefinition.
        /// </summary>
        public string ShortDefinition { get; set; }

        /// <summary>
        /// Gets or sets the Definition.
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the Note.
        /// </summary>
        public string Note { get; set; }
    }
}

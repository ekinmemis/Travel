using System;

namespace Core.Domain.Main
{
    /// <summary>
    /// Defines the <see cref="About" />.
    /// </summary>
    public partial class About : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the Definition.
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        public DateTime CreateDate { get; set; }

        public string Note { get; set; }
        #endregion
    }
}

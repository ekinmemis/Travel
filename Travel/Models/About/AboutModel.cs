using System;

namespace Travel.Models.About
{
    /// <summary>
    /// Defines the <see cref="AboutModel" />.
    /// </summary>
    public class AboutModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Gets or sets the CreateDate.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the Note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the ShortDefinition.
        /// </summary>
        public string ShortDefinition { get; set; }

        /// <summary>
        /// Gets or sets the DateString.
        /// </summary>
        public string DateString { get; set; }
    }
}

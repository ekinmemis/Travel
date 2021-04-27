namespace Core.Domain.Main
{
    /// <summary>
    /// Defines the <see cref="HomePage" />.
    /// </summary>
    public partial class HomePage : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Definition.
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Gets or sets the FullName.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }
    }
}

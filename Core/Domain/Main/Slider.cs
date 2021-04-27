namespace Core.Domain.Main
{
    /// <summary>
    /// Defines the <see cref="Slider" />.
    /// </summary>
    public partial class Slider : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the Definition.
        /// </summary>
        public string Title { get; set; }
    }
}

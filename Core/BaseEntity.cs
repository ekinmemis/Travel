namespace Core
{
    /// <summary>
    /// Defines the <see cref="BaseEntity" />.
    /// </summary>
    public partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Deleted.
        /// </summary>
        public bool Deleted { get; set; }
    }
}

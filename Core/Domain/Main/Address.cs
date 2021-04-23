namespace Core.Domain.Main
{
    /// <summary>
    /// Defines the <see cref="Address" />.
    /// </summary>
    public partial class Address : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Adres.
        /// </summary>
        public string Adres { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Telefon.
        /// </summary>
        public string Telefon { get; set; }

        /// <summary>
        /// Gets or sets the Location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Definition.
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        #endregion


    }
}

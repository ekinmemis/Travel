namespace Core.Domain.Main
{
    /// <summary>
    /// Defines the <see cref="Contact" />.
    /// </summary>
    public partial class Contact : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Definition.
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Gets or sets the PhoneNumberTitle.
        /// </summary>
        public string PhoneNumberTitle { get; set; }

        /// <summary>
        /// Gets or sets the PhoneNumberSubject.
        /// </summary>
        public string PhoneNumberSubject { get; set; }

        /// <summary>
        /// Gets or sets the PostalAdressTitle.
        /// </summary>
        public string PostalAdressTitle { get; set; }

        /// <summary>
        /// Gets or sets the PostalAddressSubject.
        /// </summary>
        public string PostalAddressSubject { get; set; }

        /// <summary>
        /// Gets or sets the EmailAddress.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the EmailSubject.
        /// </summary>
        public string EmailSubject { get; set; }
    }
}

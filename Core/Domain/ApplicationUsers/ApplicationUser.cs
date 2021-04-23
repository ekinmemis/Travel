namespace Core.Domain.ApplicationUsers
{
    /// <summary>
    /// Defines the <see cref="ApplicationUser" />.
    /// </summary>
    public partial class ApplicationUser : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        public string UserName { get; set; }

        #endregion
    }
}

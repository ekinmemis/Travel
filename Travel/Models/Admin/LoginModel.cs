using System.ComponentModel.DataAnnotations;

namespace Travel.Models.Admin
{
    /// <summary>
    /// Defines the <see cref="LoginModel" />.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

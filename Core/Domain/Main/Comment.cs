using System;

namespace Core.Domain.Main
{
    /// <summary>
    /// Defines the <see cref="Comment" />.
    /// </summary>
    public partial class Comment : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CreateDate.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Subject.
        /// </summary>
        public string Subject { get; set; }


        #endregion

        #region Properties
        
        /// <summary>
        /// Gets or sets the BlogId.
        /// </summary>
        public int BlogId { get; set; }

        /// <summary>
        /// Gets or sets the Blog.
        /// </summary>
        public Blog Blog { get; set; }

        #endregion


    }
}

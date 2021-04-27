using Core.Domain.ApplicationUsers;
using Core.Domain.Main;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data
{
    /// <summary>
    /// Defines the <see cref="TravelDataContext" />.
    /// </summary>
    public class TravelDataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TravelDataContext"/> class.
        /// </summary>
        public TravelDataContext() : base("name=TravelDataContext")
        {
        }

        /// <summary>
        /// The OnModelCreating.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="DbModelBuilder"/>.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        /// <summary>
        /// Gets or sets the ApplicationUser.
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        /// <summary>
        /// Gets or sets the About.
        /// </summary>
        public DbSet<About> About { get; set; }

        /// <summary>
        /// Gets or sets the Blog.
        /// </summary>
        public DbSet<Blog> Blog { get; set; }

        /// <summary>
        /// Gets or sets the Comment.
        /// </summary>
        public DbSet<Comment> Comment { get; set; }

        /// <summary>
        /// Gets or sets the HomePage.
        /// </summary>
        public DbSet<HomePage> HomePage { get; set; }

        /// <summary>
        /// Gets or sets the Contact.
        /// </summary>
        public DbSet<Contact> Contact { get; set; }

        /// <summary>
        /// Gets or sets the Slider.
        /// </summary>
        public DbSet<Slider> Slider { get; set; }
    }
}

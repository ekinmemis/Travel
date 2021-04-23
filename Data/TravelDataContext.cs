using Core.Domain.ApplicationUsers;
using Core.Domain.Main;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data
{
    public class TravelDataContext : DbContext
    {
        public TravelDataContext() : base("name=TravelDataContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Blog> Blog{ get; set; }
        public DbSet<Comment> Comment{ get; set; }
        public DbSet<HomePage> HomePage{ get; set; }
    }
}

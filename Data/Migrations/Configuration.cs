namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Defines the <see cref="Configuration" />.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<Data.TravelDataContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// The Seed.
        /// </summary>
        /// <param name="context">The context<see cref="Data.TravelDataContext"/>.</param>
        protected override void Seed(Data.TravelDataContext context)
        {
            context.About.Add(new Core.Domain.Main.About
            {
                CreateDate = DateTime.Now,
                Definition = "Kategori - 1",
                Deleted = false,
                Id = 1,
                Image = "test.jpg",
                IsActive = true,
                Note = "note",
                ShortDefinition = "ShortDefinition",
                Title = "Title"
            });

            context.ApplicationUser.Add(new Core.Domain.ApplicationUsers.ApplicationUser
            {
                IsActive = true,
                Deleted = false,
                Email = "memis.ekin@gmail.com",
                FirstName = "ekin",
                Id = 1,
                LastName = "memis",
                Password = "123",
                UserName = "ekinmemis"
            });
            context.HomePage.Add(new Core.Domain.Main.HomePage
            {
                Id = 1,
                Definition = "Definition ",
                Deleted = false,
                FullName = "Test",
                Image = "test.jpg",
                Title = "title",
                IsActive = true
            });
            context.Slider.Add(new Core.Domain.Main.Slider { Deleted = false, Id = 1, Image = "test.jpg", Title = "Title", IsActive = true });
            context.SaveChanges();
        }
    }
}
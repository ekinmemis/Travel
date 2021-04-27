namespace Data.Migrations
{
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
        }
    }
}

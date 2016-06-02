namespace ScholarshipWebApplication.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ScholarshipWebApplication.Models.Database.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ScholarshipWebApplication.Models.Database.StudentContext";
        }

        protected override void Seed(ScholarshipWebApplication.Models.Database.StudentContext context){}
    }
}

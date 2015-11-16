using Shell.Models;

namespace Shell.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shell.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Shell.Models.ApplicationDbContext";
        }

        protected override void Seed(Shell.Models.ApplicationDbContext context)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Product[] p = new Product[]
            {
                new Product
                {
                    Title = "Walking Cane",
                    Price = 10.6,
                    Description = "The best walking cane"
                }
            };

            foreach (Product x in p)
            {
                db.Products.Add(x);
            }
            db.SaveChanges();
        }
    }
}

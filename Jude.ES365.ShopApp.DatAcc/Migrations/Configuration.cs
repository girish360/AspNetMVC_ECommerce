using System.Collections.Generic;
using Jude.ES365.ShopApp.DatAcc.Models;

namespace Jude.ES365.ShopApp.DatAcc.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Jude.ES365.ShopApp.DatAcc.Models.DataModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Jude.ES365.ShopApp.DatAcc.Models.DataModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            SeedCategory(context);
            SeedDefaultCustomer(context);
        }

        private void SeedCategory(DataModelContext context)
        {
            var defaultName = " Category ";

            var categories = new List<String> {"Men", "Women", "Kids", "Others"};

            var categoriesIds = new List<String>
            {
                "5110BE6C-00F4-46BA-B141-CC0B74B33EEF",
                "892F90E4-C533-49DE-A7EA-F1DD1DB7D01A",
                "042A2B12-1C92-465A-828C-69DCE587A1A7",
                "25457B16-486A-4153-85D1-F18F28802886"
            };

            for (var count = 0; count < 4; count++)
            {
                var category = new Category
                {
                    ID = new Guid(categoriesIds[count]),
                    ShortName = categories[count],
                    Code =categories[count].Substring(0,2),
                    Description = $"{categories[count]}{defaultName}"

                };
                
                context.Categories.AddOrUpdate(category);
            }

            context.SaveChanges();

        }

        public void SeedDefaultCustomer(DataModelContext context)
        {
            var customer = new Customer
            {
                ID = Guid.NewGuid(),
                FirstName = "Gabriel",
                LastName = "Le Roux",
                Address = "254 Dryer Street, Claremont Cape Town, ZA",
                Gender = true,
                Phone = "0793352641",
                Email = "info@judebabs.co.za",
                IsAccountValid = true
            };

            context.Customers.AddOrUpdate(customer);
            context.SaveChanges();

        }

       
    }
}

namespace PrintShop.data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PrintShop.data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PrintShop.data.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Client[] clients =
            {
                new Client
                {
                    Name = "Эдуард",
                    Lastname = "Петров",
                    Login = "Ad",
                    Email = "petrov01@Gmail.ru",
                    Password = "123"
                },
                new Client
                {
                    Name = "Артем",
                    Lastname = "Сидоров",
                    Login = "Art",
                    Email = "artem02@gmail.ru",
                    Password = "123"
                }
            };

            PrintItem[] prints =
             {
                new PrintItem
                {
                    ImageName = "Images/print1.jpg",
                    Title = "Leon"
                },
                new PrintItem
                {
                    ImageName = "Images/print2.jpg",
                    Title = "Vortex"
                },
                new PrintItem
                {
                    ImageName = "Images/print3.jpg",
                    Title = "Circle"
                },
                new PrintItem
                {
                    ImageName = "Images/print4.jpg",
                    Title = "Batman"
                },
                new PrintItem
                {
                    ImageName = "Images/print5.jpg",
                    Title = "BluePrint"
                },
                new PrintItem
                {
                    ImageName = "Images/print6.jpg",
                    Title = "Step"
                },
                new PrintItem
                {
                    ImageName = "Images/print7.jpg",
                    Title = "EADragon"
                },
                new PrintItem
                {
                    ImageName = "Images/print8.jpg",
                    Title = "FreshFish"
                },
                new PrintItem
                {
                    ImageName = "Images/print9.jpg",
                    Title = "Hand5"
                }
            };
            context.Client.AddOrUpdate(
                c => c.Login,
                clients);
            context.PrintItem.AddOrUpdate(
                c => c.Title,
                prints);
            context.SaveChanges();
        }
    }
}

using ProjectСlothingPrintShop.Domains;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectСlothingPrintShop.BusinessLogic
{
    public static class DefaultObjects
    {
        public static void Create()
        {
            var listClients = new List<Client>()
            {
                new Client()
                {
                    IdClient = Guid.NewGuid().ToString(),
                    Name = "Эдуард",
                    Lastname = "Петров",
                    Login = "Ad",
                    Email = "petrov@mail.ru",
                    Password = "123"
                },
                new Client()
                {
                    IdClient = Guid.NewGuid().ToString(),
                    Name = "Артем",
                    Lastname = "Сидоров",
                    Login = "Art",
                    Email = "art@mail.ru",
                    Password = "123"
                }
            };
            using (var fs = new FileStream("clients.xml", FileMode.Create))
            {
                var xms = new XmlSerializer(typeof(List<Client>));
                xms.Serialize(fs, listClients);
            }
            //----------------------------------------------
            string[] clothesTypes = { "толстовка", "кепка", "футболка", "шорты" };
            using (var fs = new FileStream("clothesTypes.xml", FileMode.Create))
            {
                var xms = new XmlSerializer(typeof(string[]));
                xms.Serialize(fs, clothesTypes);
            }
            //----------------------------------------------
            string[] clothesSizes = { "XS", "S", "M", "L", "XL", "XXL" };
            using (var fs = new FileStream("clothesSizes.xml", FileMode.Create))
            {
                var xms = new XmlSerializer(typeof(string[]));
                xms.Serialize(fs, clothesSizes);
            }
            //----------------------------------------------
            string[] delivery = { "почтой", "курьером", "самовывоз" };
            using (var fs = new FileStream("delivery.xml", FileMode.Create))
            {
                var xms = new XmlSerializer(typeof(string[]));
                xms.Serialize(fs, delivery);
            }
            //---------------------------------------------
            var listPrints = new List<PrintItem>()
            {
                new PrintItem()
                {
                    Id = 1,
                    ImageName = "images/print1.jpg",
                    Title = "Leon"
                },
                new PrintItem()
                {
                    Id = 2,
                    ImageName = "images/print2.jpg",
                    Title = "Vortex"
                },
                new PrintItem()
                {
                    Id = 3,
                    ImageName = "images/print3.jpg",
                    Title = "Circle"
                },
                new PrintItem()
                {
                    Id = 4,
                    ImageName = "images/print4.jpg",
                    Title = "Batman"
                },
                new PrintItem()
                {
                    Id = 5,
                    ImageName = "images/print5.jpg",
                    Title = "BluePrint"
                },
                new PrintItem()
                {
                    Id = 6,
                    ImageName = "images/print6.jpg",
                    Title = "Step"
                },
                new PrintItem()
                {
                    Id = 7,
                    ImageName = "images/print7.jpg",
                    Title = "EA Dragon"
                },
                new PrintItem()
                {
                    Id = 8,
                    ImageName = "images/print8.jpg",
                    Title = "Fresh Fish"
                },
                new PrintItem()
                {
                    Id = 9,
                    ImageName = "images/print9.jpg",
                    Title = "Hand 5"
                }
            };
            using (var fs = new FileStream("prints.xml", FileMode.Create))
            {
                var xms = new XmlSerializer(typeof(List<PrintItem>));
                xms.Serialize(fs, listPrints);
            }
        }

    }
}

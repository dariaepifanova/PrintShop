using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectСlothingPrintShop.Domains;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Collections;
using System.Globalization;

namespace ProjectСlothingPrintShop.DAL
{
    public class FileRepository : IRepository
    {
        private List<Client> _listClients;
        private List<PrintItem> _listPrints;
        private string[] _clothesTypes;
        private string[] _clothesSizes;
        private string[] _delivery;

        public FileRepository()
        {
            _listClients = null;
            _listPrints = null;
            _clothesTypes = null;
            _clothesSizes = null;
            _delivery = null;
        }
        public IEnumerable<Client> ReadClients()
        {
            if (_listClients != null) return _listClients;
            var fi = new FileInfo("clients.xml");
            if (fi.Exists)
            using (var fs = fi.OpenRead())
            {
                var xms = new XmlSerializer(typeof(List<Client>));
                _listClients = (List<Client>) xms.Deserialize(fs);
            }
            return _listClients;
        }

        public IEnumerable<PrintItem> ReadPrints()
        {
            if (_listPrints != null) return _listPrints;
            var fi = new FileInfo("prints.xml");
            if (fi.Exists)
                using (var fs = fi.OpenRead())
                {
                    var xms = new XmlSerializer(typeof(List<PrintItem>));
                    _listPrints = (List<PrintItem>)xms.Deserialize(fs);
                }
            return _listPrints;
        }

        public IEnumerable<string> ReadClothesTypes()
        {
            if (_clothesTypes != null) return _clothesTypes;
            var fi = new FileInfo("clothesTypes.xml");
            if (fi.Exists)
                using (var fs = fi.OpenRead())
                {
                    var xms = new XmlSerializer(typeof(string[]));
                    _clothesTypes = (string[])xms.Deserialize(fs);
                }
            return _clothesTypes;
        }

        public IEnumerable<string> ReadClothesSizes()
        {
            if (_clothesSizes != null) return _clothesSizes;
            var fi = new FileInfo("clothesSizes.xml");
            if (fi.Exists)
                using (var fs = fi.OpenRead())
                {
                    var xms = new XmlSerializer(typeof(string[]));
                    _clothesSizes = (string[])xms.Deserialize(fs);
                }
            return _clothesSizes;
        }

        public IEnumerable<string> ReadPrintsImages()
        {
            List<string> resourceNames = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var rm = new ResourceManager(assembly.GetName().Name + ".g", assembly);
            try
            {
                var list = rm.GetResourceSet(CultureInfo.CurrentCulture, true, true);
                foreach (DictionaryEntry item in list)
                    resourceNames.Add((string)item.Key);
            }
            finally
            {
                rm.ReleaseAllResources();
            }
            return resourceNames
                .Where(r => r.StartsWith("images") && r.EndsWith(".jpg"))
                .ToArray();
        }

        public IEnumerable<string> ReadDeliveryOptions()
        {
            if (_delivery != null) return _delivery;
            var fi = new FileInfo("delivery.xml");
            if (fi.Exists)
                using (var fs = fi.OpenRead())
                {
                    var xms = new XmlSerializer(typeof(string[]));
                    _delivery = (string[])xms.Deserialize(fs);
                }
            return _delivery;
        }

        public void SaveOrders(List<OrderDetails> orders)
        {
            var fi = new FileInfo("Orders.xml");
            using (var fs = fi.Create())
            {
                var xms = new XmlSerializer(typeof(List<OrderDetails>));
                xms.Serialize(fs, orders);
            }
        }
    }
}

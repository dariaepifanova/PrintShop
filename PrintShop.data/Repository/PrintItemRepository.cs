using PrintShop.data.Iterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.data.Repository
{
    internal class PrintItemRepository : Repository<PrintItem>, IPrintItemRepository
    {
        public PrintItemRepository(Context context) : base(context) { }
        public List<PrintItem> GetPrints()
        {
            return _context.PrintItem.ToList();
        }
    }
}

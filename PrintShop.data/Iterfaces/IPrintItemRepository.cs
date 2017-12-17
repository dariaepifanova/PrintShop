using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.data.Iterfaces
{
    public interface IPrintItemRepository : IRepository<PrintItem>
    {
        List<PrintItem> GetPrints();
    }
}

using HB.Domain.Entities;
using HB.Domain.Repositories;
using HB.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.Infrastructure.Repositories
{
    public class StockItemRepository : Repository<StockItem>,IStockItemRepository
    {
        public StockItemRepository(HbContext hbContext) : base(hbContext) { }
    }
}

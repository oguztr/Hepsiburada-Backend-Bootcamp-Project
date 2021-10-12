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
    public class FirmRepository : Repository<Firm> , IFirmRepository
    {
        public FirmRepository(HbContext hbContext) : base(hbContext) { }
    }
}

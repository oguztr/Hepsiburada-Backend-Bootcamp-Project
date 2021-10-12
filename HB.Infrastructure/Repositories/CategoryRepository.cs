using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HB.Domain.Entities;
using HB.Domain.Repositories;
using HB.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HB.Infrastructure.Repositories
{
    class CategoryRepository : Repository<Category>,ICategoryRepository 
    {
        public CategoryRepository(HbContext hbContext) : base(hbContext) { }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HB.Domain.Entities;

namespace HB.Infrastructure.Context
{
    public class HbContext : DbContext
    {
        public HbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Stock> Stocks{ get; set; }
        public DbSet<StockItem> StockItems{ get; set; }
        public DbSet<Firm> Firms{ get; set; }
        public DbSet<User> Users{ get; set; }
      
    }
}

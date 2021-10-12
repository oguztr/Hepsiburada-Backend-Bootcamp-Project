using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.Domain.Entities
{
    public class OrderItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("StockItem")]
        public Guid StockItem_Id { get; set; }
       
        public StockItem StockItem { get; set; }
        public Guid Order_Id { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Tax { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.Domain.Entities
{
    public class StockItem
    {
        public StockItem()
        {
            Id = new Guid();
        }
        [Key]
        public Guid Id { get; set; }
        public Guid? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public string Name { get; set; }
        public string? SerieNo { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HB.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid();
            isActive = 1;
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? isActive { get; set; }
        public ICollection<StockItem> StockItem { get; set; }

        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]

        public  ICollection<Category> SubCategories { get; set; }
    }
}

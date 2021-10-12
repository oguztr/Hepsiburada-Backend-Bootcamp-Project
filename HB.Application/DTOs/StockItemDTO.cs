using HB.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.Application.DTOs
{
    public class StockItemResponseDTO
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public Category Category { get; set; }
        public string SerieNo { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Tax { get; set; }
    }
}

using AutoMapper;
using HB.Application.Categories.Commands;
using HB.Application.Mapper;
using HB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Application.DTOs
{

    public class CategoryResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int isActive { get; set; }
        public virtual ICollection<StockItem> Items { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }
    }

}
